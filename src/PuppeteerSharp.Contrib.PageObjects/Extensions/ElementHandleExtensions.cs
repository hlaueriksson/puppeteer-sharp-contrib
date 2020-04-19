using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects
{
    public static class ElementHandleExtensions
    {
        public static async Task<T[]> QuerySelectorAllAsync<T>(this ElementHandle elementHandle, string selector) where T : ElementObject
        {
            var results = await elementHandle.QuerySelectorAllAsync(selector);

            return results.Select(x => ProxyFactory.ElementObject<T>(x.GetPage(), x)).ToArray();
        }

        public static async Task<T> QuerySelectorAsync<T>(this ElementHandle elementHandle, string selector) where T : ElementObject
        {
            var result = await elementHandle.QuerySelectorAsync(selector);

            return ProxyFactory.ElementObject<T>(elementHandle.GetPage(), result);
        }

        public static async Task<T[]> XPathAsync<T>(this ElementHandle elementHandle, string expression) where T : ElementObject
        {
            var results = await elementHandle.XPathAsync(expression);

            return results.Select(x => ProxyFactory.ElementObject<T>(x.GetPage(), x)).ToArray();
        }

        private static Page GetPage(this ElementHandle elementHandle)
        {
            var propertyInfo = elementHandle.GetType().GetProperty("Page", BindingFlags.NonPublic | BindingFlags.Instance);
            var methodInfo = propertyInfo?.GetGetMethod(nonPublic: true);

            return methodInfo?.Invoke(elementHandle, null) as Page;
        }
    }
}