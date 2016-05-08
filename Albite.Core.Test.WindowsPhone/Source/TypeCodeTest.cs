using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Test.WindowsPhone
{
    [TestClass]
    public class TypeCodeTest : UnitTest
    {
        private readonly Test.TypeCodeTest _test = new Test.TypeCodeTest();

        [TestMethod]
        public void TypeCodeFromNullAsObject()
        {
            _test.TypeCodeFromNullAsObject();
        }

        [TestMethod]
        public void TypeCodeFromNullAsType()
        {
            _test.TypeCodeFromNullAsType();
        }

        [TestMethod]
        public void TypeCodeFromObject()
        {
            _test.TypeCodeFromObject();
        }

        [TestMethod]
        public void TypeCodeFromByte()
        {
            _test.TypeCodeFromByte();
        }

        [TestMethod]
        public void TypeCodeFromInt32()
        {
            _test.TypeCodeFromInt32();
        }

        [TestMethod]
        public void TypeCodeFromString()
        {
            _test.TypeCodeFromString();
        }

        [TestMethod]
        public void TypeCodeFromType()
        {
            _test.TypeCodeFromType();
        }
    }
}
