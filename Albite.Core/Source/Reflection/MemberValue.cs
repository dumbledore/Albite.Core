using System;
using System.Collections.Generic;
using System.Reflection;

namespace Albite.Core.Reflection
{
    // Abstracts setting fields and properties into one.
    // Why is there a bunch of exactly the same methods/properties
    // that are however not declared in MemberInfo at all?!
    public abstract class MemberValue
    {
        public abstract object GetValue(object t);
        public abstract void SetValue(object t, object value);
        public abstract string Name { get; }
        public abstract Type MemberType { get; }
    }

    public static class MemberValueExtensions
    {
        public delegate bool FilterDelegate(Type memberType, MemberInfo info);

        /// <summary>
        /// Returns all members from a for which the filter returns true 
        /// </summary>
        public static MemberValue[] GetMembers(this TypeInfo info, FilterDelegate filter)
        {
            List<MemberValue> list = new List<MemberValue>();

            foreach (FieldInfo member in info.DeclaredFields)
            {
                if (filter(member.FieldType, member))
                {
                    list.Add(new FieldMemberValue(member));
                }
            }

            foreach (PropertyInfo member in info.DeclaredProperties)
            {
                if (filter(member.PropertyType, member))
                {
                    list.Add(new PropertyMemberValue(member));
                }
            }

            return list.ToArray();
        }
    }
}
