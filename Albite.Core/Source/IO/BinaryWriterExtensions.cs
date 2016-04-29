using System;
using System.Diagnostics;
using System.IO;

namespace Albite.Core.IO
{
    /// <summary>
    /// Extension methods for BinaryWriter.
    /// </summary>
    public static class BinaryWriterExtensions
    {
        /// <summary>
        /// Writes an <c>System.Enum</c> of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of the <c>System.Enum</c></typeparam>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="value">The <c>System.Enum</c> value to write.</param>
        public static void WriteEnum<T>(this BinaryWriter writer, T value) where T : IComparable, IFormattable
        {
            writer.WriteEnum(typeof(T), value);
        }

        /// <summary>
        /// Writes an <c>System.Enum</c> of type <c>enumType</c>.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="enumType">The type of the <c>System.Enum</c></param>
        /// <param name="value">The <c>System.Enum</c> value to write.</param>
        public static void WriteEnum(this BinaryWriter writer, Type enumType, object value)
        {
            int intValue = Convert.ToInt32(value);

#if DEBUG
            Debug.WriteLine("WriteEnum: {0}:{1}:{2}", enumType.FullName, value, intValue);
#endif
            writer.Write(intValue);
        }

        /// <summary>
        /// Writes an <c>System.Enum</c> of type <typeparamref name="T" />.
        /// It is written as a byte to save space.
        /// </summary>
        /// <typeparam name="T">The type of the <c>System.Enum</c></typeparam>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="value">The <c>System.Enum</c> value to write.</param>
        /// <exception cref="System.OverflowException">
        /// <c>value</c> is either too large or too small to fit in an unsigned byte.
        /// </exception>
        public static void WriteSmallEnum<T>(this BinaryWriter writer, T value) where T : IComparable, IFormattable
        {
            writer.WriteSmallEnum(typeof(T), value);
        }

        /// <summary>
        /// Writes an <c>System.Enum</c> of type <c>enumType</c>.
        /// It is written as a byte to save space.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="enumType">The type of the <c>System.Enum</c></param>
        /// <param name="value">The <c>System.Enum</c> value to write.</param>
        /// <exception cref="System.OverflowException">
        /// <c>value</c> is either too large or too small to fit in an unsigned byte.
        /// </exception>
        private static void WriteSmallEnum(this BinaryWriter writer, Type enumType, object value)
        {
            byte byteValue = Convert.ToByte(value);

#if DEBUG
            Debug.WriteLine("WriteSmallEnum: {0}:{1}:{2}", enumType.FullName, value, byteValue);
#endif
            writer.Write(byteValue);
        }

        /// <summary>
        /// Writes a <c>System.Type</c>.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="type">The <c>System.Type</c> to write.</param>
        public static void Write(this BinaryWriter writer, Type type)
        {
            string typeName = type.AssemblyQualifiedName;

#if DEBUG
            Debug.WriteLine("Write Type: {0}", typeName);
#endif
            writer.Write(typeName);
        }

        /// <summary>
        /// Writes a <c>System.DateTime</c>.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="date">The <c>System.DateTime</c> to write.</param>
        public static void Write(this BinaryWriter writer, DateTime date)
        {
            long binaryDate = date.ToBinary();

#if DEBUG
            Debug.WriteLine("Write DateTime: {0}:{1}", date, binaryDate);
#endif
            writer.Write(binaryDate);
        }

        /// <summary>
        /// Writes a <c>System.TimeSpan</c>.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="span">The <c>System.TimeSpan</c> to write.</param>
        public static void Write(this BinaryWriter writer, TimeSpan span)
        {
            long ticks = span.Ticks;
            writer.Write(ticks);

#if DEBUG
            Debug.WriteLine("Write TimeSpan: {0}:{1}", span, ticks);
#endif
        }

        /// <summary>
        /// Writes a <c>System.DateTimeOffset</c>.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="offset">The <c>System.DateTimeOffset</c> to write.</param>
        public static void Write(this BinaryWriter writer, DateTimeOffset offset)
        {
#if DEBUG
            Debug.WriteLine("Write DateTimeOffset: {0}", offset);
#endif
            writer.Write(offset.DateTime);
            writer.Write(offset.Offset);
        }

        /// <summary>
        /// Writes a <c>System.Guid</c>.
        /// </summary>
        /// <param name="writer"><c>System.IO.BinaryWriter</c> used for writing the value.</param>
        /// <param name="guid">The <c>System.Guid</c> to write.</param>
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
