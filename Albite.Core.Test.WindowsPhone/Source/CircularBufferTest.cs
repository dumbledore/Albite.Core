using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.WindowsPhone
{
    [TestClass]
    public class CircularBufferTest : UnitTest
    {
        private readonly Test.CircularBufferTest _test = new Test.CircularBufferTest();

        [TestMethod]
        public void PredefinedDataTest()
        {
            _test.PredefinedDataTest();
        }

        [TestMethod]
        public void RandomDataTest()
        {
            _test.RandomDataTest();
        }
    }
}
