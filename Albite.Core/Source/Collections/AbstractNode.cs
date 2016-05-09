using System;

namespace Albite.Collections
{
    public abstract class AbstractNode<TValue> : INode<TValue>
    {
        public abstract TValue Value { get; }

        private AbstractNode<TValue> _firstChild;
        public INode<TValue> FirstChild
        {
            get { return _firstChild; }
        }

        public INode<TValue> LastChild
        {
            get { return _lastChild; }
        }

        private AbstractNode<TValue> _lastChild
        {
            get
            {
                if (_firstChild != null)
                {
                    if (_firstChild._nextSibling != null)
                    {
                        return _firstChild._lastSibling;
                    }

                    // no siblings, so return the first child directly
                    return _firstChild;
                }
                return null;
            }
        }

        private AbstractNode<TValue> _nextSibling;
        public INode<TValue> NextSibling
        {
            get { return _nextSibling; }
        }

        public INode<TValue> LastSibling
        {
            get { return _lastSibling; }
        }

        private AbstractNode<TValue> _lastSibling
        {
            get
            {
                AbstractNode<TValue> sibling = _nextSibling;
                if (sibling != null)
                {
                    while (sibling._nextSibling != null)
                    {
                        sibling = sibling._nextSibling;
                    }
                }
                return sibling;
            }
        }

        public void AddChild(AbstractNode<TValue> newChild)
        {
            newChild.makeSureNotAdded();

            if (_firstChild == null)
            {
                _firstChild = newChild;
            }
            else
            {
                _lastChild._nextSibling = newChild;
            }
        }

        public void AddSibling(AbstractNode<TValue> newSibling)
        {
            newSibling.makeSureNotAdded();

            if (_nextSibling != null)
            {
                newSibling._nextSibling = _nextSibling;
            }

            _nextSibling = newSibling;
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
