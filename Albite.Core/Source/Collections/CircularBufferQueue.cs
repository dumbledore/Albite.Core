using System.Collections.Generic;

namespace Albite.Collections
{
    public class CircularBufferQueue<TValue> : CircularBuffer<TValue>
    {
        // For serialization
        private CircularBufferQueue() { }

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
            return Head;
        }
    }
}
