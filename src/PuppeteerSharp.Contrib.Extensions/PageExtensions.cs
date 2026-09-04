using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IPage"/>.
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// The method runs <c>document.querySelectorAll</c> within the page and then tests a <c>RegExp</c> against the elements <c>textContent</c>. The first element match is returned. If no element matches the selector and regular expression, the return value resolve to <c>null</c>.
        /// </summary>
        /// <param name="page">An <see cref="IPage"/> to query.</param>
        /// <param name="selector">A selector to query page for.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns>Task which resolves to an <see cref="IElementHandle"/> pointing to the frame element.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<IElementHandle?> QuerySelectorWithContentAsync(this IPage page, string selector, string regex, string flags = "")
        {
            return await page.GuardFromNull().EvaluateFunctionHandleAsync(
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
        /// The method runs <c>document.querySelectorAll</c> within the page and then tests a <c>RegExp</c> against the elements <c>textContent</c>. All element matches are returned. If no element matches the selector and regular expression, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <param name="page">An <see cref="IPage"/> to query.</param>
        /// <param name="selector">A selector to query page for.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns>Task which resolves to an <see cref="IElementHandle"/> array pointing to the frame elements.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<IElementHandle[]> QuerySelectorAllWithContentAsync(this IPage page, string selector, string regex, string flags = "")
        {
            var arrayHandle = await page.GuardFromNull().EvaluateFunctionHandleAsync(
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

            return [.. properties.Values.OfType<IElementHandle>()];
        }

        /// <summary>
        /// Indicates whether the page has the specified content or not.
        /// </summary>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="regex">A regular expression to test against <c>document.documentElement.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the page has the specified content.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasContentAsync(this IPage page, string regex, string flags = "")
        {
            return await page.GuardFromNull().EvaluateFunctionAsync<bool>("(regex, flags) => RegExp(regex, flags).test(document.documentElement.textContent)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the page has the specified title or not.
        /// </summary>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="regex">A regular expression to test against <c>document.title</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the page has the specified title.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasTitleAsync(this IPage page, string regex, string flags = "")
        {
            return await page.GuardFromNull().EvaluateFunctionAsync<bool>("(regex, flags) => RegExp(regex, flags).test(document.title)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the page has the specified URL or not.
        /// </summary>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="regex">A regular expression to test against <c>window.location.href</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the page has the specified URL.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasUrlAsync(this IPage page, string regex, string flags = "")
        {
            return await page.GuardFromNull().EvaluateFunctionAsync<bool>("(regex, flags) => RegExp(regex, flags).test(window.location.href)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// Waits for the specific element or elements to be removed from page's DOM.
        /// </summary>
        /// <param name="page">A <see cref="IPage"/>.</param>
        /// <param name="selector">An element's selector to query page for.</param>
        /// <param name="timeout">Maximum time to wait for in milliseconds. Pass 0 to disable timeout. Pass null to use Page default timeout.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task WaitForElementsRemovedFromDOMAsync(this IPage page, string selector, int? timeout = null)
        {
            var options = new WaitForFunctionOptions { Polling = WaitForFunctionPollingOption.Mutation };
            if (timeout.HasValue) options.Timeout = timeout;
            await page.GuardFromNull().WaitForFunctionAsync(
                string.Format(CultureInfo.InvariantCulture, "async () => document.querySelector('{0}') === null", selector),
                options)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Scrolls the page to the top.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="smooth">If true, uses smooth scrolling behavior.</param>
        /// <param name="shake">If true, scrolls down slightly and back up to trigger lazy-loaded content.</param>
        /// <param name="shakeDelayMs">Delay in ms between shake scroll-down and scroll-back-up.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ScrollToTopAsync(
            this IPage page,
            bool smooth = false,
            bool shake = false,
            int shakeDelayMs = 500)
        {
            var behavior = smooth ? "smooth" : "auto";

            await page.GuardFromNull().EvaluateFunctionAsync(
                "(behavior) => window.scrollTo({ top: 0, behavior })",
                behavior).ConfigureAwait(false);

            if (shake)
            {
                await page.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollBy({ top: 100, behavior })",
                    behavior).ConfigureAwait(false);
                await Task.Delay(shakeDelayMs).ConfigureAwait(false);
                await page.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollTo({ top: 0, behavior })",
                    behavior).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Scrolls the page to the bottom.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="smooth">If true, uses smooth scrolling behavior.</param>
        /// <param name="shake">If true, scrolls up slightly and back down to trigger lazy-loaded content.</param>
        /// <param name="shakeDelayMs">Delay in ms between shake scroll-up and scroll-back-down.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ScrollToBottomAsync(
            this IPage page,
            bool smooth = false,
            bool shake = false,
            int shakeDelayMs = 500)
        {
            var behavior = smooth ? "smooth" : "auto";

            await page.GuardFromNull().EvaluateFunctionAsync(
                "(behavior) => window.scrollTo({ top: document.body.scrollHeight, behavior })",
                behavior).ConfigureAwait(false);

            if (shake)
            {
                await page.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollBy({ top: -100, behavior })",
                    behavior).ConfigureAwait(false);
                await Task.Delay(shakeDelayMs).ConfigureAwait(false);
                await page.GuardFromNull().EvaluateFunctionAsync(
                    "(behavior) => window.scrollTo({ top: document.body.scrollHeight, behavior })",
                    behavior).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Scrolls the page to a specific position.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="x">Horizontal position in pixels.</param>
        /// <param name="y">Vertical position in pixels.</param>
        /// <param name="smooth">If true, uses smooth scrolling behavior.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task ScrollToAsync(
            this IPage page,
            int x,
            int y,
            bool smooth = false)
        {
            var behavior = smooth ? "smooth" : "auto";

            await page.GuardFromNull().EvaluateFunctionAsync(
                "(x, y, behavior) => window.scrollTo({ left: x, top: y, behavior })",
                x,
                y,
                behavior).ConfigureAwait(false);
        }

        /// <summary>
        /// Intercepts a file generated in the memory of an SPA page (via Blob/Object-URL),
        /// completely blocking it from being saved to the hard disk and returning its content as a byte array.
        /// </summary>
        /// <remarks>
        /// This method is conceptually designed for modern Single Page Applications (React, Angular, Vue)
        /// that assemble files on the client side. It supports any data format: TXT, CSV, JSON, PDF, ZIP, and images.
        /// </remarks>
        /// <param name="page">An <see cref="IPage"/>.</param>
        /// <param name="clickElement">The UI element (button, link) that triggers the download.</param>
        /// <param name="timeoutMs">The maximum time to wait for the file interception in milliseconds. Default is 30000 (30 seconds).</param>
        /// <param name="pollingIntervalMs">The interval in milliseconds to check the browser's RAM for the intercepted file. Default is 100ms.</param>
        /// <returns>A byte array representing the content of the intercepted file.</returns>
        /// <exception cref="PuppeteerException">Thrown if an error occurs within the browser context while reading data.</exception>
        /// <exception cref="TimeoutException">Thrown if the file generation does not start within the allocated time.</exception>
        /// <example>
        /// <code>
        /// var downloadButton = await page.QuerySelectorAsync("#download-btn");
        /// // Intercept the file into RAM as bytes
        /// byte[] fileBytes = await page.InterceptSpaBlobDownloadAsync(downloadButton);
        /// // Save the bytes directly to your desired path (works for text, pdf, images, etc.)
        /// string targetPath = @"C:\MyFolder\output.txt";
        /// await File.WriteAllBytesAsync(targetPath, fileBytes);
        /// </code>
        /// </example>
        public static async Task<byte[]> InterceptSpaBlobDownloadAsync(
            this IPage page,
            IElementHandle clickElement,
            int timeoutMs = 30000,
            int pollingIntervalMs = 100)
        {
            ArgumentNullException.ThrowIfNull(clickElement);

            // 1. Activate the system-level disk blocker.
            // This prevents Chromium from writing files to disk, regardless of the site's tricks.
            var cdp = await page.GuardFromNull().CreateCDPSessionAsync().ConfigureAwait(false);
            await cdp.SendAsync("Browser.setDownloadBehavior", new { behavior = "deny" }).ConfigureAwait(false);

            // 2. Inject interception hooks deep into the page's JavaScript engine.
            await page.EvaluateFunctionAsync(@"() => {
                window._interceptedBase64 = null;
                window._interceptedError = null;

                if (window._blobDownloadInterceptorInstalled) return;
                window._blobDownloadInterceptorInstalled = true;

                // Helper function to asynchronously read Blob to Base64 without data corruption
                const readBlobAsBase64 = (blob) => {
                    const reader = new FileReader();
                    reader.onloadend = () => {
                        // FIX: Extract the actual Base64 string payload (the second element after the comma split)
                        const base64Parts = reader.result.split(',');
                        if (base64Parts.length > 1) {
                            window._interceptedBase64 = base64Parts[1];
                        } else {
                            window._interceptedError = 'Failed to parse Base64 from FileReader result.';
                        }
                    };
                    reader.onerror = () => {
                        window._interceptedError = 'FileReader error: ' + reader.error.message;
                    };
                    reader.readAsDataURL(blob);
                };

                // HOOK 1: Intercept the creation of dynamic object URLs in RAM
                const originalCreate = URL.createObjectURL;
                URL.createObjectURL = function(obj) {
                    if (obj instanceof Blob) {
                        readBlobAsBase64(obj);
                    }
                    return originalCreate.apply(this, arguments);
                };

                // HOOK 2: Intercept direct clicks on pre-generated Blob links as a fallback
                document.addEventListener('click', (e) => {
                    const a = e.target.closest('a');
                    if (a && (a.download || a.href.startsWith('blob:'))) {
                        // Suppress the native OS Download Manager window trigger
                        e.preventDefault();
                        e.stopPropagation();

                        if (a.href.startsWith('blob:') && !window._interceptedBase64) {
                            fetch(a.href)
                                .then(r => r.blob())
                                .then(blob => readBlobAsBase64(blob))
                                .catch(err => {
                                    window._interceptedError = 'Fetch hook error: ' + err.message;
                                });
                        }
                    }
                }, true);
            }").ConfigureAwait(false);

            // Reset the shared buffers before clicking to allow sequential multiple downloads
            await page.EvaluateFunctionAsync(@"() => {
                window._interceptedBase64 = null;
                window._interceptedError = null;
            }").ConfigureAwait(false);

            try
            {
                // 3. Trigger the UI click action
                await clickElement.ClickAsync().ConfigureAwait(false);

                // 4. Poll the page memory, waiting for the Base64 data string to arrive
                int elapsed = 0;
                while (elapsed < timeoutMs)
                {
                    var error = await page.EvaluateExpressionAsync<string>("window._interceptError").ConfigureAwait(false);
                    if (!string.IsNullOrEmpty(error))
                        throw new PuppeteerException($"Interception error within the browser context: {error}");

                    var base64Data = await page.EvaluateExpressionAsync<string>("window._interceptedBase64").ConfigureAwait(false);
                    if (base64Data != null)
                    {
                        // 5. Decode the safe Base64 string back into a standard .NET binary byte array
                        return Convert.FromBase64String(base64Data);
                    }

                    await Task.Delay(pollingIntervalMs).ConfigureAwait(false);
                    elapsed += pollingIntervalMs;
                }

                throw new TimeoutException($"File data did not appear in the page RAM within {timeoutMs}ms. Verify the click element selector.");
            }
            finally
            {
                // 6. Release the disk lock, restoring the browser session to its original state
                await cdp.DetachAsync().ConfigureAwait(false);
            }
        }
    }
}
