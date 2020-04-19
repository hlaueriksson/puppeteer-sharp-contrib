using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects
{
    public static class PageExtensions
    {
        // PageObject

        public static async Task<T> GoToAsync<T>(this Page page, string url, NavigationOptions options) where T : PageObject
        {
            var response = await page.GoToAsync(url, options);

            return ProxyFactory.PageObject<T>(page, response);
        }

        public static async Task<T> GoToAsync<T>(this Page page, string url, WaitUntilNavigation waitUntil) where T : PageObject
        {
            var response = await page.GoToAsync(url, waitUntil);

            return ProxyFactory.PageObject<T>(page, response);
        }

        public static async Task<T> GoToAsync<T>(this Page page, string url, int? timeout = null, WaitUntilNavigation[] waitUntil = null) where T : PageObject
        {
            var response = await page.GoToAsync(url, timeout, waitUntil);

            return ProxyFactory.PageObject<T>(page, response);
        }

        public static async Task<T> WaitForNavigationAsync<T>(this Page page, NavigationOptions options = null) where T : PageObject
        {
            var response = await page.WaitForNavigationAsync(options);

            return ProxyFactory.PageObject<T>(page, response);
        }

        // ElementObject

        public static async Task<T[]> QuerySelectorAllAsync<T>(this Page page, string selector) where T : ElementObject
        {
            var results = await page.QuerySelectorAllAsync(selector);

            return results.Select(x => ProxyFactory.ElementObject<T>(page, x)).ToArray();
        }

        public static async Task<T> QuerySelectorAsync<T>(this Page page, string selector) where T : ElementObject
        {
            var result = await page.QuerySelectorAsync(selector);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        public static async Task<T> WaitForSelectorAsync<T>(this Page page, string selector, WaitForSelectorOptions options = null) where T : ElementObject
        {
            var result = await page.WaitForSelectorAsync(selector, options);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        public static async Task<T> WaitForXPathAsync<T>(this Page page, string xpath, WaitForSelectorOptions options = null) where T : ElementObject
        {
            var result = await page.WaitForXPathAsync(xpath, options);

            return ProxyFactory.ElementObject<T>(page, result);
        }

        public static async Task<T[]> XPathAsync<T>(this Page page, string expression) where T : ElementObject
        {
            var results = await page.XPathAsync(expression);

            return results.Select(x => ProxyFactory.ElementObject<T>(page, x)).ToArray();
        }
    }
}