using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <see cref="Page"/> extension methods.
    /// </summary>
    public static class PageExtensions
    {
        // PageObject

        /// <summary>
        /// Navigates to an url and returns a <see cref="PageObject" />.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="url">URL to navigate page to. The url should include scheme, e.g. https://</param>
        /// <param name="options">Navigation parameters</param>
        /// <returns>Task which resolves to the <see cref="PageObject" /></returns>
        /// <seealso cref="Page.GoToAsync(string, NavigationOptions)"/>
        public static async Task<T> GoToAsync<T>(this Page page, string url, NavigationOptions options) where T : PageObject
        {
            var response = await page.GoToAsync(url, options);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Navigates to an url and returns a <see cref="PageObject" />.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="url">URL to navigate page to. The url should include scheme, e.g. https://</param>
        /// <param name="waitUntil">When to consider navigation succeeded</param>
        /// <returns>Task which resolves to the <see cref="PageObject" /></returns>
        /// <seealso cref="Page.GoToAsync(string, WaitUntilNavigation)"/>
        public static async Task<T> GoToAsync<T>(this Page page, string url, WaitUntilNavigation waitUntil) where T : PageObject
        {
            var response = await page.GoToAsync(url, waitUntil);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Navigates to an url and returns a <see cref="PageObject" />.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="url">URL to navigate page to. The url should include scheme, e.g. https://</param>
        /// <param name="timeout">Maximum navigation time in milliseconds, defaults to 30 seconds, pass <c>0</c> to disable timeout</param>
        /// <param name="waitUntil">When to consider navigation succeeded, defaults to <see cref="WaitUntilNavigation.Load" />. Given an array of <see cref="WaitUntilNavigation" />, navigation is considered to be successful after all events have been fired.</param>
        /// <returns>Task which resolves to the <see cref="PageObject" /></returns>
        /// <seealso cref="Page.GoToAsync(string, int?, WaitUntilNavigation[])"/>
        public static async Task<T> GoToAsync<T>(this Page page, string url, int? timeout = null, WaitUntilNavigation[] waitUntil = null) where T : PageObject
        {
            var response = await page.GoToAsync(url, timeout, waitUntil);

            return ProxyFactory.PageObject<T>(page, response);
        }

        /// <summary>
        /// Waits for navigation and returns a <see cref="PageObject" />.
        /// This resolves when the page navigates to a new URL or reloads.
        /// It is useful for when you run code which will indirectly cause the page to navigate.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="PageObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="options">navigation options</param>
        /// <returns>Task which resolves to the <see cref="PageObject" />.
        /// In case of multiple redirects, the <see cref="PageObject.Response" /> is the response of the last redirect.
        /// In case of navigation to a different anchor or navigation due to History API usage, the <see cref="PageObject.Response" /> is <c>null</c>.
        /// </returns>
        /// <seealso cref="Page.WaitForNavigationAsync(NavigationOptions)"/>
        public static async Task<T> WaitForNavigationAsync<T>(this Page page, NavigationOptions options = null) where T : PageObject
        {
            var response = await page.WaitForNavigationAsync(options);

            return ProxyFactory.PageObject<T>(page, response);
        }

        // ElementObject

        /// <summary>
        /// Runs <c>document.querySelectorAll</c> within the page and returns an <see cref="ElementObject" /> array.
        /// If no elements match the selector, the return value resolve to <see cref="System.Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="selector">A selector to query page for</param>
        /// <returns>Task which resolves to the <see cref="ElementObject" /> array</returns>
        /// <seealso cref="Page.QuerySelectorAllAsync(string)"/>
        public static async Task<T[]> QuerySelectorAllAsync<T>(this Page page, string selector) where T : ElementObject
        {
            var results = await page.QuerySelectorAllAsync(selector);

            return results.Select(x => ProxyFactory.ElementObject<T>(page, x)).ToArray();
        }

        /// <summary>
        /// Runs <c>document.querySelector</c> within the page and returns an <see cref="ElementObject" />.
        /// If no elements match the selector, the return value resolve to <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="selector">A selector to query page for</param>
        /// <returns>Task which resolves to the <see cref="ElementObject" /></returns>
        /// <seealso cref="Page.QuerySelectorAsync(string)"/>
        public static async Task<T> QuerySelectorAsync<T>(this Page page, string selector) where T : ElementObject
        {
            var result = await page.QuerySelectorAsync(selector);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        /// <summary>
        /// Waits for a selector to be added to the DOM and returns an <see cref="ElementObject" />.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="selector">A selector of an element to wait for</param>
        /// <param name="options">Optional waiting parameters</param>
        /// <returns>A task that resolves to the <see cref="ElementObject" />, when a element specified by selector string is added to DOM.</returns>
        /// <seealso cref="Page.WaitForSelectorAsync(string, WaitForSelectorOptions)"/>
        public static async Task<T> WaitForSelectorAsync<T>(this Page page, string selector, WaitForSelectorOptions options = null) where T : ElementObject
        {
            var result = await page.WaitForSelectorAsync(selector, options);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        /// <summary>
        /// Waits for a XPath expression to be added to the DOM and returns an <see cref="ElementObject" />.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="xpath">A XPath expression of an element to wait for</param>
        /// <param name="options">Optional waiting parameters</param>
        /// <returns>A task that resolves to the <see cref="ElementObject" />, when a element specified by xpath string is added to DOM.</returns>
        /// <seealso cref="Page.WaitForXPathAsync(string, WaitForSelectorOptions)"/>
        public static async Task<T> WaitForXPathAsync<T>(this Page page, string xpath, WaitForSelectorOptions options = null) where T : ElementObject
        {
            var result = await page.WaitForXPathAsync(xpath, options);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        /// <summary>
        /// Evaluates the XPath expression and returns an <see cref="ElementObject" /> array.
        /// If no elements match the expression, the return value resolve to <see cref="System.Array.Empty{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="ElementObject" /></typeparam>
        /// <param name="page">A <see cref="Page" /></param>
        /// <param name="expression">Expression to evaluate <see href="https://developer.mozilla.org/en-US/docs/Web/API/Document/evaluate" /></param>
        /// <returns>Task which resolves to the <see cref="ElementObject" /> array</returns>
        /// <seealso cref="Page.XPathAsync(string)"/>
        public static async Task<T[]> XPathAsync<T>(this Page page, string expression) where T : ElementObject
        {
            var results = await page.XPathAsync(expression);

            return results.Select(x => ProxyFactory.ElementObject<T>(page, x)).ToArray();
        }
    }
}