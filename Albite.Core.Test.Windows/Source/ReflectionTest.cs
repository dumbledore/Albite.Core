using Albite.Core.Reflection;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Albite.Core.Test.Windows
{
    [TestClass]
    public class ReflectionTest
    {
        [TestMethod]
        public void VerifyTypeEquality()
        {
            object o1 = 123;
            Type type = o1.GetType();
            TypeInfo info = type.GetTypeInfo();
            Type type2 = info.AsType();

            object o2 = 567;
            Type type3 = o2.GetType();

            // Type, TypeInfo and TypeInfo.AsType() have to be the same
            Assert.AreSame(type, info);
            Assert.AreSame(type, type2);
            Assert.AreSame(type, type3);
        }

        [TestMethod]
        public void IsType()
        {
            Type type1 = typeof(Object);
            Type type2 = 123.GetType();
            testIsType(typeof(Object), false);
            testIsType(typeof(Object).GetType(), true);
            testIsType(123.GetType(), false);
            testIsType(123.GetType().GetType(), true);
        }

        private static void testIsType(Type type, bool assertTrue)
        {
            Debug.WriteLine("Type {0} should {1} a type",
                type.FullName, assertTrue ? "BE" : "NOT be");
            if (type.GetTypeInfo().IsType() != assertTrue)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
