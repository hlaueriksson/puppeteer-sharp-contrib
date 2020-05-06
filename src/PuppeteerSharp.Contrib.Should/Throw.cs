namespace PuppeteerSharp.Contrib.Should
{
    internal static class Throw
    {
        /* Page */

        public static void ShouldHaveContent(Page page, string regex, string message)
        {
            throw Exception($"Expected page to have content \"{regex}\"", "but it did not", message);
        }

        public static void ShouldNotHaveContent(Page page, string regex, string message)
        {
            throw Exception($"Expected page not to have content \"{regex}\"", null, message);
        }

        public static void ShouldHaveTitle(Page page, string regex, string actual, string message)
        {
            throw Exception($"Expected page to have title \"{regex}\"", $"but found \"{actual}\"", message);
        }

        public static void ShouldNotHaveTitle(Page page, string regex, string message)
        {
            throw Exception($"Expected page not to have title \"{regex}\"", null, message);
        }

        /* ElementHandle */

        public static void ShouldExist(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to exist", "but it did not", message);
        }

        public static void ShouldNotExist(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element not to exist", "but it did", message);
        }

        public static void ShouldHaveValue(ElementHandle elementHandle, string value, string actual, string message)
        {
            throw Exception($"Expected element to have value \"{value}\"", $"but found \"{actual}\"", message);
        }

        public static void ShouldNotHaveValue(ElementHandle elementHandle, string value, string message)
        {
            throw Exception($"Expected element not to have value \"{value}\"", null, message);
        }

        public static void ShouldHaveAttribute(ElementHandle elementHandle, string name, string message)
        {
            throw Exception($"Expected element to have attribute \"{name}\"", "but it did not", message);
        }

        public static void ShouldNotHaveAttribute(ElementHandle elementHandle, string name, string message)
        {
            throw Exception($"Expected element not to have attribute \"{name}\"", "but it did", message);
        }

        public static void ShouldHaveContent(ElementHandle elementHandle, string content, string message)
        {
            throw Exception($"Expected element to have content \"{content}\"", "but it did not", message);
        }

        public static void ShouldNotHaveContent(ElementHandle elementHandle, string content, string message)
        {
            throw Exception($"Expected element not to have content \"{content}\"", "but it did", message);
        }

        public static void ShouldHaveClass(ElementHandle elementHandle, string className, string message)
        {
            throw Exception($"Expected element to have class \"{className}\"", "but it did not", message);
        }

        public static void ShouldNotHaveClass(ElementHandle elementHandle, string className, string message)
        {
            throw Exception($"Expected element not to have class \"{className}\"", "but it did", message);
        }

        public static void ShouldBeVisible(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be visible", "but it is not", message);
        }

        public static void ShouldBeHidden(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be hidden", "but it is not", message);
        }

        public static void ShouldBeSelected(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be selected", "but it is not", message);
        }

        public static void ShouldNotBeSelected(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element not to be selected", "but it is", message);
        }

        public static void ShouldBeChecked(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be checked", "but it is not", message);
        }

        public static void ShouldNotBeChecked(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element not to be checked", "but it is", message);
        }

        public static void ShouldBeDisabled(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be disabled", "but it is not", message);
        }

        public static void ShouldBeEnabled(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be enabled", "but it is not", message);
        }

        public static void ShouldBeReadOnly(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be read-only", "but it is not", message);
        }

        public static void ShouldNotBeReadOnly(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element not to be read-only", "but it is", message);
        }

        public static void ShouldBeRequired(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to be required", "but it is not", message);
        }

        public static void ShouldNotBeRequired(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element not to be required", "but it is", message);
        }

        public static void ShouldHaveFocus(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element to have focus", "but it did not", message);
        }

        public static void ShouldNotHaveFocus(ElementHandle elementHandle, string message)
        {
            throw Exception("Expected element not to have focus", "but it did", message);
        }

        private static ShouldException Exception(string expected, string actual, string because)
        {
            return new ShouldException(new ShouldMessage(expected, because, actual).ToString());
        }
    }
}
