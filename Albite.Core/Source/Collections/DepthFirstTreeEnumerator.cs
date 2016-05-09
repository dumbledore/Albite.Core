using System;
using System.Collections;
using System.Collections.Generic;

namespace Albite.Collections
{
    /// <summary>
    /// A depth-first pre-order enumerator
    ///
    /// Check: http://en.wikipedia.org/wiki/Tree_traversal#Pre-order
    /// </summary>
    /// <typeparam name="TValue">Type of the values for the tree nodes</typeparam>
    public class DepthFirstTreeEnumerator<TValue> : ITreeEnumerator<TValue>
    {
        private INode<TValue> _root;
        private INode<TValue> _currentNode;

        // A stack of nodes to visit
        private Stack<INode<TValue>> _toVisit = new Stack<INode<TValue>>();

        // A temporary list of nodes to add to the stack. Use in order
        // to reverse the collection of nodes, so that we have pre-order
        // enumerator, instead of a post-order one.
        private List<INode<TValue>> _temp = new List<INode<TValue>>();

        /// <summary>
        /// Creates an enumerator for the root node
        /// </summary>
        /// <param name="root"></param>
        public DepthFirstTreeEnumerator(INode<TValue> root)
        {
            if (root == null)
            {
                throw new NullReferenceException("Root node is null");
            }

            _root = root;

            Reset();
        }

        public void Reset()
        {
            _currentNode = null;
            _toVisit.Clear();

            // Note the root could potentially have siblings
            prependSiblings(_root);
        }

        public bool MoveNext()
        {
            if (_toVisit.Count == 0)
            {
                return false;
            }

            // Get the node on top of the stack
            _currentNode = _toVisit.Pop();

            // Pre-pend its children
            prependSiblings(_currentNode.FirstChild);

            // We have a current node
            return true;
        }

        private void prependSiblings(INode<TValue> node)
        {
            _temp.Clear();

            while (node != null)
            {
                _temp.Add(node);
                node = node.NextSibling;
            }

            // Now push the nodes in reverse so that
            // have pre-order traversal
            for (int i = _temp.Count - 1; i >= 0; i--)
            {
                _toVisit.Push(_temp[i]);
            }
        }

        public INode<TValue> Current
        {
            get { return _currentNode; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() { }
    }
}
