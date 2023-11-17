using System.Net;
using System.Text.RegularExpressions;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class Throw
    {
        /* IPage */

        public static void PageShouldHaveContent(string regex, string flags, string? because)
        {
            throw Exception($"Expected page to have content \"/{regex}/{flags}\"", "but it did not", because);
        }

        public static void PageShouldNotHaveContent(string regex, string flags, string? because)
        {
            throw Exception($"Expected page not to have content \"/{regex}/{flags}\"", null, because);
        }

        public static void PageShouldHaveTitle(string regex, string flags, string actual, string? because)
        {
            throw Exception($"Expected page to have title \"/{regex}/{flags}\"", $"but found \"{actual}\"", because);
        }

        public static void PageShouldNotHaveTitle(string regex, string flags, string? because)
        {
            throw Exception($"Expected page not to have title \"/{regex}/{flags}\"", null, because);
        }

        public static void PageShouldHaveUrl(string regex, string flags, string actual, string? because)
        {
            throw Exception($"Expected page to have URL \"/{regex}/{flags}\"", $"but found \"{actual}\"", because);
        }

        public static void PageShouldNotHaveUrl(string regex, string flags, string? because)
        {
            throw Exception($"Expected page not to have URL \"/{regex}/{flags}\"", null, because);
        }

        /* IResponse */

        public static void ResponseShouldHaveUrl(string regex, RegexOptions options, string actual, string? because)
        {
            throw Exception($"Expected response to have URL \"{regex}\" ({options})", $"but found \"{actual}\"", because);
        }

        public static void ResponseShouldNotHaveUrl(string regex, RegexOptions options, string? because)
        {
            throw Exception($"Expected response not to have URL \"{regex}\" ({options})", null, because);
        }

        public static void ResponseShouldHaveStatusCode(HttpStatusCode status, HttpStatusCode actual, string? because)
        {
            throw Exception($"Expected response to have status code \"{status}\"", $"but found \"{actual}\"", because);
        }

        public static void ResponseShouldNotHaveStatusCode(HttpStatusCode status, string? because)
        {
            throw Exception($"Expected response not to have status code \"{status}\"", null, because);
        }

        public static void ResponseShouldBeSuccessful(HttpStatusCode actual, string? because)
        {
            throw Exception("Expected response status to be successful (2xx)", $"but found \"{actual}\"", because);
        }

        public static void ResponseShouldBeRedirection(HttpStatusCode actual, string? because)
        {
            throw Exception("Expected response status to be redirection (3xx)", $"but found \"{actual}\"", because);
        }

        public static void ResponseShouldHaveClientError(HttpStatusCode actual, string? because)
        {
            throw Exception("Expected response status to be client error (4xx)", $"but found \"{actual}\"", because);
        }

        public static void ResponseShouldHaveServerError(HttpStatusCode actual, string? because)
        {
            throw Exception("Expected response status to be server error (5xx)", $"but found \"{actual}\"", because);
        }

        public static void ResponseShouldHaveError(HttpStatusCode actual, string? because)
        {
            throw Exception("Expected response status to be an error", $"but found \"{actual}\"", because);
        }

        /* IElementHandle */

        public static void ElementShouldExist(string? because)
        {
            throw Exception("Expected element to exist", "but it did not", because);
        }

        public static void ElementShouldNotExist(string? because)
        {
            throw Exception("Expected element not to exist", "but it did", because);
        }

        public static void ElementShouldHaveValue(string value, string actual, string? because)
        {
            throw Exception($"Expected element to have value \"{value}\"", $"but found \"{actual}\"", because);
        }

        public static void ElementShouldNotHaveValue(string value, string? because)
        {
            throw Exception($"Expected element not to have value \"{value}\"", null, because);
        }

        public static void ElementShouldHaveAttribute(string name, string? because)
        {
            throw Exception($"Expected element to have attribute \"{name}\"", "but it did not", because);
        }

        public static void ElementShouldNotHaveAttribute(string name, string? because)
        {
            throw Exception($"Expected element not to have attribute \"{name}\"", "but it did", because);
        }

        public static void ElementShouldHaveContent(string regex, string flags, string? because)
        {
            throw Exception($"Expected element to have content \"/{regex}/{flags}\"", "but it did not", because);
        }

        public static void ElementShouldNotHaveContent(string regex, string flags, string? because)
        {
            throw Exception($"Expected element not to have content \"/{regex}/{flags}\"", "but it did", because);
        }

        public static void ElementShouldHaveClass(string className, string? because)
        {
            throw Exception($"Expected element to have class \"{className}\"", "but it did not", because);
        }

        public static void ElementShouldNotHaveClass(string className, string? because)
        {
            throw Exception($"Expected element not to have class \"{className}\"", "but it did", because);
        }

        public static void ElementShouldBeVisible(string? because)
        {
            throw Exception("Expected element to be visible", "but it is not", because);
        }

        public static void ElementShouldBeHidden(string? because)
        {
            throw Exception("Expected element to be hidden", "but it is not", because);
        }

        public static void ElementShouldBeSelected(string? because)
        {
            throw Exception("Expected element to be selected", "but it is not", because);
        }

        public static void ElementShouldNotBeSelected(string? because)
        {
            throw Exception("Expected element not to be selected", "but it is", because);
        }

        public static void ElementShouldBeChecked(string? because)
        {
            throw Exception("Expected element to be checked", "but it is not", because);
        }

        public static void ElementShouldNotBeChecked(string? because)
        {
            throw Exception("Expected element not to be checked", "but it is", because);
        }

        public static void ElementShouldBeDisabled(string? because)
        {
            throw Exception("Expected element to be disabled", "but it is not", because);
        }

        public static void ElementShouldBeEnabled(string? because)
        {
            throw Exception("Expected element to be enabled", "but it is not", because);
        }

        public static void ElementShouldBeReadOnly(string? because)
        {
            throw Exception("Expected element to be read-only", "but it is not", because);
        }

        public static void ElementShouldNotBeReadOnly(string? because)
        {
            throw Exception("Expected element not to be read-only", "but it is", because);
        }

        public static void ElementShouldBeRequired(string? because)
        {
            throw Exception("Expected element to be required", "but it is not", because);
        }

        public static void ElementShouldNotBeRequired(string? because)
        {
            throw Exception("Expected element not to be required", "but it is", because);
        }

        public static void ElementShouldHaveFocus(string? because)
        {
            throw Exception("Expected element to have focus", "but it did not", because);
        }

        public static void ElementShouldNotHaveFocus(string? because)
        {
            throw Exception("Expected element not to have focus", "but it did", because);
        }

        private static ShouldException Exception(string expected, string? actual, string? because)
        {
            return new ShouldException(new ShouldMessage(expected, because, actual).ToString());
        }
    }
}
