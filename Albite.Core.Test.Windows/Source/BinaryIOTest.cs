using System;
using Albite.Core.IO;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Albite.Core.Test.Windows
{
    [TestClass]
    public class BinaryIOTest
    {
        private enum MyEnum
        {
            Zero,
            One,
            Ten = 10,
            Eleven,
            Thousand = 1000,
        }

        [TestMethod]
        public void EnumTest()
        {
            testEnum<MyEnum>(MyEnum.Zero);
            testEnum<MyEnum>(MyEnum.One);
            testEnum<MyEnum>(MyEnum.Ten);
            testEnum<MyEnum>(MyEnum.Eleven);
        }

        [TestMethod]
        public void SmallEnumTest()
        {
            testEnum<MyEnum>(MyEnum.Zero, true);
            testEnum<MyEnum>(MyEnum.One, true);
            testEnum<MyEnum>(MyEnum.Ten, true);
            testEnum<MyEnum>(MyEnum.Eleven, true);

            // This should fail on write for even though 1000 is valid,
            // Convert.ToByte() would fail with OverflowException
            testEnumFail<OverflowException>(MyEnum.Thousand, true);
        }

        [TestMethod]
        public void EnumInvalidValueTest()
        {
            // This should fail on read for 2 is not valid
            testEnumFail<InvalidDataException>((MyEnum)2);
        }

        [TestMethod]
        public void EnumWriteBadTypeTest()
        {
            UnitTest.Assert.ThrowsException<InvalidCastException>(() =>
            {
                DateTime value = DateTime.Now;

                using (MemoryStream stream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
                    {
                        writer.WriteEnum(value);
                    }
                }
            });
        }

        [TestMethod]
        public void EnumReadBadTypeTest()
        {
            UnitTest.Assert.ThrowsException<ArgumentException>(() =>
            {
                DateTime value = DateTime.Now;

                // Write a valid enum, so that the write would work.
                // Now the read should throw
                using (MemoryStream stream = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
                    {
                        writer.WriteEnum(MyEnum.One);
                    }

                    // Rewind
                    stream.Position = 0;

                    using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
                    {
                        reader.ReadEnum<DateTime>();
                    }
                }
            });
        }

        private static void testEnum<T>(T en, bool isSmall = false) where T : IComparable, IFormattable
        {
            test<T>(en, (writer, value) =>
            {
                if (isSmall)
                {
                    writer.WriteSmallEnum(value);
                }
                else
                {
                    writer.WriteEnum(value);
                }
            }, (reader) =>
            {
                if (isSmall)
                {
                    return reader.ReadSmallEnum<T>();
                }
                else
                {
                    return reader.ReadEnum<T>();
                }
            });
        }

        private static void testEnumFail<E>(MyEnum value, bool isSmall = false) where E : Exception
        {
            UnitTest.Assert.ThrowsException<E>(() =>
            {
                testEnum<MyEnum>(value, isSmall);
            });
        }

        [TestMethod]
        public void TypeTest()
        {
            test(typeof(String));
            test(typeof(BinaryIOTest));
        }

        private void test(Type type)
        {
            test<Type>(type, (writer, value) => { writer.Write(value); }, (reader) => { return reader.ReadType(); });
        }

        [TestMethod]
        public void DateTimeTest()
        {
            test(DateTime.MinValue);
            test(DateTime.MaxValue);
            test(DateTime.Now);
            test(DateTime.UtcNow);
            test(DateTime.Today);
            test(new DateTime(DateTime.Now.Ticks, DateTimeKind.Local));
            test(new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc));
            test(new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified));
        }

        private static void test(DateTime date)
        {
            test<DateTime>(date, (writer, value) => { writer.Write(value); }, (reader) => { return reader.ReadDateTime(); });
        }

        [TestMethod]
        public void TimeSpanTest()
        {
            test(TimeSpan.Zero);
            test(new TimeSpan(-2, 0, 0));
            test(new TimeSpan(2, 0, 0));
            test(TimeSpan.MinValue);
            test(TimeSpan.MaxValue);
        }

        private static void test(TimeSpan span)
        {
            test<TimeSpan>(span, (writer, value) => { writer.Write(value); }, (reader) => { return reader.ReadTimeSpan(); });
        }

        [TestMethod]
        public void DateTimeOffsetTest()
        {
            // Use this to get the UTC offset for the current time zone.
            // Note that creating DateTimeOffset for something different than
            // the UTC (the same as TimeSpan.Zero) or the local time zone
            // (the same as DateTimeOffset.Now.Offset) would throw an exception
            DateTimeOffset localTime = DateTimeOffset.Now;

            test(DateTimeOffset.MinValue);
            test(DateTimeOffset.MaxValue);
            test(DateTimeOffset.Now);
            test(DateTimeOffset.UtcNow);
            test(new DateTimeOffset(DateTime.Now, localTime.Offset));
            test(new DateTimeOffset(DateTime.UtcNow, TimeSpan.Zero));
            test(new DateTimeOffset(new DateTime(DateTime.Now.Ticks, DateTimeKind.Local), localTime.Offset));
            test(new DateTimeOffset(new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc), TimeSpan.Zero));
            test(new DateTimeOffset(new DateTime(DateTime.Now.Ticks, DateTimeKind.Unspecified), new TimeSpan(2, 0, 0)));
        }

        private static void test(DateTimeOffset offset)
        {
            test<DateTimeOffset>(offset, (writer, value) => { writer.Write(offset); }, (reader) => { return reader.ReadDateTimeOffset(); });
        }

        [TestMethod]
        public void GuidTest()
        {
            test(Guid.Empty);
            test(new Guid(Int32.MaxValue, Int16.MaxValue, Int16.MinValue, 1, 2, 3, 4, 5, 6, Byte.MinValue, Byte.MaxValue));
        }

        private static void test(Guid guid)
        {
            test<Guid>(guid, (writer, value) => { writer.Write(guid); }, (reader) => { return reader.ReadGuid(); });
        }

        private delegate void WriterDelegate<T>(BinaryWriter writer, T value);
        private delegate T ReaderDelegate<T>(BinaryReader reader);

        private static void test<T>(T value, WriterDelegate<T> w, ReaderDelegate<T> r)
        {
            Type type = value.GetType();

            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8, true))
                {
                    Debug.WriteLine("Writing {0}: {1}", type, value);
                    w(writer, value);
                }

                // Rewind
                stream.Position = 0;

                using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8, true))
                {
                    T readValue = r(reader);
                    Debug.WriteLine("Read {0}: {1}", type, readValue);
                    Assert.AreEqual(value, readValue);
                }
            }
        }
    }
}
