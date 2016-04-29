using System;
using System.Linq;
using System.Reflection;

namespace Albite.Core.Reflection
{
    /// <summary>
    /// Extensions methods for the <c>TypeInfo</c> type.
    /// </summary>
    public static class TypeInfoExtensions
    {
        private static readonly TypeInfo TypeTypeInfo = typeof(Type).GetTypeInfo();

        /// <summary>
        /// Checks if a type is of type <c>Type</c>.
        /// </summary>
        /// <param name="info">The <c>TypeInfo</c> for the type being queried.</param>
        /// <returns>
        /// <c>true</c> if <c>info</c> inherits from <c>Type</c>.
        /// Othewise <c>false</c>.
        /// </returns>
        public static bool IsType(this TypeInfo info)
        {
            return TypeTypeInfo.IsAssignableFrom(info);
        }

        /// <summary>
        /// Checks if a type implements a generic interface.
        /// </summary>
        /// <param name="info">The <c>TypeInfo</c> for the type being queried.</param>
        /// <param name="generic">The generic interface.</param>
        /// <returns>
        /// <c>true</c> if <c>info</c> implements <c>generic</c>.
        /// </returns>
        public static bool ImplementsGenericInterface(this TypeInfo info, Type generic)
        {
            return info.ImplementedInterfaces.Any(
                i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == generic);
        }
    }
}
