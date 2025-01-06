using System;
using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <see cref="IPage"/> extension methods.
    /// </summary>
    public static class PageExtensions
    {
        // PageObject

        /// <summary>
        /// Returns a <see cref="PageObject"/> from the given <see cref="IPage"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        public static T To<T>(this IPage page)
            where T : PageObject
        {
            return ProxyFactory.PageObject<T>(page.GuardFromNull(), null);
        }

        /// <summary>
        /// Navigates to an url and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="url">URL to navigate page to. The url should include scheme, e.g. <c>https://</c>.</param>
        /// <param name="options">Navigation options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        /// <seealso cref="IPage.GoToAsync(string, NavigationOptions)"/>
        public static async Task<T> GoToAsync<T>(this IPage page, string url, NavigationOptions options)
            where T : PageObject
        {
            var response = await page.GuardFromNull().GoToAsync(url, options).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Navigates to an url and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="url">URL to navigate page to. The url should include scheme, e.g. <c>https://</c>.</param>
        /// <param name="waitUntil">When to consider navigation succeeded.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        /// <seealso cref="IPage.GoToAsync(string, WaitUntilNavigation)"/>
        public static async Task<T> GoToAsync<T>(this IPage page, string url, WaitUntilNavigation waitUntil)
            where T : PageObject
        {
            var response = await page.GuardFromNull().GoToAsync(url, waitUntil).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Navigates to an url and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="url">URL to navigate page to. The url should include scheme, e.g. <c>https://</c>.</param>
        /// <param name="timeout">Maximum navigation time in milliseconds, defaults to 30 seconds, pass <c>0</c> to disable timeout.</param>
        /// <param name="waitUntil">When to consider navigation succeeded, defaults to <see cref="WaitUntilNavigation.Load"/>. Given an array of <see cref="WaitUntilNavigation"/>, navigation is considered to be successful after all events have been fired.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        /// <seealso cref="IPage.GoToAsync(string, int?, WaitUntilNavigation[])"/>
        public static async Task<T> GoToAsync<T>(this IPage page, string url, int? timeout = null, WaitUntilNavigation[]? waitUntil = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().GoToAsync(url, timeout, waitUntil).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Reloads the page and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="options">Navigation options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.
        /// In case of multiple redirects, the navigation will resolve with the response of the last redirect.
        /// </returns>
        /// <seealso cref="IPage.ReloadAsync(NavigationOptions)"/>
        public static async Task<T> ReloadAsync<T>(this IPage page, NavigationOptions options)
            where T : PageObject
        {
            var response = await page.GuardFromNull().ReloadAsync(options).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Reloads the page and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="timeout">Maximum navigation time in milliseconds, defaults to 30 seconds, pass <c>0</c> to disable timeout. </param>
        /// <param name="waitUntil">When to consider navigation succeeded, defaults to <see cref="WaitUntilNavigation.Load"/>. Given an array of <see cref="WaitUntilNavigation"/>, navigation is considered to be successful after all events have been fired.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.
        /// In case of multiple redirects, the navigation will resolve with the response of the last redirect.
        /// </returns>
        /// <seealso cref="IPage.ReloadAsync(int?, WaitUntilNavigation[])"/>
        public static async Task<T> ReloadAsync<T>(this IPage page, int? timeout = null, WaitUntilNavigation[]? waitUntil = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().ReloadAsync(timeout, waitUntil).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Waits for navigation and returns a <see cref="PageObject"/>.
        /// This resolves when the page navigates to a new URL or reloads.
        /// It is useful for when you run code which will indirectly cause the page to navigate.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="options">Navigation options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.
        /// In case of multiple redirects, the navigation will resolve with the response of the last redirect.
        /// In case of navigation to a different anchor or navigation due to History API usage, the navigation will resolve with <c>null</c>.
        /// </returns>
        /// <seealso cref="IPage.WaitForNavigationAsync(NavigationOptions)"/>
        public static async Task<T> WaitForNavigationAsync<T>(this IPage page, NavigationOptions? options = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().WaitForNavigationAsync(options).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Waits for a response and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="url">URL to wait for.</param>
        /// <param name="options">Waiting options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        /// <seealso cref="IPage.WaitForResponseAsync(string, WaitForOptions)"/>
        public static async Task<T> WaitForResponseAsync<T>(this IPage page, string url, WaitForOptions? options = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().WaitForResponseAsync(url, options).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Waits for a response and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="predicate">Function which looks for a matching response.</param>
        /// <param name="options">Waiting options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        /// <seealso cref="IPage.WaitForResponseAsync(Func{IResponse, bool}, WaitForOptions)"/>
        public static async Task<T> WaitForResponseAsync<T>(this IPage page, Func<IResponse, bool> predicate, WaitForOptions? options = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().WaitForResponseAsync(predicate, options).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Waits for a response and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="predicate">Function which looks for a matching response.</param>
        /// <param name="options">Waiting options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.</returns>
        /// <seealso cref="IPage.WaitForResponseAsync(Func{IResponse, Task{bool}}, WaitForOptions)"/>
        public static async Task<T> WaitForResponseAsync<T>(this IPage page, Func<IResponse, Task<bool>> predicate, WaitForOptions? options = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().WaitForResponseAsync(predicate, options).ConfigureAwait(false);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Navigate to the previous page in history and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="options">Navigation options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.
        /// In case of multiple redirects, the navigation will resolve with the response of the last redirect.
        /// If can not go back, resolves to <c>null</c>.
        /// </returns>
        /// <seealso cref="IPage.GoBackAsync(NavigationOptions)"/>
        public static async Task<T?> GoBackAsync<T>(this IPage page, NavigationOptions? options = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().GoBackAsync(options).ConfigureAwait(false);

            if (response == null) return default;

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Navigate to the next page in history and returns a <see cref="PageObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="options">Navigation options.</param>
        /// <returns>Task which resolves to the <see cref="PageObject"/>.
        /// In case of multiple redirects, the navigation will resolve with the response of the last redirect.
        /// If can not go forward, resolves to <c>null</c>.
        /// </returns>
        /// <seealso cref="IPage.GoForwardAsync(NavigationOptions)"/>
        public static async Task<T?> GoForwardAsync<T>(this IPage page, NavigationOptions? options = null)
            where T : PageObject
        {
            var response = await page.GuardFromNull().GoForwardAsync(options).ConfigureAwait(false);

            if (response == null) return default;

            return ProxyFactory.PageObject<T>(page, response);
        }

        // ElementObject

        /// <summary>
        /// Runs <c>document.querySelectorAll</c> within the page and returns an <see cref="ElementObject"/> array.
        /// If no elements match the selector, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="selector">A selector to query page for.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/> array.</returns>
        /// <seealso cref="IPage.QuerySelectorAllAsync(string)"/>
        public static async Task<T[]> QuerySelectorAllAsync<T>(this IPage page, string selector)
            where T : ElementObject
        {
            var results = await page.GuardFromNull().QuerySelectorAllAsync(selector).ConfigureAwait(false);

            return results.Select(x => ProxyFactory.ElementObject<T>(page, x)).ToArray()!;
        }

        /// <summary>
        /// Runs <c>document.querySelector</c> within the page and returns an <see cref="ElementObject"/>.
        /// If no elements match the selector, the return value resolve to <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="selector">A selector to query page for.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/>.</returns>
        /// <seealso cref="IPage.QuerySelectorAsync(string)"/>
        public static async Task<T?> QuerySelectorAsync<T>(this IPage page, string selector)
            where T : ElementObject
        {
            var result = await page.GuardFromNull().QuerySelectorAsync(selector).ConfigureAwait(false);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        /// <summary>
        /// Waits for a selector to be added to the DOM and returns an <see cref="ElementObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="selector">A selector of an element to wait for.</param>
        /// <param name="options">Waiting options.</param>
        /// <returns>A task that resolves to the <see cref="ElementObject"/>, when a element specified by selector string is added to DOM.
        /// Resolves to <c>null</c> if waiting for <c>hidden: true</c> and selector is not found in DOM.
        /// </returns>
        /// <seealso cref="IPage.WaitForSelectorAsync(string, WaitForSelectorOptions)"/>
        public static async Task<T?> WaitForSelectorAsync<T>(this IPage page, string selector, WaitForSelectorOptions? options = null)
            where T : ElementObject
        {
            var result = await page.GuardFromNull().WaitForSelectorAsync(selector, options).ConfigureAwait(false);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        /// <summary>
        /// Waits for a XPath expression to be added to the DOM and returns an <see cref="ElementObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="xpath">A XPath expression of an element to wait for.</param>
        /// <param name="options">Waiting options.</param>
        /// <returns>A task that resolves to the <see cref="ElementObject"/>, when a element specified by xpath string is added to DOM.
        /// Resolves to <c>null</c> if waiting for <c>hidden: true</c> and xpath is not found in DOM.
        /// </returns>
        /// <seealso cref="IPage.WaitForXPathAsync(string, WaitForSelectorOptions)"/>
        [Obsolete("Use " + nameof(WaitForSelectorAsync) + " instead")]
        public static async Task<T?> WaitForXPathAsync<T>(this IPage page, string xpath, WaitForSelectorOptions? options = null)
            where T : ElementObject
        {
            var result = await page.GuardFromNull().WaitForXPathAsync(xpath, options).ConfigureAwait(false);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        /// <summary>
        /// Evaluates the XPath expression and returns an <see cref="ElementObject"/> array.
        /// If no elements match the expression, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject"/>.</typeparam>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="expression">Expression to evaluate <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document/evaluate"/>.</param>
        /// <returns>Task which resolves to the <see cref="ElementObject"/> array.</returns>
        /// <seealso cref="IPage.XPathAsync(string)"/>
        [Obsolete("Use " + nameof(QuerySelectorAsync) + " instead")]
        public static async Task<T[]> XPathAsync<T>(this IPage page, string expression)
            where T : ElementObject
        {
            var results = await page.GuardFromNull().XPathAsync(expression).ConfigureAwait(false);

            return results.Select(x => ProxyFactory.ElementObject<T>(page, x)).ToArray()!;
        }

        private static IPage GuardFromNull(this IPage page)
        {
            ArgumentNullException.ThrowIfNull(page);

            return page;
        }
    }
}
