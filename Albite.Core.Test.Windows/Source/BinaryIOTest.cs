using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.Windows
{
    [TestClass]
    public class BinaryIOTest : UnitTest
    {
        private readonly Test.BinaryIOTest _test = new Test.BinaryIOTest();

        [TestMethod]
        public void EnumTest()
        {
            _test.EnumTest();
        }

        [TestMethod]
        public void SmallEnumTest()
        {
            _test.SmallEnumTest();
        }

        [TestMethod]
        public void EnumInvalidValueTest()
        {
            _test.EnumInvalidValueTest();
        }

        [TestMethod]
        public void EnumWriteBadTypeTest()
        {
            _test.EnumWriteBadTypeTest();
        }

        [TestMethod]
        public void EnumReadBadTypeTest()
        {
            _test.EnumReadBadTypeTest();
        }

        [TestMethod]
        public void TypeTest()
        {
            _test.TypeTest();
        }

        [TestMethod]
        public void DateTimeTest()
        {
            _test.DateTimeTest();
        }

        [TestMethod]
        public void TimeSpanTest()
        {
            _test.TimeSpanTest();
        }

        [TestMethod]
        public void DateTimeOffsetTest()
        {
            _test.DateTimeOffsetTest();
        }

        [TestMethod]
        public void GuidTest()
        {
            _test.GuidTest();
        }
    }
}
