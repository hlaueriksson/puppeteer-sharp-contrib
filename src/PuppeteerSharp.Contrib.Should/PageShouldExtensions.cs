using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// Should assertions for <see cref="Page"/>.
    /// </summary>
    public static class PageShouldExtensions
    {
        /// <summary>
        /// Asserts that the page has the specified content.
        /// </summary>
        /// <param name="page">A <see cref="Page"/>.</param>
        /// <param name="regex">A regular expression to test against <c>document.documentElement.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldHaveContentAsync(this Page page, string regex, string flags = "", string? because = null)
        {
            if (!await page.HasContentAsync(regex, flags).ConfigureAwait(false)) Throw.PageShouldHaveContent(regex, flags, because);
        }

        /// <summary>
        /// Asserts that the page does not have the specified content.
        /// </summary>
        /// <param name="page">A <see cref="Page"/>.</param>
        /// <param name="regex">A regular expression to test against <c>document.documentElement.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldNotHaveContentAsync(this Page page, string regex, string flags = "", string? because = null)
        {
            if (await page.HasContentAsync(regex, flags).ConfigureAwait(false)) Throw.PageShouldNotHaveContent(regex, flags, because);
        }

        /// <summary>
        /// Asserts that the page has the specified title.
        /// </summary>
        /// <param name="page">A <see cref="Page"/>.</param>
        /// <param name="regex">A regular expression to test against <c>document.title</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldHaveTitleAsync(this Page page, string regex, string flags = "", string? because = null)
        {
            if (!await page.HasTitleAsync(regex, flags).ConfigureAwait(false)) Throw.PageShouldHaveTitle(regex, flags, await page.GuardFromNull().GetTitleAsync().ConfigureAwait(false), because);
        }

        /// <summary>
        /// Asserts that the page does not have the specified title.
        /// </summary>
        /// <param name="page">A <see cref="Page"/>.</param>
        /// <param name="regex">A regular expression to test against <c>document.title</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldNotHaveTitleAsync(this Page page, string regex, string flags = "", string? because = null)
        {
            if (await page.HasTitleAsync(regex, flags).ConfigureAwait(false)) Throw.PageShouldNotHaveTitle(regex, flags, because);
        }
    }
}
