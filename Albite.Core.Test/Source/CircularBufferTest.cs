using Albite.Collections;
using System;
using System.Collections.Generic;

namespace Albite.Test
{
    public class CircularBufferTest
    {
        private static int Iterations = 1000;

        public void PredefinedDataTest()
        {
            CircularBuffer<int> buffer = new CircularBuffer<int>(3);

            // check max capacity
            Assert.AreEqual(3, buffer.MaximumCapacity);

            // check if empty
            assertBuffer(buffer, new int[] { }, 0, true, false);

            // add to tail
            buffer.AddTail(1);

            // { 1 }
            assertBuffer(buffer, new int[] { 1 }, 1, false, false);

            // add to tail
            buffer.AddTail(2);

            // { 1, 2 }
            assertBuffer(buffer, new int[] { 1, 2 }, 2, false, false);

            // add to tail
            buffer.AddTail(3);

            // { 1, 2, 3 }
            assertBuffer(buffer, new int[] { 1, 2, 3 }, 3, false, true);

            // add to tail
            buffer.AddTail(4);

            // { 2, 3, 4 }
            assertBuffer(buffer, new int[] { 2, 3, 4 }, 3, false, true);

            // add to head
            buffer.AddHead(5);

            // { 5, 2, 3 }
            assertBuffer(buffer, new int[] { 5, 2, 3 }, 3, false, true);

            // remove tail
            Assert.AreEqual(buffer.GetTail(), buffer.RemoveTail());

            // { 5, 2 }
            assertBuffer(buffer, new int[] { 5, 2 }, 2, false, false);

            // add head
            buffer.AddHead(6);

            // { 6, 5, 2 }
            assertBuffer(buffer, new int[] { 6, 5, 2 }, 3, false, true);

            // remove head
            Assert.AreEqual(buffer.GetHead(), buffer.RemoveHead());

            // { 5, 2 }
            assertBuffer(buffer, new int[] { 5, 2 }, 2, false, false);

            // add head
            buffer.AddHead(7);

            // { 7, 5, 2 }
            assertBuffer(buffer, new int[] { 7, 5, 2 }, 3, false, true);

            // add head
            buffer.AddHead(8);

            // { 8, 7, 5 }
            assertBuffer(buffer, new int[] { 8, 7, 5 }, 3, false, true);

            // add head
            buffer.AddHead(9);

            // { 9, 8, 7 }
            assertBuffer(buffer, new int[] { 9, 8, 7 }, 3, false, true);

            // remove tail
            Assert.AreEqual(buffer.GetTail(), buffer.RemoveTail());

            // { 9, 8 }
            assertBuffer(buffer, new int[] { 9, 8 }, 2, false, false);

            // remove head
            Assert.AreEqual(buffer.GetHead(), buffer.RemoveHead());

            // { 8 }
            assertBuffer(buffer, new int[] { 8 }, 1, false, false);

            // remove tail
            Assert.AreEqual(buffer.GetTail(), buffer.RemoveTail());

            // { }
            assertBuffer(buffer, new int[] { }, 0, true, false);

            // GetHead() must throw exception on an empty list
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                buffer.GetHead();
            });

            // RemoveHead() must throw exception on an empty list
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                buffer.RemoveHead();
            });

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                buffer.GetTail();
            });

            // RemoveTail() must throw exception on an empty list
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                buffer.RemoveTail();
            });

            // add head
            buffer.AddHead(10);

            // { 10 }
            assertBuffer(buffer, new int[] { 10 }, 1, false, false);

            // add head
            buffer.AddHead(11);

            // { 11, 10 }
            assertBuffer(buffer, new int[] { 11, 10 }, 2, false, false);

            // Clear it
            buffer.Clear();

            // { }
            assertBuffer(buffer, new int[] { }, 0, true, false);
        }

        public void RandomDataTest()
        {
            int maxCapacity = 3;

            CircularBuffer<int> buffer = new CircularBuffer<int>(maxCapacity);

            List<int> list = new List<int>(maxCapacity);

            Random random = new Random();

            for (int i = 0; i < Iterations; i++)
            {
                int number = random.Next(5);
                int item = i;
                int removedItem;

                // 0 -> remove head
                // 1 -> add head
                // 2 -> remove tail
                // 3 -> add tail
                // 4 -> clear

                if ((number == 0 || number == 2) && list.Count == 0)
                {
                    // in case of removing an item, but the lists are empty,
                    // default to adding
                    number++;
                }

                switch (number)
                {
                    case 0:
                        // asert heads are the same
                        removedItem = buffer.GetHead();
                        Assert.AreEqual(list[0], removedItem);

                        // remove head from buffer
                        Assert.AreEqual(removedItem, buffer.RemoveHead());

                        // remove from list
                        list.RemoveAt(0);

                        // done
                        break;

                    case 1:
                        // add head to buffer
                        buffer.AddHead(item);

                        // remove tail if list is full
                        if (list.Count == maxCapacity)
                        {
                            list.RemoveAt(list.Count - 1);
                        }

                        // add head to list
                        list.Insert(0, item);

                        // done
                        break;

                    case 2:
                        // asert tails are the same
                        removedItem = buffer.GetTail();
                        Assert.AreEqual(list[list.Count - 1], removedItem);

                        // remove tail from buffer
                        Assert.AreEqual(removedItem, buffer.RemoveTail());

                        // remove from list
                        list.RemoveAt(list.Count - 1);

                        // done
                        break;

                    case 3:
                        // add tail to buffer
                        buffer.AddTail(item);

                        // remove head if list is full
                        if (list.Count == maxCapacity)
                        {
                            list.RemoveAt(0);
                        }

                        // add tail to list
                        list.Add(item);

                        // done
                        break;

                    case 4:
                        // clear buffer
                        buffer.Clear();

                        // clear list
                        list.Clear();

                        // done
                        break;
                }

                assertBuffer(buffer, list, list.Count, list.Count == 0, list.Count == maxCapacity);
            }
        }

        private void assertBuffer(CircularBuffer<int> buffer, IList<int> expected, int expectedCount, bool expectedEmpty, bool expectedFull)
        {
            // count as expected?
            Assert.AreEqual(expectedCount, buffer.Count);

            // empty?
            Assert.AreEqual(expectedEmpty, buffer.IsEmpty);

            // full?
            Assert.AreEqual(expectedFull, buffer.IsFull);

            // items as expected?
            // TODO
            //CollectionAssert.AreEqual((ICollection)expected, buffer);

            // for non-empty buffers
            if (expected.Count > 0)
            {
                // head as expected?
                Assert.AreEqual(expected[0], buffer.GetHead());

                // tail as expected?
                Assert.AreEqual(expected[expected.Count - 1], buffer.GetTail());
            }
        }
    }
}