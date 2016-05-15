using System;

namespace Albite.Collections
{
    public class Node<TValue> : INode<TValue>
    {
        public TValue Value { get; set; }

        INode<TValue> INode<TValue>.FirstChild
        {
            get { return FirstChild; }
        }

        public Node<TValue> FirstChild { get; private set; }

        public Node<TValue> LastChild
        {
            get
            {
                if (FirstChild != null)
                {
                    if (FirstChild.NextSibling != null)
                    {
                        return FirstChild.LastSibling;
                    }

                    // no siblings, so return the first child directly
                    return FirstChild;
                }

                return null;
            }
        }

        INode<TValue> INode<TValue>.NextSibling
        {
            get { return NextSibling; }
        }

        public Node<TValue> NextSibling { get; private set; }

        public Node<TValue> LastSibling
        {
            get
            {
                Node<TValue> sibling = NextSibling;
                if (sibling != null)
                {
                    while (sibling.NextSibling != null)
                    {
                        sibling = sibling.NextSibling;
                    }
                }

                return sibling;
            }
        }

        public void AddChild(Node<TValue> newChild)
        {
            newChild.makeSureNotAdded();

            if (FirstChild == null)
            {
                FirstChild = newChild;
            }
            else
            {
                LastChild.NextSibling = newChild;
            }
        }

        public void AddSibling(Node<TValue> newSibling)
        {
            newSibling.makeSureNotAdded();

            if (NextSibling != null)
            {
                newSibling.NextSibling = NextSibling;
            }

            NextSibling = newSibling;
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
        private void makeSureNotAdded()
        {
            if (_alreadyAdded)
            {
                throw new InvalidOperationException("Node already added");
            }

            _alreadyAdded = true;
        }

        private bool _alreadyAdded = false;
    }
}
