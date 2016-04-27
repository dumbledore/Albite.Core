using System.Collections;
using System.Collections.Generic;

namespace Albite.Core.Collections
{
    // Let's keep it simple, and *not* handle ICollection<>,
    // even though it does not inherit from ICollection, most
    // built-in collections (except for HashSet) extend from
    // ICollection anyway.

    /// <summary>
    /// This is pretty much a weaker version of System.Linq.Enumerable,
    /// but for non-generics, with only a few methods available.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>Returns the number of elements in a sequence.</summary>
        /// <param name="source">A sequence that contains elements to be counted.</param>
        /// <returns>The number of elements in the input sequence.</returns>
        public static int Count(this IEnumerable source)
        {
            if (source is ICollection)
            {
                return ((ICollection)source).Count;
            }
            else
            {
                int count = 0;
                foreach (var o in source)
                {
                    count++;
                }

                return count;
            }
        }

        /// <summary>Inverts the order of the elements in a sequence.</summary>
        /// <param name="source">A sequence of values to reverse.</param>
        /// <returns>
        /// A sequence whose elements correspond to those of the
        /// input sequence in reverse order
        /// </returns>
        public static IEnumerable Reverse(this IEnumerable source)
        {
            IList buffer = source.ToBuffer();

            for (int i = buffer.Count - 1; i >= 0; i--)
            {
                yield return buffer[i];
            }
        }

        /// <summary>
        /// Returns a list that might be indexed over.
        /// The actual object may be an array or a List{},
        /// depending on the actual type of the source
        /// so it might be of fixed size, or not.
        /// </summary>
        /// <param name="source">The source enumeration</param>
        /// <returns>An IList for the enumeration, so that
        /// the enumeration can be indexed.</returns>
        public static IList ToBuffer(this IEnumerable source)
        {
            if (source is ICollection)
            {
                ICollection collection = (ICollection)source;
                object[] buffer = new object[collection.Count];
                collection.CopyTo(buffer, 0);
                return buffer;
            }
            else
            {
                List<object> buffer = new List<object>();
                foreach (var o in source)
                {
                    buffer.Add(o);
                }
                return buffer;
            }
        }
    }
}
