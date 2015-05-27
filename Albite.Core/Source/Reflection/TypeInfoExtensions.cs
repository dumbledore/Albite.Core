using System;
using System.Linq;
using System.Reflection;

namespace Albite.Core.Reflection
{
    public static class TypeInfoExtensions
    {
        private static readonly TypeInfo TypeTypeInfo = typeof(Type).GetTypeInfo();

        public static bool IsType(this TypeInfo info)
        {
            return TypeTypeInfo.IsAssignableFrom(info);
        }

        public static bool ImplementsGenericInterface(this TypeInfo info, Type generic)
        {
            return info.ImplementedInterfaces.Any(
                i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == generic);
        }
    }
}
