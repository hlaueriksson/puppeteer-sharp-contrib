using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <see cref="ElementHandle"/> extension methods.
    /// </summary>
    public static class ElementHandleExtensions
    {
        /// <summary>
        /// Runs <c>element.querySelectorAll</c> within the element and returns an <see cref="ElementObject" /> array.
        /// If no elements match the selector, the return value resolve to <see cref="System.Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" />.</typeparam>
        /// <param name="elementHandle">A <see cref="ElementHandle" />.</param>
        /// <param name="selector">A selector to query element for.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject" /> array.</returns>
        /// <seealso cref="ElementHandle.QuerySelectorAllAsync(string)"/>
        public static async Task<T[]> QuerySelectorAllAsync<T>(this ElementHandle elementHandle, string selector)
            where T : ElementObject
        {
            var results = await elementHandle.GuardFromNull().QuerySelectorAllAsync(selector).ConfigureAwait(false);

            return results.Select(x => ProxyFactory.ElementObject<T>(x.GetPage(), x)).ToArray()!;
        }

        /// <summary>
        /// Runs <c>element.querySelector</c> within the element and returns an <see cref="ElementObject" />.
        /// If no elements match the selector, the return value resolve to <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" />.</typeparam>
        /// <param name="elementHandle">A <see cref="ElementHandle" />.</param>
        /// <param name="selector">A selector to query element for.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject" />.</returns>
        /// <seealso cref="ElementHandle.QuerySelectorAsync(string)"/>
        public static async Task<T?> QuerySelectorAsync<T>(this ElementHandle elementHandle, string selector)
            where T : ElementObject
        {
            var result = await elementHandle.GuardFromNull().QuerySelectorAsync(selector).ConfigureAwait(false);

            return ProxyFactory.ElementObject<T>(elementHandle.GetPage(), result);
        }

        /// <summary>
        /// Evaluates the XPath expression relative to the element and returns an <see cref="ElementObject" /> array.
        /// If no elements match the expression, the return value resolve to <see cref="System.Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" />.</typeparam>
        /// <param name="elementHandle">A <see cref="ElementHandle" />.</param>
        /// <param name="expression">Expression to evaluate <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document/evaluate" />.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject" /> array.</returns>
        /// <seealso cref="ElementHandle.XPathAsync(string)"/>
        public static async Task<T[]> XPathAsync<T>(this ElementHandle elementHandle, string expression)
            where T : ElementObject
        {
            var results = await elementHandle.GuardFromNull().XPathAsync(expression).ConfigureAwait(false);

            return results.Select(x => ProxyFactory.ElementObject<T>(x.GetPage(), x)).ToArray()!;
        }

        private static Page GetPage(this ElementHandle elementHandle)
        {
            var propertyInfo = elementHandle.GetType().GetProperty("Page", BindingFlags.NonPublic | BindingFlags.Instance);
            var methodInfo = propertyInfo.GetGetMethod(nonPublic: true);

            return (Page)methodInfo.Invoke(elementHandle, null);
        }

        private static ElementHandle GuardFromNull(this ElementHandle elementHandle)
        {
            if (elementHandle == null) throw new ArgumentNullException(nameof(elementHandle));

            return elementHandle;
        }
    }
}
