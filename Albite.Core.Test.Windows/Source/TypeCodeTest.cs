using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Diagnostics;

namespace Albite.Core.Test.Windows
{
    [TestClass]
    public class TypeCodeTest
    {
        [TestMethod]
        public void TypeCodeFromNullAsObject()
        {
            Debug.WriteLine("test null object");
            test((object)null, TypeCode.Empty);
        }

        [TestMethod]
        public void TypeCodeFromNullAsType()
        {
            Debug.WriteLine("test null type");
            test((Type)null, TypeCode.Empty);
        }

        [TestMethod]
        public void TypeCodeFromObject()
        {
            Debug.WriteLine("test Object");
            test(new object(), TypeCode.Object);
        }

        [TestMethod]
        public void TypeCodeFromByte()
        {
            Debug.WriteLine("test Byte");
            byte b = 16;
            test(b, TypeCode.Byte);
        }

        [TestMethod]
        public void TypeCodeFromInt32()
        {
            Debug.WriteLine("test Int32");
            int i = 1024;
            test(i, TypeCode.Int32);
        }

        [TestMethod]
        public void TypeCodeFromString()
        {
            Debug.WriteLine("test String");
            string s = "Hello";
            test(s, TypeCode.String);
        }

        [TestMethod]
        public void TypeCodeFromType()
        {
            Debug.WriteLine("test types");
            test(typeof(Object), TypeCode.Object);
            test(typeof(Byte), TypeCode.Byte);
            test(typeof(Int32), TypeCode.Int32);
            test(typeof(String), TypeCode.String);
        }

        private static void test(object obj, TypeCode expectedCode)
        {
            printResult(obj == null ? null : obj.GetType(), obj.GetTypeCode(), expectedCode);
        }

        private static void test(Type type, TypeCode expectedCode)
        {
            printResult(type, type.GetTypeCode(), expectedCode);
        }

        private static void printResult(Type type, TypeCode code, TypeCode expectedCode)
        {
            Debug.WriteLine("Type: {0} Code: {1}", type == null ? "null" : type.Name, Enum.GetName(typeof(TypeCode), code));
            Assert.AreEqual<TypeCode>(expectedCode, code);
        }
    }
}
