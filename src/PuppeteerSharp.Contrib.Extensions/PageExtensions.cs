using System.Linq;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    public static class PageExtensions
    {
        public static async Task<ElementHandle> QuerySelectorWithContentAsync(this Page page, string selector, string regex)
        {
            var handle = await page.EvaluateFunctionHandleAsync(
                @"(selector, regex) => {
                    var elements = document.querySelectorAll(selector);
                    return Array.prototype.find.call(elements, function(element) {
                        return RegExp(regex).test(element.textContent);
                    });
                }", selector, regex) as ElementHandle;

            return handle;
        }

        public static async Task<ElementHandle[]> QuerySelectorAllWithContentAsync(this Page page, string selector, string regex)
        {
            // https://stackoverflow.com/a/37098508
            var arrayHandle = await page.EvaluateFunctionHandleAsync(
                @"(selector, regex) => {
                    var elements = document.querySelectorAll(selector);
                    return Array.prototype.filter.call(elements, function(element) {
                        return RegExp(regex).test(element.textContent);
                    });
                }", selector, regex);

            var properties = await arrayHandle.GetPropertiesAsync().ConfigureAwait(false);
            await arrayHandle.DisposeAsync().ConfigureAwait(false);

            return properties.Values.OfType<ElementHandle>().ToArray();
        }
    }
}