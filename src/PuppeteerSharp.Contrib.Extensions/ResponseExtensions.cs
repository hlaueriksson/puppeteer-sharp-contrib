using System.Text.RegularExpressions;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IResponse"/>.
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Indicates whether the response has the specified URL or not.
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="regex">A regular expression to test against <see cref="IResponse.Url"/>.</param>
        /// <param name="options">A set of options for the regular expression.</param>
        /// <returns><c>true</c> if the response has the specified URL.</returns>
        /// <seealso href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference"/>
        public static bool HasUrl(this IResponse response, string regex, RegexOptions options = RegexOptions.None)
        {
            return Regex.IsMatch(response.GuardFromNull().Url, regex, options);
        }
    }
}
