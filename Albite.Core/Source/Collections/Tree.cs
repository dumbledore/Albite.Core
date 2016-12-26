using Albite.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Albite.Collections
{
    public class Tree<TValue> : ITree<TValue>
    {
        [Serialized]
        public INode<TValue> Root { get; private set; }

        // For serialization
        private Tree() { }

        public Tree(INode<TValue> root)
        {
            Root = root;
        }

        public IEnumerator<INode<TValue>> GetEnumerator()
        {
            return new DepthFirstTreeEnumerator<TValue>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
