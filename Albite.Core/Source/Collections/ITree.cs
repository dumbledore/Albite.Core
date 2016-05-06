using System.Collections.Generic;

#pragma warning disable 1591
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
