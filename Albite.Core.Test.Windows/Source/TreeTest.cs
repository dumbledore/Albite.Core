using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.Windows
{
    [TestClass]
    public class TreeTest : UnitTest
    {
        private readonly Test.TreeTest _test = new Test.TreeTest();

        [TestMethod]
        public void StaticTreeTest()
        {
            _test.StaticTreeTest();
        }
    }
}
