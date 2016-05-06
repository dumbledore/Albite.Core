﻿#pragma warning disable 1591
namespace Albite.Collections
{
    public interface INode<TValue>
    {
        INode<TValue> FirstChild { get; }

        INode<TValue> NextSibling { get; }

        TValue Value { get; }
    }
}
