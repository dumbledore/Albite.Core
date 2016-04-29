using System;
using System.Collections.Generic;

namespace Albite.Core
{
    // Note that the order of the enumeration values
    // is the same as in C# core library.

    /// <summary>
    /// Specifies the type of an object.
    /// </summary>
    public enum TypeCode
    {
        /// <summary>
        /// A null reference.
        /// </summary>
        Empty,

        /// <summary>
        /// A general type representing any reference or value type not explicitly represented
        /// by another <c>TypeCode</c>.
        /// </summary>
        Object,

        // DBNull is not supported, but it is here for compatibility reasons.

        /// <summary>
        /// A database null (column) value.
        /// </summary>
        DBNull,

        /// <summary>
        /// A simple type representing Boolean values of true or false.
        /// </summary>
        Boolean,

        /// <summary>
        /// An integral type representing unsigned 16-bit integers with values between 0 and 65535.
        /// The set of possible values for the Char type corresponds to the Unicode character set.
        /// </summary>
        Char,

        /// <summary>
        /// An integral type representing signed 8-bit integers with values between -128 and 127.
        /// </summary>
        SByte,

        /// <summary>
        /// An integral type representing unsigned 8-bit integers with values between 0 and 255.
        /// </summary>
        Byte,

        /// <summary>
        /// An integral type representing signed 16-bit integers with values between -32768 and 32767.
        /// </summary>
        Int16,

        /// <summary>
        /// An integral type representing unsigned 16-bit integers with values between 0 and 65535.
        /// </summary>
        UInt16,

        /// <summary>
        /// An integral type representing signed 32-bit integers with values between -2147483648 and 2147483647.
        /// </summary>
        Int32,

        /// <summary>
        /// An integral type representing unsigned 32-bit integers with values between 0 and 4294967295.
        /// </summary>
        UInt32,

        /// <summary>
        /// An integral type representing signed 64-bit integers with values
        /// between -9223372036854775808 and 9223372036854775807.
        /// </summary>
        Int64,

        /// <summary>
        /// An integral type representing unsigned 64-bit integers with values
        /// between 0 and 18446744073709551615.
        /// </summary>
        UInt64,

        /// <summary>
        /// A floating point type representing values ranging from approximately
        /// 1.5 x 10^-45 to 3.4 x 10^38 with a precision of 7 digits.
        /// </summary>
        Single,

        /// <summary>
        /// A floating point type representing values ranging from approximately
        /// 5.0 x 10^-324 to 1.7 x 10^308 with a precision of 15-16 digits.
        /// </summary>
        Double,

        /// <summary>
        /// A simple type representing values ranging from 1.0 x 10^-28
        /// to approximately 7.9 x 10^28 with 28-29 significant digits.
        /// </summary>
        Decimal,

        /// <summary>
        /// A type representing a date and time value.
        /// </summary>
        DateTime,

        /// <summary>
        /// A sealed class type representing Unicode character strings.
        /// </summary>
        String,

        // These are extra, i.e. not included in .NET mscorlib

        /// <summary>
        /// A type representing a point in time, typically
        /// expressed as a date and time of day, relative
        /// to Coordinated Universal Time (UTC).
        /// </summary>
        DateTimeOffset,

        /// <summary>
        /// A type representing a time interval.
        /// </summary>
        TimeSpan,

        /// <summary>
        /// A type representing a globally unique identifier (GUID).
        /// </summary>
        Guid,
    }

    /// <summary>
    /// Extensions to <c>Object</c> and <c>Type</c>,
    /// so that one can get the <c>TypeCode</c> of an object.
    /// </summary>
    public static class TypeCodeExtensions
    {
        private static readonly Dictionary<Type, TypeCode> codes = new Dictionary<Type, TypeCode>()
        {
            {typeof(Boolean), TypeCode.Boolean},
            {typeof(Char), TypeCode.Char},
            {typeof(SByte), TypeCode.SByte},
            {typeof(Byte), TypeCode.Byte},
            {typeof(Int16), TypeCode.Int16},
            {typeof(UInt16), TypeCode.UInt16},
            {typeof(Int32), TypeCode.Int32},
            {typeof(UInt32), TypeCode.UInt32},
            {typeof(Int64), TypeCode.Int64},
            {typeof(UInt64), TypeCode.UInt64},
            {typeof(Single), TypeCode.Single},
            {typeof(Double), TypeCode.Double},
            {typeof(Decimal), TypeCode.Decimal},
            {typeof(DateTime), TypeCode.DateTime},
            {typeof(String), TypeCode.String},
            {typeof(DateTimeOffset), TypeCode.DateTimeOffset},
            {typeof(TimeSpan), TypeCode.TimeSpan},
            {typeof(Guid), TypeCode.Guid},
        };

        // Note that as extensions are syntax sugar,
        // the "this" object could be null, i.e. a call
        // of this sort would not throw NullReferenceException:
        //
        //   string s = null
        //   s.GetTypeCode()

        /// <summary>
        /// Gets the underlying type code of the specified <c>Object</c>.
        /// </summary>
        /// <param name="obj">
        /// The object whose underlying type code to get.
        /// </param>
        /// <returns>
        /// The code of the underlying type, or <c>Empty</c> if <c>object</c> is <c>null</c>.
        /// </returns>
        public static TypeCode GetTypeCode(this Object obj)
        {
            if (obj == null)
            {
                return TypeCode.Empty;
            }

            return obj.GetType().GetTypeCode();
        }

        /// <summary>
        /// Gets the underlying type code of the specified Type.
        /// </summary>
        /// <param name="type">
        /// The type whose underlying type code to get.
        /// </param>
        /// <returns>
        /// The code of the underlying type, or <c>Empty</c> if <c>type</c> is <c>null</c>.
        /// </returns>
        public static TypeCode GetTypeCode(this Type type)
        {
            if (type == null)
            {
                return TypeCode.Empty;
            }
            else
            {
                TypeCode code;
                if (codes.TryGetValue(type, out code))
                {
                    return code;
                }
                else
                {
                    return TypeCode.Object;
                }
            }
        }
    }
}
