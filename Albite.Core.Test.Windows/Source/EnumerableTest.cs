using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.Windows
{
    [TestClass]
    public class EnumerableTest : UnitTest
    {
        private readonly Test.EnumerableTest _test = new Test.EnumerableTest();

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
