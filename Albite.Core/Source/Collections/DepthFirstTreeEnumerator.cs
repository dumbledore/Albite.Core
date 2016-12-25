﻿using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable 1591
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
        private INode<TValue> root;
        private INode<TValue> currentNode;

        // A stack of nodes to visit
        private Stack<INode<TValue>> nodesToVisit = new Stack<INode<TValue>>();

        // A temporary list of nodes to add to the stack. Use in order
        // to reverse the collection of nodes, so that we have pre-order
        // enumerator, instead of a post-order one.
        private List<INode<TValue>> tempNodes = new List<INode<TValue>>();

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

            this.root = root;

            Reset();
        }

        public void Reset()
        {
            currentNode = null;
            nodesToVisit.Clear();

            // Note the root could potentially have siblings
            prependSiblings(root);
        }

        public bool MoveNext()
        {
            if (nodesToVisit.Count == 0)
            {
                return false;
            }

            // Get the node on top of the stack
            currentNode = nodesToVisit.Pop();

            // Pre-pend its children
            prependSiblings(currentNode.FirstChild);

            // We have a current node
            return true;
        }

        private void prependSiblings(INode<TValue> node)
        {
            tempNodes.Clear();

            while (node != null)
            {
                tempNodes.Add(node);
                node = node.NextSibling;
            }

            // Now push the nodes in reverse so that
            // have pre-order traversal
            for (int i = tempNodes.Count - 1; i >= 0; i--)
            {
                nodesToVisit.Push(tempNodes[i]);
            }
        }

        public INode<TValue> Current
        {
            get { return currentNode; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() { }
    }
}
