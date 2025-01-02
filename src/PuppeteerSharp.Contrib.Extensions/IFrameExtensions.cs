using System;
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
                string.Format("async () => document.querySelector('{0}') === null", selector),
                options)
                .ConfigureAwait(false);
        }
    }
}
