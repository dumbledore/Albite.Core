using System;
using System.Diagnostics;
using System.IO;

namespace Albite.Core.IO
{
    public static class BinaryWriterExtensions
    {
        public static void WriteEnum<T>(this BinaryWriter writer, T value) where T : IComparable, IFormattable
        {
            writer.WriteEnum(typeof(T), value);
        }

        public static void WriteEnum(this BinaryWriter writer, Type enumType, object value)
        {
            int intValue = Convert.ToInt32(value);

#if DEBUG
            Debug.WriteLine("WriteEnum: {0}:{1}:{2}", enumType.FullName, value, intValue);
#endif
            writer.Write(intValue);
        }

        public static void WriteSmallEnum<T>(this BinaryWriter writer, T value) where T : IComparable, IFormattable
        {
            writer.WriteSmallEnum(typeof(T), value);
        }

        private static void WriteSmallEnum(this BinaryWriter writer, Type enumType, object value)
        {
            byte byteValue = Convert.ToByte(value);

#if DEBUG
            Debug.WriteLine("WriteSmallEnum: {0}:{1}:{2}", enumType.FullName, value, byteValue);
#endif
            writer.Write(byteValue);
        }

        public static void Write(this BinaryWriter writer, Type type)
        {
            string typeName = type.AssemblyQualifiedName;

#if DEBUG
            Debug.WriteLine("Write Type: {0}", typeName);
#endif
            writer.Write(typeName);
        }

        public static void Write(this BinaryWriter writer, DateTime date)
        {
            long binaryDate = date.ToBinary();

#if DEBUG
            Debug.WriteLine("Write DateTime: {0}:{1}", date, binaryDate);
#endif
            writer.Write(binaryDate);
        }

        public static void Write(this BinaryWriter writer, TimeSpan span)
        {
            long ticks = span.Ticks;
            writer.Write(ticks);

#if DEBUG
            Debug.WriteLine("Write TimeSpan: {0}:{1}", span, ticks);
#endif
        }

        public static void Write(this BinaryWriter writer, DateTimeOffset offset)
        {
#if DEBUG
            Debug.WriteLine("Write DateTimeOffset: {0}", offset);
#endif
            writer.Write(offset.DateTime);
            writer.Write(offset.Offset);
        }

        public static void Write(this BinaryWriter writer, Guid guid)
        {
            byte[] buf = guid.ToByteArray();

#if DEBUG
            Debug.WriteLine("Write Guid: {0}:{1}", guid, BitConverter.ToString(buf));
#endif
            writer.Write(buf.Length);
            writer.Write(buf);
        }
    }
}
