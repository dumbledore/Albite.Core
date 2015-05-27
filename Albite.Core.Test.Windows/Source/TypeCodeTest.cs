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
            test((object)null);
        }

        [TestMethod]
        public void TypeCodeFromNullAsType()
        {
            Debug.WriteLine("test null type");
            test((Type)null);
        }

        [TestMethod]
        public void TypeCodeFromObject()
        {
            Debug.WriteLine("test Object");
            test(new object());
        }

        [TestMethod]
        public void TypeCodeFromByte()
        {
            Debug.WriteLine("test Byte");
            byte b = 16;
            test(b);
        }

        [TestMethod]
        public void TypeCodeFromInt32()
        {
            Debug.WriteLine("test Int32");
            int i = 1024;
            test(i);
        }

        [TestMethod]
        public void TypeCodeFromString()
        {
            Debug.WriteLine("test String");
            string s = "Hello";
            test(s);
        }

        [TestMethod]
        public void TypeCodeFromType()
        {
            Debug.WriteLine("test types");
            test(typeof(Object));
            test(typeof(Byte));
            test(typeof(Int32));
            test(typeof(String));
        }

        private static void test(object obj)
        {
            printResult(obj == null ? null : obj.GetType(), obj.GetTypeCode());
        }

        private static void test(Type type)
        {
            printResult(type, type.GetTypeCode());
        }

        private static void printResult(Type type, TypeCode code)
        {
            Debug.WriteLine("Type: {0} Code: {1}", type == null ? "null" : type.Name, Enum.GetName(typeof(TypeCode), code));
        }
    }
}
