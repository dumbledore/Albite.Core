using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Core.Test.WindowsPhone
{
    [TestClass]
    public class EnumerableTestWP : UnitTest
    {
        private readonly EnumerableTest _test = new EnumerableTest();

        [TestMethod]
        public void ListTest()
        {
            _test.ListTest();
        }

        [TestMethod]
        public void LinkedList()
        {
            _test.LinkedList();
        }

        [TestMethod]
        public void StackTest()
        {
            _test.StackTest();
        }

        [TestMethod]
        public void QueueTest()
        {
            _test.QueueTest();
        }

        [TestMethod]
        public void HashSetTest()
        {
            _test.HashSetTest();
        }

        [TestMethod]
        public void SortedSetTest()
        {
            _test.SortedSetTest();
        }
    }
}
