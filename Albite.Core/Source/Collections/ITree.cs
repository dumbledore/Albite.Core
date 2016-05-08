using System.Collections.Generic;

namespace Albite.Collections
{
    public interface ITree<TValue>: IEnumerable<INode<TValue>>
    {
        INode<TValue> Root { get; }
    }

    public interface ITreeEnumerator<TValue> : IEnumerator<INode<TValue>>
    {
    }
}
