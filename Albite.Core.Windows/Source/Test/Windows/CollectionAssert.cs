using System;
using System.Collections;
using VSUnitTest = Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.Windows
{
    class CollectionAssert : ICollectionAssert
    {
        public static readonly ICollectionAssert Instance = new CollectionAssert();

        private CollectionAssert() { }

        public void AllItemsAreInstancesOfType(ICollection collection, Type expectedType)
        {
            VSUnitTest.CollectionAssert.AllItemsAreInstancesOfType(collection, expectedType);
        }

        public void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message)
        {
            VSUnitTest.CollectionAssert.AllItemsAreInstancesOfType(collection, expectedType, message);
        }

        public void AllItemsAreInstancesOfType(ICollection collection, Type expectedType, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AllItemsAreInstancesOfType(collection, expectedType, message, parameters);
        }

        public void AllItemsAreNotNull(ICollection collection)
        {
            VSUnitTest.CollectionAssert.AllItemsAreNotNull(collection);
        }

        public void AllItemsAreNotNull(ICollection collection, string message)
        {
            VSUnitTest.CollectionAssert.AllItemsAreNotNull(collection, message);
        }

        public void AllItemsAreNotNull(ICollection collection, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AllItemsAreNotNull(collection, message, parameters);
        }

        public void AllItemsAreUnique(ICollection collection)
        {
            VSUnitTest.CollectionAssert.AllItemsAreUnique(collection);
        }

        public void AllItemsAreUnique(ICollection collection, string message)
        {
            VSUnitTest.CollectionAssert.AllItemsAreUnique(collection, message);
        }

        public void AllItemsAreUnique(ICollection collection, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AllItemsAreUnique(collection, message, parameters);
        }

        public void AreEqual(ICollection expected, ICollection actual)
        {
            VSUnitTest.CollectionAssert.AreEqual(expected, actual);
        }

        public void AreEqual(ICollection expected, ICollection actual, IComparer comparer)
        {
            VSUnitTest.CollectionAssert.AreEqual(expected, actual, comparer);
        }

        public void AreEqual(ICollection expected, ICollection actual, string message)
        {
            VSUnitTest.CollectionAssert.AreEqual(expected, actual, message);
        }

        public void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message)
        {
            VSUnitTest.CollectionAssert.AreEqual(expected, actual, comparer, message);
        }

        public void AreEqual(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AreEqual(expected, actual, message, parameters);
        }

        public void AreEqual(ICollection expected, ICollection actual, IComparer comparer, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AreEqual(expected, actual, comparer, message, parameters);
        }


        public void AreEquivalent(ICollection expected, ICollection actual)
        {
            VSUnitTest.CollectionAssert.AreEquivalent(expected, actual);
        }

        public void AreEquivalent(ICollection expected, ICollection actual, string message)
        {
            VSUnitTest.CollectionAssert.AreEquivalent(expected, actual, message);
        }

        public void AreEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AreEquivalent(expected, actual, message, parameters);
        }

        public void AreNotEqual(ICollection notExpected, ICollection actual)
        {
            VSUnitTest.CollectionAssert.AreNotEqual(notExpected, actual);
        }

        public void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer)
        {
            VSUnitTest.CollectionAssert.AreNotEqual(notExpected, actual, comparer);
        }

        public void AreNotEqual(ICollection notExpected, ICollection actual, string message)
        {
            VSUnitTest.CollectionAssert.AreNotEqual(notExpected, actual, message);
        }

        public void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message)
        {
            VSUnitTest.CollectionAssert.AreNotEqual(notExpected, actual, comparer, message);
        }

        public void AreNotEqual(ICollection notExpected, ICollection actual, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AreNotEqual(notExpected, actual, message, parameters);
        }

        public void AreNotEqual(ICollection notExpected, ICollection actual, IComparer comparer, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AreNotEqual(notExpected, actual, comparer, message, parameters);
        }

        public void AreNotEquivalent(ICollection expected, ICollection actual)
        {
            VSUnitTest.CollectionAssert.AreNotEquivalent(expected, actual);
        }

        public void AreNotEquivalent(ICollection expected, ICollection actual, string message)
        {
            VSUnitTest.CollectionAssert.AreNotEquivalent(expected, actual, message);
        }

        public void AreNotEquivalent(ICollection expected, ICollection actual, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.AreNotEquivalent(expected, actual, message, parameters);
        }

        public void Contains(ICollection collection, object element)
        {
            VSUnitTest.CollectionAssert.Contains(collection, element);
        }

        public void Contains(ICollection collection, object element, string message)
        {
            VSUnitTest.CollectionAssert.Contains(collection, element, message);
        }

        public void Contains(ICollection collection, object element, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.Contains(collection, element, message, parameters);
        }

        public void DoesNotContain(ICollection collection, object element)
        {
            VSUnitTest.CollectionAssert.DoesNotContain(collection, element);
        }

        public void DoesNotContain(ICollection collection, object element, string message)
        {
            VSUnitTest.CollectionAssert.DoesNotContain(collection, element, message);
        }

        public void DoesNotContain(ICollection collection, object element, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.DoesNotContain(collection, element, message, parameters);
        }

        public void IsNotSubsetOf(ICollection subset, ICollection superset)
        {
            VSUnitTest.CollectionAssert.IsNotSubsetOf(subset, superset);
        }

        public void IsNotSubsetOf(ICollection subset, ICollection superset, string message)
        {
            VSUnitTest.CollectionAssert.IsNotSubsetOf(superset, superset, message);
        }

        public void IsNotSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.IsNotSubsetOf(subset,superset,message,parameters);
        }

        public void IsSubsetOf(ICollection subset, ICollection superset)
        {
            VSUnitTest.CollectionAssert.IsSubsetOf(subset, superset);
        }

        public void IsSubsetOf(ICollection subset, ICollection superset, string message)
        {
            VSUnitTest.CollectionAssert.IsSubsetOf(subset, superset, message);
        }

        public void IsSubsetOf(ICollection subset, ICollection superset, string message, params object[] parameters)
        {
            VSUnitTest.CollectionAssert.IsSubsetOf(subset, superset, message, parameters);
        }
    }
}
