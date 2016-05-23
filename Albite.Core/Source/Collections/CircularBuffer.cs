using Albite.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Albite.Collections
{
    public class CircularBuffer<TValue> : IEnumerable<TValue>, ICollection
    {
        public int MaximumCapacity
        {
            get { return data.Length; }
        }

        [Serialized]
        // array holding items
        protected TValue[] data;

        [Serialized]
        // offset of current item
        protected int offset = 0;

        [Serialized]
        // total number of items
        protected int size = 0;

        // For serialization
        protected CircularBuffer() { }

        public CircularBuffer(int maximumCapacity)
        {
            if (maximumCapacity <= 0)
            {
                throw new ArgumentException("maximumCapacity must be positive");
            }

            data = new TValue[maximumCapacity];
        }

        public CircularBuffer(IEnumerable<TValue> collection, int maximumCapacity)
        {
            if (collection == null)
            {
                throw new NullReferenceException("collection is null");
            }

            TValue[] data = collection.ToArray();

            if (data.Length == 0)
            {
                throw new ArgumentException("collection is empty");
            }

            if (data.Length > maximumCapacity)
            {
                throw new ArgumentException("collection has more data than provided maximumCapacity");
            }

            // get the current size <= maximumCapacity
            this.size = data.Length;

            // create the new data array
            this.data = new TValue[maximumCapacity];

            // copy to store array
            Array.Copy(data, this.data, size);
        }

        public void Clear()
        {
            reset(true);
        }

        private void reset(bool clear)
        {
            offset = 0;
            size = 0;

            if (clear)
            {
                // Clear the data, so that we don't leak resources
                Array.Clear(data, 0, data.Length);
            }
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public bool IsFull
        {
            get { return Count == MaximumCapacity; }
        }

        public void AddHead(TValue item)
        {
            offset--;

            if (offset < 0)
            {
                // This should mean that offset == -1
                // but we are handling it in a generic way
                offset = MaximumCapacity + offset;
            }

            data[offset] = item;

            if (!IsFull)
            {
                // increment the size only if not full
                size++;
            }
        }

        public TValue Head
        {

            set
            {
                ThrowIfEmpty();
                int index = getHeadIndex();
                data[index] = value;
            }

            get
            {
                return getHead(false);
            }
        }

        public TValue RemoveHead()
        {
            return getHead(true);
        }

        private TValue getHead(bool remove)
        {
            ThrowIfEmpty();

            // get index
            int index = getHeadIndex();

            // get head
            TValue item = data[index];

            // remove?
            if (remove)
            {
                // don't leak
                data[index] = default(TValue);

                // move offset to the right, not forgetting it might wrap
                offset = wrapIndex(offset + 1);

                // decrement total size
                size--;
            }

            return item;
        }

        private int getHeadIndex()
        {
            return offset;
        }

        public void AddTail(TValue item)
        {
            if (IsFull)
            {
                // move the head
                offset = wrapIndex(offset + 1);
            }
            else
            {
                size++;
            }

            int index = wrapIndex(offset + size - 1);

            data[index] = item;
        }

        public TValue Tail
        {
            set
            {
                ThrowIfEmpty();
                int index = getTailIndex();
                data[index] = value;
            }

            get
            {
                return getTail(false);
            }
        }

        public TValue RemoveTail()
        {
            return getTail(true);
        }

        private TValue getTail(bool remove)
        {
            ThrowIfEmpty();

            // get index
            int index = getTailIndex();

            // get head
            TValue item = data[index];

            // remove?
            if (remove)
            {
                // don't leak
                data[index] = default(TValue);

                // decrement total size
                size--;
            }

            return item;
        }

        private int getTailIndex()
        {
            return wrapIndex(offset + size - 1);
        }

        protected void ThrowIfEmpty()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        private int wrapIndex(int index)
        {
            return index % MaximumCapacity;
        }

        // ICollection interface
        public int Count
        {
            get { return size; }
        }

        public bool IsSynchronized { get { return false; } }

        public object SyncRoot { get { return null; } }

        public void CopyTo(Array array, int index)
        {
            data.CopyTo(array, index);
        }

        // IEnumertor<> interface
        public IEnumerator<TValue> GetEnumerator()
        {
            return new Enumerator(this);
        }

        // IEnumertor interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Actual enumerator  that supports wrapping indices
        private class Enumerator : IEnumerator<TValue>
        {
            TValue[] data;
            int offset;
            int size;

            int currentIndex;

            public Enumerator(CircularBuffer<TValue> buffer)
            {
                data = buffer.data;
                offset = buffer.offset;
                size = buffer.size;

                Reset();
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            public bool MoveNext()
            {
                return (++currentIndex < size);
            }

            void IDisposable.Dispose() { }

            public TValue Current
            {
                get { return data[(offset + currentIndex) % data.Length]; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
