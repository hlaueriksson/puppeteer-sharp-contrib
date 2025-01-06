using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    internal static class InvocationExtensions
    {
        public static bool HasValidReturnType(this IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;

            return typeof(Task).IsAssignableFrom(returnType) && returnType.IsGenericType;
        }

        public static bool IsGetterPropertyWithAttribute<T>(this IInvocation invocation)
            where T : Attribute
        {
            if (!invocation.Method.IsGetter()) return false;

            var property = invocation.TargetType.GetProperty(invocation.Method);

            return property?.HasAttribute<T>() ?? false;
        }

        public static T? GetAttribute<T>(this IInvocation invocation)
            where T : Attribute
        {
            var property = invocation.TargetType.GetProperty(invocation.Method);

            return property?.GetAttribute<T>();
        }

        public static bool IsReturning<T>(this IInvocation invocation)
        {
            return invocation.Method.ReturnType == typeof(Task<T>);
        }

        public static bool IsReturningElementObject(this IInvocation invocation)
        {
            return invocation.Method.ReturnType.IsGenericType &&
                   invocation.Method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>) &&
                   typeof(ElementObject).IsAssignableFrom(invocation.Method.ReturnType.GetGenericArguments()[0]);
        }

        public static bool IsReturningElementObjectArray(this IInvocation invocation)
        {
            return invocation.Method.ReturnType.IsGenericType &&
                   invocation.Method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>) &&
                   typeof(ElementObject[]).IsAssignableFrom(invocation.Method.ReturnType.GetGenericArguments()[0]);
        }

        public static async Task<object?> GetReturnValueAsync(this IInvocation invocation, PageObject pageObject, SelectorAttribute? attribute)
        {
            var page = pageObject.Page;

            if (page == null) return null;

            if (attribute == null) return null;

            if (invocation.IsReturning<IElementHandle>())
            {
                return await page.QuerySelectorAsync(attribute.Selector).ConfigureAwait(false);
            }

            if (invocation.IsReturning<IElementHandle[]>())
            {
                return await page.QuerySelectorAllAsync(attribute.Selector).ConfigureAwait(false);
            }

            if (invocation.IsReturningElementObject())
            {
                var proxyType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var elementHandle = await page.QuerySelectorAsync(attribute.Selector).ConfigureAwait(false);

                return ProxyFactory.ElementObject(proxyType, page, elementHandle);
            }

            if (invocation.IsReturningElementObjectArray())
            {
                var arrayType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var proxyType = arrayType.GetElementType();
                var elementHandles = await page.QuerySelectorAllAsync(attribute.Selector).ConfigureAwait(false);

                return ProxyFactory.ElementObjectArray(proxyType, page, elementHandles);
            }

            return null;
        }

        public static async Task<object?> GetReturnValueAsync(this IInvocation invocation, ElementObject elementObject, SelectorAttribute? attribute)
        {
            var element = elementObject.Element;

            if (element == null) return null;

            if (attribute == null) return null;

            if (invocation.IsReturning<IElementHandle>())
            {
                return await element.QuerySelectorAsync(attribute.Selector).ConfigureAwait(false);
            }

            if (invocation.IsReturning<IElementHandle[]>())
            {
                return await element.QuerySelectorAllAsync(attribute.Selector).ConfigureAwait(false);
            }

            if (invocation.IsReturningElementObject())
            {
                var proxyType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var elementHandle = await element.QuerySelectorAsync(attribute.Selector).ConfigureAwait(false);

                return ProxyFactory.ElementObject(proxyType, elementObject.Page, elementHandle);
            }

            if (invocation.IsReturningElementObjectArray())
            {
                var arrayType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var proxyType = arrayType.GetElementType();
                var elementHandles = await element.QuerySelectorAllAsync(attribute.Selector).ConfigureAwait(false);

                return ProxyFactory.ElementObjectArray(proxyType, elementObject.Page, elementHandles);
            }

            return null;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        public static async Task<object?> GetReturnValueAsync(this IInvocation invocation, PageObject pageObject, XPathAttribute? attribute)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            var page = pageObject.Page;

            if (page == null) return null;

            if (attribute == null) return null;

            if (invocation.IsReturning<IElementHandle[]>())
            {
#pragma warning disable CS0618 // Type or member is obsolete
                return await page.XPathAsync(attribute.Expression).ConfigureAwait(false);
#pragma warning restore CS0618 // Type or member is obsolete
            }

            if (invocation.IsReturningElementObjectArray())
            {
                var arrayType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var proxyType = arrayType.GetElementType();
#pragma warning disable CS0618 // Type or member is obsolete
                var elementHandles = await page.XPathAsync(attribute.Expression).ConfigureAwait(false);
#pragma warning restore CS0618 // Type or member is obsolete

                return ProxyFactory.ElementObjectArray(proxyType, page, elementHandles);
            }

            return null;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        public static async Task<object?> GetReturnValueAsync(this IInvocation invocation, ElementObject elementObject, XPathAttribute? attribute)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            var element = elementObject.Element;

            if (element == null) return null;

            if (attribute == null) return null;

            if (invocation.IsReturning<IElementHandle[]>())
            {
#pragma warning disable CS0618 // Type or member is obsolete
                return await element.XPathAsync(attribute.Expression).ConfigureAwait(false);
#pragma warning restore CS0618 // Type or member is obsolete
            }

            if (invocation.IsReturningElementObjectArray())
            {
                var arrayType = invocation.Method.ReturnType.GetGenericArguments()[0];
                var proxyType = arrayType.GetElementType();
#pragma warning disable CS0618 // Type or member is obsolete
                var elementHandles = await element.XPathAsync(attribute.Expression).ConfigureAwait(false);
#pragma warning restore CS0618 // Type or member is obsolete

                return ProxyFactory.ElementObjectArray(proxyType, elementObject.Page, elementHandles);
            }

            return null;
        }
    }
}
