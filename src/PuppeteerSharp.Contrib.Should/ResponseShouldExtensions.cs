using System.Net;
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
            if (!response.HasUrl(regex, options)) Throw.ResponseShouldHaveUrl(regex, options, response.GuardFromNull().Url, because);

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

        /// <summary>
        /// Asserts that the response has the specified status code.
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="status">A <see cref="HttpStatusCode"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldHaveStatusCode(this IResponse response, HttpStatusCode status, string? because = null)
        {
            if (response.GuardFromNull().Status != status) Throw.ResponseShouldHaveStatusCode(status, response.GuardFromNull().Status, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response does not have the specified status code.
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="status">A <see cref="HttpStatusCode"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldNotHaveStatusCode(this IResponse response, HttpStatusCode status, string? because = null)
        {
            if (response.GuardFromNull().Status == status) Throw.ResponseShouldNotHaveStatusCode(status, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response <see cref="IResponse.Status"/> is successful (2xx).
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldBeSuccessful(this IResponse response, string? because = null)
        {
            if (!response.GuardFromNull().Ok) Throw.ResponseShouldBeSuccessful(response.GuardFromNull().Status, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response <see cref="IResponse.Status"/> is redirection (3xx).
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldBeRedirection(this IResponse response, string? because = null)
        {
            if ((int)response.GuardFromNull().Status is not (>= 300 and <= 399)) Throw.ResponseShouldBeRedirection(response.GuardFromNull().Status, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response <see cref="IResponse.Status"/> is client error (4xx).
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldHaveClientError(this IResponse response, string? because = null)
        {
            if ((int)response.GuardFromNull().Status is not (>= 400 and <= 499)) Throw.ResponseShouldHaveClientError(response.GuardFromNull().Status, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response <see cref="IResponse.Status"/> is server error (5xx).
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldHaveServerError(this IResponse response, string? because = null)
        {
            if ((int)response.GuardFromNull().Status is not (>= 500 and <= 599)) Throw.ResponseShouldHaveServerError(response.GuardFromNull().Status, because);

            return response;
        }

        /// <summary>
        /// Asserts that the response <see cref="IResponse.Status"/> is either client (4xx) or server error (5xx).
        /// </summary>
        /// <param name="response">A <see cref="IResponse"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IResponse"/> for method chaining.</returns>
        public static IResponse ShouldHaveError(this IResponse response, string? because = null)
        {
            if ((int)response.GuardFromNull().Status is not (>= 400 and <= 599)) Throw.ResponseShouldHaveError(response.GuardFromNull().Status, because);

            return response;
        }
    }
}
