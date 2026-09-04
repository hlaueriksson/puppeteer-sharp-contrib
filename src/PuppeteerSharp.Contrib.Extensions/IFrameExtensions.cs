using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IFrame"/>.
    /// </summary>
    public static class IFrameExtensions
    {
        /// <summary>
        /// The method runs <c>document.querySelectorAll</c> within the iframe and then tests a <c>RegExp</c> against the elements <c>textContent</c>. The first element match is returned. If no element matches the selector and regular expression, the return value resolve to <c>null</c>.
        /// </summary>
        /// <param name="iframe">An <see cref="IFrame"/> to query.</param>
        /// <param name="selector">A selector to query iframe for.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns>Task which resolves to an <see cref="IElementHandle"/> pointing to the frame element.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<IElementHandle?> QuerySelectorWithContentAsync(this IFrame iframe, string selector, string regex, string flags = "")
        {
            return await iframe.GuardFromNull().EvaluateFunctionHandleAsync(
                @"(selector, regex, flags) => {
                    var elements = document.querySelectorAll(selector);
                    return Array.prototype.find.call(elements, function(element) {
                        return RegExp(regex, flags).test(element.textContent);
                    });
                }",
                selector,
                regex,
                flags).ConfigureAwait(false) as IElementHandle;
        }

        /// <summary>
        /// The method runs <c>document.querySelectorAll</c> within the iframe and then tests a <c>RegExp</c> against the elements <c>textContent</c>. All element matches are returned. If no element matches the selector and regular expression, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <param name="iframe">An <see cref="IFrame"/> to query.</param>
        /// <param name="selector">A selector to query iframe for.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns>Task which resolves to an <see cref="IElementHandle"/> array pointing to the frame elements.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<IElementHandle[]> QuerySelectorAllWithContentAsync(this IFrame iframe, string selector, string regex, string flags = "")
        {
            var arrayHandle = await iframe.GuardFromNull().EvaluateFunctionHandleAsync(
                @"(selector, regex, flags) => {
                    var elements = document.querySelectorAll(selector);
                    return Array.prototype.filter.call(elements, function(element) {
                        return RegExp(regex, flags).test(element.textContent);
                    });
                }",
                selector,
                regex,
                flags).ConfigureAwait(false);

            var properties = await arrayHandle.GetPropertiesAsync().ConfigureAwait(false);
            await arrayHandle.DisposeAsync().ConfigureAwait(false);

            return properties.Values.OfType<IElementHandle>().ToArray();
        }

        /// <summary>
        /// Indicates whether the iframe has the specified content or not.
        /// </summary>
        /// <param name="iframe">An <see cref="IFrame"/> to query.</param>
        /// <param name="regex">A regular expression to test against <c>document.documentElement.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the iframe has the specified content.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasContentAsync(this IFrame iframe, string regex, string flags = "")
        {
            return await iframe.GuardFromNull().EvaluateFunctionAsync<bool>("(regex, flags) => RegExp(regex, flags).test(contentDocument.documentElement.textContent)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the iframe has the specified title or not.
        /// </summary>
        /// <param name="iframe">An <see cref="IFrame"/> to query.</param>
        /// <param name="regex">A regular expression to test against <c>document.title</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the iframe has the specified title.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasTitleAsync(this IFrame iframe, string regex, string flags = "")
        {
            return await iframe.GuardFromNull().EvaluateFunctionAsync<bool>("(regex, flags) => RegExp(regex, flags).test(document.title)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the iframe has the specified URL or not.
        /// </summary>
        /// <param name="iframe">An <see cref="IFrame"/> to query.</param>
        /// <param name="regex">A regular expression to test against <c>window.location.href</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the iframe has the specified URL.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasUrlAsync(this IFrame iframe, string regex, string flags = "")
        {
            return await iframe.GuardFromNull().EvaluateFunctionAsync<bool>("(regex, flags) => RegExp(regex, flags).test(contentWindow.location.href)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits for the specific element to be removed from iframe's DOM.
        /// </summary>
        /// <param name="iframe">A <see cref="IFrame"/>.</param>
        /// <param name="selector">A selector to query iframe for.</param>
        /// <param name="timeout">Maximum time to wait for in milliseconds. Pass 0 to disable timeout. Pass null to use default timeout.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task WaitForElementsRemovedFromDOMAsync(this IFrame iframe, string selector, int? timeout = null)
        {
            var options = new WaitForFunctionOptions { Polling = WaitForFunctionPollingOption.Mutation };
            if (timeout.HasValue) options.Timeout = timeout;
            await iframe.GuardFromNull().WaitForFunctionAsync(
                string.Format(CultureInfo.InvariantCulture, "async () => document.querySelector('{0}') === null", selector),
                options)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Scrolls the frame to the top.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <param name="smooth">If true, uses smooth scrolling behavior.</param>
        /// <param name="shake">If true, scrolls down slightly and back up to trigger lazy-loaded content.</param>
        /// <param name="shakeDelayMs">Delay in ms between shake scroll-down and scroll-back-up.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ScrollToTopAsync(
            this IFrame frame,
            bool smooth = false,
            bool shake = false,
            int shakeDelayMs = 500)
        {
            var behavior = smooth ? "smooth" : "auto";

            await frame.GuardFromNull().EvaluateFunctionAsync(
                "(behavior) => window.scrollTo({ top: 0, behavior })",
                behavior).ConfigureAwait(false);

            if (shake)
            {
                await frame.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollBy({ top: 100, behavior })",
                    behavior).ConfigureAwait(false);
                await Task.Delay(shakeDelayMs).ConfigureAwait(false);
                await frame.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollTo({ top: 0, behavior })",
                    behavior).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Scrolls the frame to the bottom.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <param name="smooth">If true, uses smooth scrolling behavior.</param>
        /// <param name="shake">If true, scrolls up slightly and back down to trigger lazy-loaded content.</param>
        /// <param name="shakeDelayMs">Delay in ms between shake scroll-up and scroll-back-down.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ScrollToBottomAsync(
            this IFrame frame,
            bool smooth = false,
            bool shake = false,
            int shakeDelayMs = 500)
        {
            var behavior = smooth ? "smooth" : "auto";

            await frame.GuardFromNull().EvaluateFunctionAsync(
                "(behavior) => window.scrollTo({ top: document.body.scrollHeight, behavior })",
                behavior).ConfigureAwait(false);

            if (shake)
            {
                await frame.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollBy({ top: -100, behavior })",
                    behavior).ConfigureAwait(false);
                await Task.Delay(shakeDelayMs).ConfigureAwait(false);
                await frame.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollTo({ top: document.body.scrollHeight, behavior })",
                    behavior).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Scrolls the frame to a specific position.
        /// </summary>
        /// <param name="frame">The frame.</param>
        /// <param name="x">Horizontal position in pixels.</param>
        /// <param name="y">Vertical position in pixels.</param>
        /// <param name="smooth">If true, uses smooth scrolling behavior.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ScrollToAsync(
            this IFrame frame,
            int x,
            int y,
            bool smooth = false)
        {
            var behavior = smooth ? "smooth" : "auto";

            await frame.GuardFromNull().EvaluateFunctionAsync(
                "(x, y, behavior) => window.scrollTo({ left: x, top: y, behavior })",
                x,
                y,
                behavior).ConfigureAwait(false);
        }
    }
}
