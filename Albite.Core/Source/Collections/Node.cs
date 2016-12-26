using Albite.Serialization;
using System;

namespace Albite.Collections
{
    public class Node<TValue> : INode<TValue>
    {
        public Node() { }

        public Node(TValue value)
        {
            this.Value = value;
        }

        [Serialized]
        public TValue Value { get; set; }

        INode<TValue> INode<TValue>.FirstChild
        {
            get { return FirstChild; }
        }

        [Serialized]
        public Node<TValue> FirstChild { get; private set; }

        public Node<TValue> LastChild
        {
            get
            {
                if (FirstChild != null)
                {
                    Node<TValue> node = FirstChild;
                    while (node.NextSibling != null)
                    {
                        node = node.NextSibling;
                    }

                    return node;
                }

                return null;
            }
        }

        INode<TValue> INode<TValue>.NextSibling
        {
            get { return NextSibling; }
        }

        [Serialized]
        public Node<TValue> NextSibling { get; private set; }

        /// <summary>
        /// Adds a new child node as the last child node.
        /// </summary>
        /// <param name="node">The node object you want to append</param>
        /// <returns>The appended node</returns>
        public Node<TValue> AppendChild(Node<TValue> node)
        {
            node.assertNotAdded();

            if (FirstChild == null)
            {
                // No children
                FirstChild = node;
            }
            else
            {
                // Append at the end
                LastChild.NextSibling = node;
            }

            return node;
        }

        // This check is done so that the same node is not added
        // in different trees. Note that the node can still be empty,
        // i.e. firstChild/firstSibling being null, yet still can
        // be a leaf for several trees. That would be a logical
        // issue, so to keep things simple and static, the node
        // can be added only once. Of course, one can add
        // root/previousSibling and get a full-blown tree
        // yet, moving nodes around would make things complex,
        // which is not needed at the moment, i.e. static
        // trees are quite fine for now.
        private void assertNotAdded()
        {
            if (_alreadyAdded)
            {
                throw new InvalidOperationException("Node already added");
            }

            _alreadyAdded = true;
        }

        [Serialized]
        private bool _alreadyAdded = false;

        public override bool Equals(object obj)
        {
            Node<TValue> other = obj as Node<TValue>;

            if (other == null)
            {
                return false;
            }

            return Object.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return Value == null ? 0 : Value.GetHashCode();
        }
    }
}
