using System.Text.RegularExpressions;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// Should assertions for <see cref="IResponse"/>.
    /// </summary>
    public static class ResponseShouldExtensions
    {
        /// <summary>
        /// Asserts that the response has the specified URL.
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="regex">A regular expression to test against <see cref="IResponse.Url"/>.</param>
        /// <param name="options">A set of options for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference"/>
        public static IResponse ShouldHaveUrl(this IResponse response, string regex, RegexOptions options = RegexOptions.None, string? because = null)
        {
            if (!response.HasUrl(regex, options)) Throw.ResponseShouldHaveUrl(regex, options, response.Url, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response does not have the specified URL.
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="regex">A regular expression to test against <see cref="IResponse.Url"/>.</param>
        /// <param name="options">A set of options for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference"/>
        public static IResponse ShouldNotHaveUrl(this IResponse response, string regex, RegexOptions options = RegexOptions.None, string? because = null)
        {
            if (response.HasUrl(regex, options)) Throw.ResponseShouldNotHaveUrl(regex, options, because);

            return response;
        }
    }
}
