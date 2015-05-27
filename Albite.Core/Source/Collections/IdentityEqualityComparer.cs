using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Albite.Core.Collections
{
    public class IdentityEqualityComparer<T> : IEqualityComparer<T>
    {
        public int GetHashCode(T value)
        {
            return RuntimeHelpers.GetHashCode(value);
        }

        public bool Equals(T left, T right)
        {
            return object.ReferenceEquals(left, right);
        }
    }
}
