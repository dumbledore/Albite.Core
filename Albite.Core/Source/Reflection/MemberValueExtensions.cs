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
        /// Returns <c>MemberValue</c> of all members.
        /// Indexer properties are not supported and not present.
        /// </summary>
        /// <param name="info">
        /// A <c>TypeInfo</c> for which <c>MemberValue</c>s are to be obtained.
        /// </param>
        /// <returns>An array of <c>MemberValue</c>s for the members.</returns>
        public static IList<IMemberValue> GetMembers(this TypeInfo info)
        {
            List<IMemberValue> list = new List<IMemberValue>();

            foreach (FieldInfo member in info.DeclaredFields)
            {
                list.Add(new FieldMemberValue(member));
            }

            foreach (PropertyInfo member in info.DeclaredProperties)
            {
                // Indexer properties are not supported
                if (member.GetIndexParameters().Length == 0)
                {
                    list.Add(new PropertyMemberValue(member));
                }
            }

            return list;
        }
    }
}
