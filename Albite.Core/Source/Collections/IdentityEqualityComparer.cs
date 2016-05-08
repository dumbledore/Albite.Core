using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Albite.Collections
{
    /// <summary>
    /// Compares objects by references.
    /// </summary>
    /// <typeparam name="T">
    /// The type of objects to compare.This type parameter is contravariant. That
    /// is, you can use either the type you specified or any type that is less derived.
    /// For more information about covariance and contravariance, see Covariance
    /// and Contravariance in Generics.
    /// </typeparam>
    public class IdentityEqualityComparer<T> : IEqualityComparer<T>
    {
        /// <summary>
        /// Returns a hash code for the specified object.
        /// Uses <c>RuntimeHelpers.GetHashCode()</c> to generate it.
        /// </summary>
        /// <param name="obj">
        /// The <c>System.Object</c> for which a hash code is to be returned.
        /// </param>
        /// <returns>A hash code for the specified object.</returns>
        public int GetHashCode(T obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// Uses <c>Object.ReferenceEquals()</c> to compare them.
        /// </summary>
        /// <param name="x">The first object of type T to compare.</param>
        /// <param name="y">The second object of type T to compare.</param>
        /// <returns>
        /// <c>true</c> if the specified objects are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(T x, T y)
        {
            return Object.ReferenceEquals(x, y);
        }
    }
}
