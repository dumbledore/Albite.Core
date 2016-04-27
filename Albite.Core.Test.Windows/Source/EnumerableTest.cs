using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Albite.Core.Collections;

namespace Albite.Core.Test.Windows
{
    [TestClass]
    public class EnumerableTest
    {
        private static readonly string[] Data =
        {
            "One",
            "Two",
            "Ten",
        };

        [TestMethod]
        public void ListTest()
        {
            Test<string>(new List<string>(Data), true);
        }

        [TestMethod]
        public void LinkedList()
        {
            Test<string>(new LinkedList<string>(Data), true);
        }

        [TestMethod]
        public void StackTest()
        {
            Test<string>(new List<string>(new Stack<string>(Data)), true);
        }

        [TestMethod]
        public void QueueTest()
        {
            Test<string>(new List<string>(new Queue<string>(Data)), true);
        }

        [TestMethod]
        public void HashSetTest()
        {
            Test<string>(new HashSet<string>(Data), false);
        }

        [TestMethod]
        public void SortedSetTest()
        {
            Test<string>(new SortedSet<string>(Data), true);
        }

        private static void Test<T>(ICollection<T> data, bool sorted)
        {
            int count = ((IEnumerable)data).Count();
            Assert.AreEqual(data.Count, count);

            ICollection buffer = ((IEnumerable)data).ToBuffer();
            AreEqual(new List<T>(data), buffer, sorted);

            IEnumerable reverse = ((IEnumerable)data).Reverse();
            List<T> listReverse = new List<T>(data.Count);
            foreach (var o in reverse)
            {
                listReverse.Add((T)o);
            }
            AreEqual(new List<T>(data.Reverse<T>()), listReverse, sorted);
        }

        private static void AreEqual(ICollection colA, ICollection colB, bool sorted)
        {
            if (sorted)
            {
                CollectionAssert.AreEqual(colA, colB);
            }
            else
            {
                CollectionAssert.AreEquivalent(colA, colB);
            }
        }
    }
}
