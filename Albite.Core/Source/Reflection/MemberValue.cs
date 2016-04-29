using System;
using System.Collections.Generic;
using System.Reflection;

namespace Albite.Core.Reflection
{
    // Why is there a bunch of exactly the same methods/properties
    // that are however not declared in MemberInfo at all?!

    /// <summary>
    /// Abstracts setting fields and properties into one.
    /// </summary>
    public abstract class MemberValue
    {
        /// <summary>
        /// Returns the value of member.
        /// </summary>
        /// <param name="obj">The object for which the member value is being queried.</param>
        /// <returns>
        /// The value of the member of <c>obj</c>.
        /// </returns>
        public abstract object GetValue(object obj);

        /// <summary>
        /// Sets the value of the member.
        /// </summary>
        /// <param name="obj">The object for which the member value is being set</param>
        /// <param name="value">The value of the member.</param>
        public abstract void SetValue(object obj, object value);

        /// <summary>
        /// Gets the name of the current member.
        /// </summary>
        /// <returns>A <c>System.String</c> containing the name of this member.</returns>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the type of the member.
        /// <returns>The type of the member.</returns>
        /// </summary>
        public abstract Type MemberType { get; }
    }

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
        public static MemberValue[] GetMembers(this TypeInfo info)
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
        public static MemberValue[] GetMembers(this TypeInfo info, FilterDelegate filter)
        {
            List<MemberValue> list = new List<MemberValue>();

            foreach (FieldInfo member in info.DeclaredFields)
            {
                if (filter == null || filter(member.FieldType, member))
                {
                    list.Add(new FieldMemberValue(member));
                }
            }

            foreach (PropertyInfo member in info.DeclaredProperties)
            {
                if (filter == null || filter(member.PropertyType, member))
                {
                    list.Add(new PropertyMemberValue(member));
                }
            }

            return list.ToArray();
        }
    }
}
