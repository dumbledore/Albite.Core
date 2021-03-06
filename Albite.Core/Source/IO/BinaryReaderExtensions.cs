﻿using Albite.Diagnostics;
using System;
using System.IO;

namespace Albite.IO
{
    /// <summary>
    /// Extension methods for BinaryReader.
    /// </summary>
    public static class BinaryReaderExtensions
    {
        /// <summary>
        /// Reads a <c>System.Enum</c> of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of the <c>System.Enum</c></typeparam>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.Enum</c>.</returns>
        public static T ReadEnum<T>(this BinaryReader reader) where T : IComparable, IFormattable
        {
            return (T)reader.ReadEnum(typeof(T));
        }

        /// <summary>
        /// Reads a <c>System.Enum</c> of type <typeparamref name="T" />.
        /// It is read as a byte to save space.
        /// </summary>
        /// <typeparam name="T">The type of the <c>System.Enum</c></typeparam>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.Enum</c>.</returns>
        public static T ReadSmallEnum<T>(this BinaryReader reader) where T : IComparable, IFormattable
        {
            return (T)reader.ReadSmallEnum(typeof(T));
        }

        /// <summary>
        /// Reads a <c>System.Enum</c> of type <c>enumType</c>.
        /// </summary>
        /// <param name="enumType">The type of the <c>System.Enum</c></param>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.Enum</c>.</returns>
        public static object ReadEnum(this BinaryReader reader, Type enumType)
        {
            return ReadEnum(reader, enumType, false);
        }

        /// <summary>
        /// Reads a <c>System.Enum</c> of type <c>enumType</c>.
        /// It is read as a byte to save space.
        /// </summary>
        /// <param name="enumType">The type of the <c>System.Enum</c></param>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.Enum</c>.</returns>
        public static object ReadSmallEnum(this BinaryReader reader, Type enumType)
        {
            return ReadEnum(reader, enumType, true);
        }

        private static object ReadEnum(this BinaryReader reader, Type enumType, bool isSmall)
        {
            int intValue = isSmall ? reader.ReadByte() : reader.ReadInt32();

            if (!Enum.IsDefined(enumType, intValue))
            {
                throw new InvalidDataException("Unknown value " + intValue + " for enum " + enumType.FullName);
            }

            object value = Enum.ToObject(enumType, intValue);

#if DEBUG
            Logger.LogMessage("Read{3}Enum: {0}:{1}:{2}", enumType.FullName, value, intValue, isSmall ? "Small" : "");
#endif
            return value;
        }

        /// <summary>
        /// Reads a <c>System.Type</c>.
        /// </summary>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.Type</c>.</returns>
        public static Type ReadType(this BinaryReader reader)
        {
            // Get the type name from the input stream
            string typeName = reader.ReadString();

            // Now convert the string to a real Type
            Type value = Type.GetType(typeName, true);

#if DEBUG
            Logger.LogMessage("ReadType: {0}", value.FullName);
#endif
            return value;
        }

        /// <summary>
        /// Reads a <c>System.DateTime</c>.
        /// </summary>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.DateTime</c>.</returns>
        public static DateTime ReadDateTime(this BinaryReader reader)
        {
            long dateTime = reader.ReadInt64();
            DateTime readValue=DateTime.FromBinary(dateTime);

#if DEBUG
            Logger.LogMessage("ReadDateTime: {0}", readValue);
#endif
            return readValue;
        }

        /// <summary>
        /// Reads a <c>System.TimeSpan</c>.
        /// </summary>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.TimeSpan</c>.</returns>
        public static TimeSpan ReadTimeSpan(this BinaryReader reader)
        {
            long span = reader.ReadInt64();
            TimeSpan value = TimeSpan.FromTicks(span);

#if DEBUG
            Logger.LogMessage("ReadTimeSpan: {0}", value);
#endif
            return value;
        }

        /// <summary>
        /// Reads a <c>System.DateTimeOffset</c>.
        /// </summary>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.DateTimeOffset</c>.</returns>
        public static DateTimeOffset ReadDateTimeOffset(this BinaryReader reader)
        {
            DateTime date = reader.ReadDateTime();
            TimeSpan offset = reader.ReadTimeSpan();
            DateTimeOffset value = new DateTimeOffset(date, offset);

#if DEBUG
            Logger.LogMessage("ReadDateTimeOffset: {0}", value);
#endif
            return value;
        }

        /// <summary>
        /// Reads a <c>System.Guid</c>.
        /// </summary>
        /// <param name="reader"><c>System.IO.BinaryReader</c> used for reading the value.</param>
        /// <returns>The read <c>System.Guid</c>.</returns>
        public static Guid ReadGuid(this BinaryReader reader)
        {
            int size = reader.ReadInt32();
            byte[] buf = reader.ReadBytes(size);
            Guid value =new Guid(buf);

#if DEBUG
            Logger.LogMessage("ReadGuid: {0}", value);
#endif
            return value;
        }
    }
}
