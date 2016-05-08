using System;
using System.Collections;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Albite.Core.Windows")]
[assembly: InternalsVisibleTo("Albite.Core.WindowsPhone")]

#pragma warning disable 1591
namespace Albite.Test
{
    public class CollectionAssert
    {
        internal static ICollectionAssert Current { get; set; }

        public static void AllItemsAreInstancesOfType(ICollection collection, Type expectedType)
        {
            Current.AllItemsAreInstancesOfType(collection, expectedType);
        }

        public static void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message)
        {
            Current.AllItemsAreInstancesOfType(collection, expectedType, message);
        }

        public static void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message, params object[] parameters)
        {
            Current.AllItemsAreInstancesOfType(collection, expectedType, message, parameters);
        }

        public static void AllItemsAreNotNull(ICollection collection)
        {
            Current.AllItemsAreNotNull(collection);
        }

        public static void AllItemsAreNotNull(ICollection collection, string message)
        {
            Current.AllItemsAreNotNull(collection, message);
        }

        public static void AllItemsAreNotNull(ICollection collection, string message, params object[] parameters)
        {
            Current.AllItemsAreNotNull(collection, message, parameters);
        }

        public static void AllItemsAreUnique(ICollection collection)
        {
            Current.AllItemsAreUnique(collection);
        }

        public static void AllItemsAreUnique(ICollection collection, string message)
        {
            Current.AllItemsAreUnique(collection, message);
        }

        public static void AllItemsAreUnique(ICollection collection, string message, params object[] parameters)
        {
            Current.AllItemsAreUnique(collection, message, parameters);
        }

        public static void AreEqual(ICollection expected, ICollection actual)
        {
            Current.AreEqual(expected, actual);
        }

        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer)
        {
            Current.AreEqual(expected, actual, comparer);
        }

        public static void AreEqual(ICollection expected, ICollection actual, string message)
        {
            Current.AreEqual(expected, actual, message);
        }

        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message)
        {
            Current.AreEqual(expected, actual, comparer, message);
        }

        public static void AreEqual(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, message, parameters);
        }

        public static void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters)
        {
            Current.AreEqual(expected, actual, comparer, message, parameters);
        }


        public static void AreEquivalent(ICollection expected, ICollection actual)
        {
            Current.AreEquivalent(expected, actual);
        }

        public static void AreEquivalent(ICollection expected, ICollection actual, string message)
        {
            Current.AreEquivalent(expected, actual, message);
        }

        public static void AreEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            Current.AreEquivalent(expected, actual, message, parameters);
        }

        public static void AreNotEqual(ICollection notExpected, ICollection actual)
        {
            Current.AreNotEqual(notExpected, actual);
        }

        public static void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer)
        {
            Current.AreNotEqual(notExpected, actual, comparer);
        }

        public static void AreNotEqual(ICollection notExpected, ICollection actual, string message)
        {
            Current.AreNotEqual(notExpected, actual, message);
        }

        public static void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message)
        {
            Current.AreNotEqual(notExpected, actual, comparer, message);
        }

        public static void AreNotEqual(ICollection notExpected, ICollection actual, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, actual, message, parameters);
        }

        public static void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message, params object[] parameters)
        {
            Current.AreNotEqual(notExpected, actual, comparer, message, parameters);
        }

        public static void AreNotEquivalent(ICollection expected, ICollection actual)
        {
            Current.AreNotEquivalent(expected, actual);
        }

        public static void AreNotEquivalent(ICollection expected, ICollection actual, string message)
        {
            Current.AreNotEquivalent(expected, actual, message);
        }

        public static void AreNotEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            Current.AreNotEquivalent(expected, actual, message, parameters);
        }

        public static void Contains(ICollection collection, object element)
        {
            Current.Contains(collection, element);
        }

        public static void Contains(ICollection collection, object element, string message)
        {
            Current.Contains(collection, element, message);
        }

        public static void Contains(ICollection collection, object element, string message, params object[] parameters)
        {
            Current.Contains(collection, element, message, parameters);
        }

        public static void DoesNotContain(ICollection collection, object element)
        {
            Current.DoesNotContain(collection, element);
        }

        public static void DoesNotContain(ICollection collection, object element, string message)
        {
            Current.DoesNotContain(collection, element, message);
        }

        public static void DoesNotContain(ICollection collection, object element, string message, params object[] parameters)
        {
            Current.DoesNotContain(collection, element, message, parameters);
        }

        public static void IsNotSubsetOf(ICollection subset, ICollection superset)
        {
            Current.IsNotSubsetOf(subset, superset);
        }

        public static void IsNotSubsetOf(ICollection subset, ICollection superset, string message)
        {
            Current.IsNotSubsetOf(superset, superset, message);
        }

        public static void IsNotSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
        {
            Current.IsNotSubsetOf(subset,superset,message,parameters);
        }

        public static void IsSubsetOf(ICollection subset, ICollection superset)
        {
            Current.IsSubsetOf(subset, superset);
        }

        public static void IsSubsetOf(ICollection subset, ICollection superset, string message)
        {
            Current.IsSubsetOf(subset, superset, message);
        }

        public static void IsSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
        {
            Current.IsSubsetOf(subset, superset, message, parameters);
        }
    }
}
#pragma warning restore 1591
