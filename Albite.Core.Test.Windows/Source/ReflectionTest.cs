using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.Windows
{
    [TestClass]
    public class ReflectionTest : UnitTest
    {
        private readonly Test.ReflectionTest _test = new Test.ReflectionTest();

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
