using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    internal static class ReflectionExtensions
    {
        public static bool IsGetterPropertyWithAttribute<T>(this MethodInfo methodInfo)
            where T : Attribute
        {
            if (!methodInfo.IsGetter()) return false;

            var property = methodInfo.DeclaringType?.GetProperty(methodInfo);

            return property?.HasAttribute<T>() ?? false;
        }

        public static bool IsGetter(this MethodInfo methodInfo)
        {
            return methodInfo.IsSpecialName && methodInfo.IsCompilerGenerated() && methodInfo.Name.StartsWith("get_", StringComparison.OrdinalIgnoreCase);
        }

        public static bool HasAttribute<T>(this PropertyInfo propertyInfo)
            where T : Attribute
        {
            return propertyInfo.GetCustomAttributes<T>().Any();
        }

        public static T? GetAttribute<T>(this PropertyInfo propertyInfo)
            where T : Attribute
        {
            return propertyInfo.GetCustomAttribute<T>();
        }

        public static bool IsCompilerGenerated(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes<CompilerGeneratedAttribute>().Any();
        }

        public static PropertyInfo? GetProperty(this Type rootType, MethodInfo methodInfo)
        {
            return rootType.GetProperty(methodInfo.Name.Substring(4), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }

        public static bool IsReturningAsyncResult(this MethodInfo methodInfo)
        {
            return methodInfo.ReturnType.IsGenericType &&
                   methodInfo.ReturnType.GetGenericTypeDefinition() == typeof(Task<>);
        }
    }
}
