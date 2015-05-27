using System;
using System.Collections.Generic;

namespace Albite.Core
{
    public enum TypeCode
    {
        Empty,
        Object,
        Boolean,
        Char,
        SByte,
        Byte,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        Single,
        Double,
        Decimal,
        DateTime,
        String,

        // These are extra, i.e. not included in .NET mscorlib
        DateTimeOffset,
        TimeSpan,
        Guid,
    }

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

        public static TypeCode GetTypeCode(this Object obj)
        {
            if (obj == null)
            {
                return TypeCode.Empty;
            }

            return obj.GetType().GetTypeCode();
        }

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
