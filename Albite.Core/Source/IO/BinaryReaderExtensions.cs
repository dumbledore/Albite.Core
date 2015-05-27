using System;
using System.Diagnostics;
using System.IO;

namespace Albite.Core.IO
{
    public static class BinaryReaderExtensions
    {
        public static T ReadEnum<T>(this BinaryReader reader) where T : IComparable, IFormattable
        {
            return (T)reader.ReadEnum(typeof(T));
        }

        public static T ReadSmallEnum<T>(this BinaryReader reader) where T : IComparable, IFormattable
        {
            return (T)reader.ReadSmallEnum(typeof(T));
        }

        public static object ReadEnum(this BinaryReader reader, Type enumType)
        {
            return ReadEnum(reader, enumType, false);
        }

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
            Debug.WriteLine("Read{3}Enum: {0}:{1}:{2}", enumType.FullName, value, intValue, isSmall ? "Small" : "");
#endif
            return value;
        }

        public static Type ReadType(this BinaryReader reader)
        {
            // Get the type name from the input stream
            string typeName = reader.ReadString();

            // Now convert the string to a real Type
            Type value = Type.GetType(typeName, true);

#if DEBUG
            Debug.WriteLine("ReadType: {0}", value.FullName);
#endif
            return value;
        }

        public static DateTime ReadDateTime(this BinaryReader reader)
        {
            long dateTime = reader.ReadInt64();
            DateTime readValue=DateTime.FromBinary(dateTime);

#if DEBUG
            Debug.WriteLine("ReadDateTime: {0}", readValue);
#endif
            return readValue;
        }

        public static TimeSpan ReadTimeSpan(this BinaryReader reader)
        {
            long span = reader.ReadInt64();
            TimeSpan value = TimeSpan.FromTicks(span);

#if DEBUG
            Debug.WriteLine("ReadTimeSpan: {0}", value);
#endif
            return value;
        }

        public static DateTimeOffset ReadDateTimeOffset(this BinaryReader reader)
        {
            DateTime date = reader.ReadDateTime();
            TimeSpan offset = reader.ReadTimeSpan();
            DateTimeOffset value = new DateTimeOffset(date, offset);

#if DEBUG
            Debug.WriteLine("ReadDateTimeOffset: {0}", value);
#endif
            return value;
        }

        public static Guid ReadGuid(this BinaryReader reader)
        {
            int size = reader.ReadInt32();
            byte[] buf = reader.ReadBytes(size);
            Guid value =new Guid(buf);

#if DEBUG
            Debug.WriteLine("ReadGuid: {0}", value);
#endif
            return value;
        }
    }
}
