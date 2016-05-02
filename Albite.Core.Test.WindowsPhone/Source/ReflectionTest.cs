using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Core.Test.WindowsPhone
{
    [TestClass]
    public class ReflectionTestWP : UnitTest
    {
        private readonly ReflectionTest _test = new ReflectionTest();

        [TestMethod]
        public void VerifyTypeEquality()
        {
            _test.VerifyTypeEquality();
        }

        [TestMethod]
        public void IsType()
        {
            _test.IsType();
        }

        [TestMethod]
        public void MemberValueTest()
        {
            _test.MemberValueTest();
        }

        [TestMethod]
        public void MemberValueIndexerTest()
        {
            _test.MemberValueIndexerTest();
        }
    }
}
