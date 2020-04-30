using System;
using System.Reflection;

namespace CustomTestingFramework.Utilities
{
    public static class ReflectionHelper
    {
        public static bool HasAttribute<T>(this MemberInfo mi) where T : Attribute
        {
            var hasAttribute = mi.GetCustomAttributes<T>() != null;
            return hasAttribute;
        }
    }
}
