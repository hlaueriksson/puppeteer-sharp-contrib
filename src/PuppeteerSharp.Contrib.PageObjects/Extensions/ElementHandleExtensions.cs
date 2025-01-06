using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <see cref="IElementHandle"/> extension methods.
    /// </summary>
    public static class ElementHandleExtensions
    {
        /// <summary>
        /// Returns an <see cref="ElementObject"/> from the given <see cref="IElementHandle"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/>.</returns>
        public static T To<T>(this IElementHandle elementHandle)
            where T : ElementObject
        {
            return ProxyFactory.ElementObject<T>(elementHandle.GuardFromNull().GetPage(), elementHandle)!;
        }

        /// <summary>
        /// Runs <c>element.querySelectorAll</c> within the element and returns an <see cref="ElementObject"/> array.
        /// If no elements match the selector, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="selector">A selector to query element for.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/> array.</returns>
        /// <seealso cref="IElementHandle.QuerySelectorAllAsync(string)"/>
        public static async Task<T[]> QuerySelectorAllAsync<T>(this IElementHandle elementHandle, string selector)
            where T : ElementObject
        {
            var results = await elementHandle.GuardFromNull().QuerySelectorAllAsync(selector).ConfigureAwait(false);

            return results.Select(x => ProxyFactory.ElementObject<T>(x.GetPage(), x)).ToArray()!;
        }

        /// <summary>
        /// Runs <c>element.querySelector</c> within the element and returns an <see cref="ElementObject"/>.
        /// If no elements match the selector, the return value resolve to <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="selector">A selector to query element for.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/>.</returns>
        /// <seealso cref="IElementHandle.QuerySelectorAsync(string)"/>
        public static async Task<T?> QuerySelectorAsync<T>(this IElementHandle elementHandle, string selector)
            where T : ElementObject
        {
            var result = await elementHandle.GuardFromNull().QuerySelectorAsync(selector).ConfigureAwait(false);

            return ProxyFactory.ElementObject<T>(elementHandle.GetPage(), result);
        }

        /// <summary>
        /// Evaluates the XPath expression relative to the element and returns an <see cref="ElementObject"/> array.
        /// If no elements match the expression, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="expression">Expression to evaluate <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document/evaluate"/>.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/> array.</returns>
        /// <seealso cref="IElementHandle.XPathAsync(string)"/>
        [Obsolete("Use " + nameof(QuerySelectorAsync) + " instead")]
        public static async Task<T[]> XPathAsync<T>(this IElementHandle elementHandle, string expression)
            where T : ElementObject
        {
            var results = await elementHandle.GuardFromNull().XPathAsync(expression).ConfigureAwait(false);

            return results.Select(x => ProxyFactory.ElementObject<T>(x.GetPage(), x)).ToArray()!;
        }

        /// <summary>
        /// Waits for a selector to be added to the DOM and returns an <see cref="ElementObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="selector">A selector of an element to wait for.</param>
        /// <param name="options">Waiting options.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/>, when a element specified by selector string is added to DOM.
        /// Resolves to <c>null</c> if waiting for <c>hidden: true</c> and selector is not found in DOM.
        /// </returns>
        /// <seealso cref="IElementHandle.WaitForSelectorAsync(string, WaitForSelectorOptions)"/>
        public static async Task<T?> WaitForSelectorAsync<T>(this IElementHandle elementHandle, string selector, WaitForSelectorOptions? options = null)
            where T : ElementObject
        {
            var result = await elementHandle.GuardFromNull().WaitForSelectorAsync(selector, options).ConfigureAwait(false);

            return ProxyFactory.ElementObject<T>(elementHandle.GetPage(), result);
        }

        private static IPage? GetPage(this IElementHandle elementHandle)
        {
            var propertyInfo = elementHandle.GetType().GetProperty("Page", BindingFlags.NonPublic | BindingFlags.Instance);
            var methodInfo = propertyInfo?.GetGetMethod(nonPublic: true);

            return methodInfo?.Invoke(elementHandle, null) as IPage;
        }

        private static IElementHandle GuardFromNull(this IElementHandle elementHandle)
        {
            ArgumentNullException.ThrowIfNull(elementHandle);

            return elementHandle;
        }
    }
}
