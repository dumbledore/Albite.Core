using Albite.Core.Reflection;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Diagnostics;
using System.Linq;
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

            Assert.AreEqual(type.GetTypeInfo().IsType(), assertTrue);
        }

        private class MV
        {
            private readonly int _field;
            public int Field() { return _field; }
            public int Property { get; private set; }

            public MV(int f, int p)
            {
                _field = f;
                Property = p;
            }
        }

        [TestMethod]
        public void MemberValueTest()
        {
            MV mv = new MV(10, 20);

            // Superfluous, but still.
            Assert.AreEqual(10, mv.Field());
            Assert.AreEqual(20, mv.Property);

            // Get all members of MV (fields + properties)
            IMemberValue[] members = typeof(MV).GetTypeInfo().GetMembers();

            // alter _field
            IMemberValue fieldMember = members.Single(m => m.Name == "_field");
            fieldMember.SetValue(mv, 100);
            Assert.AreEqual(100, (int)fieldMember.GetValue(mv));
            Assert.AreEqual(100, mv.Field());

            // alter Property
            IMemberValue propertyMember = members.Single(m => m.Name == "Property");
            propertyMember.SetValue(mv, 200);
            Assert.AreEqual(200, (int)propertyMember.GetValue(mv));
            Assert.AreEqual(200, mv.Property);
        }

        private class MVI
        {
            public string this[int index]
            {
                get { return "Hello"; }
                set { }
            }
        }

        [TestMethod]
        public void MemberValueIndexerTest()
        {
            MVI mvi = new MVI();

            // Get all members of MVI (fields + properties)
            IMemberValue[] members = typeof(MVI).GetTypeInfo().GetMembers();
            Assert.AreEqual(0, members.Length);
        }
    }
}
