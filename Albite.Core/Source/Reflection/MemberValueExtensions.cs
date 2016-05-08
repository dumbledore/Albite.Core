using System;
using System.Collections.Generic;
using System.Reflection;

namespace Albite.Reflection
{
    /// <summary>
    /// Extension methods for <c>TypeInfo</c> that return <c>MemberValue</c>s.
    /// </summary>
    public static class MemberValueExtensions
    {
        /// <summary>
        /// A filter function used for selecting <c>MemberInfo</c>s.
        /// </summary>
        /// <param name="memberType">
        /// The <c>Type</c> of the member.
        /// Cannot use <c>MemberInfo</c> as it does not contain the type.
        /// </param>
        /// <param name="info">The <c>MemberInfo</c> being filtered</param>
        /// <returns>
        /// <c>true</c> if <c>info</c> matches the filter.
        /// </returns>
        public delegate bool FilterDelegate(Type memberType, MemberInfo info);

        /// <summary>
        /// Returns <c>MemberValue</c> for all members.
        /// </summary>
        /// <param name="info">
        /// A <c>TypeInfo</c> for which <c>MemberValue</c>s are to be obtained.
        /// </param>
        /// <returns>An array of <c>MemberValue</c>s for the members.</returns>
        public static IMemberValue[] GetMembers(this TypeInfo info)
        {
            return info.GetMembers(null);
        }

        /// <summary>
        /// Returns <c>MemberValue</c> for all members for which <c>filter</c>
        /// returns <c>true</c>.
        /// </summary>
        /// <param name="info">
        /// A <c>TypeInfo</c> for which <c>MemberValue</c>s are to be obtained.
        /// </param>
        /// <param name="filter">A filter used for selecting which members to return.</param>
        /// <returns>An array of <c>MemberValue</c>s for the filtered members.</returns>
        public static IMemberValue[] GetMembers(this TypeInfo info, FilterDelegate filter)
        {
            List<IMemberValue> list = new List<IMemberValue>();

            foreach (FieldInfo member in info.DeclaredFields)
            {
                if (filter == null || filter(member.FieldType, member))
                {
                    list.Add(new FieldMemberValue(member));
                }
            }

            foreach (PropertyInfo member in info.DeclaredProperties)
            {
                if ((member.GetIndexParameters().Length == 0) &&
                    (filter == null || filter(member.PropertyType, member)))
                {
                    list.Add(new PropertyMemberValue(member));
                }
            }

            return list.ToArray();
        }
    }
}
