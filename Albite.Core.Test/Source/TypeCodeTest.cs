using Albite.Core.Diagnostics;
using System;

namespace Albite.Core.Test
{
    public class TypeCodeTest
    {
        public void TypeCodeFromNullAsObject()
        {
            Logger.LogMessage("test null object");
            test((object)null, TypeCode.Empty);
        }

        public void TypeCodeFromNullAsType()
        {
            Logger.LogMessage("test null type");
            test((Type)null, TypeCode.Empty);
        }

        public void TypeCodeFromObject()
        {
            Logger.LogMessage("test Object");
            test(new object(), TypeCode.Object);
        }

        public void TypeCodeFromByte()
        {
            Logger.LogMessage("test Byte");
            byte b = 16;
            test(b, TypeCode.Byte);
        }

        public void TypeCodeFromInt32()
        {
            Logger.LogMessage("test Int32");
            int i = 1024;
            test(i, TypeCode.Int32);
        }

        public void TypeCodeFromString()
        {
            Logger.LogMessage("test String");
            string s = "Hello";
            test(s, TypeCode.String);
        }

        public void TypeCodeFromType()
        {
            Logger.LogMessage("test types");
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
            Logger.LogMessage("Type: {0} Code: {1}", type == null ? "null" : type.Name, Enum.GetName(typeof(TypeCode), code));
            Assert.AreEqual<TypeCode>(expectedCode, code);
        }
    }
}
