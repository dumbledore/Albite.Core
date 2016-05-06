using System.Collections.Generic;

#pragma warning disable 1591
namespace Albite.Collections
{
    public class CircularBufferQueue<TValue> : CircularBuffer<TValue>
    {
        public CircularBufferQueue(int maximumCapacity)
            : base(maximumCapacity) { }

        public CircularBufferQueue(IEnumerable<TValue> collection, int maximumCapacity)
            : base(collection, maximumCapacity) { }

        public void Enqueue(TValue item)
        {
            AddTail(item);
        }

        public TValue Dequeue()
        {
            return RemoveHead();
        }

        public TValue Peek()
        {
            return GetHead();
        }
    }
}
