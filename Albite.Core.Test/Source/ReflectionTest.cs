using Albite.Diagnostics;
using Albite.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Albite.Test
{
    public class ReflectionTest
    {
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
            Logger.LogMessage("Type {0} should {1} a type",
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

        public void MemberValueTest()
        {
            MV mv = new MV(10, 20);

            // Superfluous, but still.
            Assert.AreEqual(10, mv.Field());
            Assert.AreEqual(20, mv.Property);

            // Get all members of MV (fields + properties)
            IList<IMemberValue> members = typeof(MV).GetTypeInfo().GetMembers();

            // alter _field
            IMemberValue fieldMember = members.Single(m => m.Info.Name == "_field");
            fieldMember.SetValue(mv, 100);
            Assert.AreEqual(100, (int)fieldMember.GetValue(mv));
            Assert.AreEqual(100, mv.Field());

            // alter Property
            IMemberValue propertyMember = members.Single(m => m.Info.Name == "Property");
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

        public void MemberValueIndexerTest()
        {
            // Get all members of MVI (fields + properties)
            IList<IMemberValue> members = typeof(MVI).GetTypeInfo().GetMembers();
            Assert.AreEqual(0, members.Count);
        }
    }
}
