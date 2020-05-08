namespace PuppeteerSharp.Contrib.Should
{
    internal static class Throw
    {
        /* Page */

        public static void ShouldHaveContent(Page page, string regex, string because)
        {
            throw Exception($"Expected page to have content \"{regex}\"", "but it did not", because);
        }

        public static void ShouldNotHaveContent(Page page, string regex, string because)
        {
            throw Exception($"Expected page not to have content \"{regex}\"", null, because);
        }

        public static void ShouldHaveTitle(Page page, string regex, string actual, string because)
        {
            throw Exception($"Expected page to have title \"{regex}\"", $"but found \"{actual}\"", because);
        }

        public static void ShouldNotHaveTitle(Page page, string regex, string because)
        {
            throw Exception($"Expected page not to have title \"{regex}\"", null, because);
        }

        /* ElementHandle */

        public static void ShouldExist(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to exist", "but it did not", because);
        }

        public static void ShouldNotExist(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element not to exist", "but it did", because);
        }

        public static void ShouldHaveValue(ElementHandle elementHandle, string value, string actual, string because)
        {
            throw Exception($"Expected element to have value \"{value}\"", $"but found \"{actual}\"", because);
        }

        public static void ShouldNotHaveValue(ElementHandle elementHandle, string value, string because)
        {
            throw Exception($"Expected element not to have value \"{value}\"", null, because);
        }

        public static void ShouldHaveAttribute(ElementHandle elementHandle, string name, string because)
        {
            throw Exception($"Expected element to have attribute \"{name}\"", "but it did not", because);
        }

        public static void ShouldNotHaveAttribute(ElementHandle elementHandle, string name, string because)
        {
            throw Exception($"Expected element not to have attribute \"{name}\"", "but it did", because);
        }

        public static void ShouldHaveContent(ElementHandle elementHandle, string content, string because)
        {
            throw Exception($"Expected element to have content \"{content}\"", "but it did not", because);
        }

        public static void ShouldNotHaveContent(ElementHandle elementHandle, string content, string because)
        {
            throw Exception($"Expected element not to have content \"{content}\"", "but it did", because);
        }

        public static void ShouldHaveClass(ElementHandle elementHandle, string className, string because)
        {
            throw Exception($"Expected element to have class \"{className}\"", "but it did not", because);
        }

        public static void ShouldNotHaveClass(ElementHandle elementHandle, string className, string because)
        {
            throw Exception($"Expected element not to have class \"{className}\"", "but it did", because);
        }

        public static void ShouldBeVisible(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be visible", "but it is not", because);
        }

        public static void ShouldBeHidden(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be hidden", "but it is not", because);
        }

        public static void ShouldBeSelected(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be selected", "but it is not", because);
        }

        public static void ShouldNotBeSelected(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element not to be selected", "but it is", because);
        }

        public static void ShouldBeChecked(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be checked", "but it is not", because);
        }

        public static void ShouldNotBeChecked(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element not to be checked", "but it is", because);
        }

        public static void ShouldBeDisabled(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be disabled", "but it is not", because);
        }

        public static void ShouldBeEnabled(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be enabled", "but it is not", because);
        }

        public static void ShouldBeReadOnly(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be read-only", "but it is not", because);
        }

        public static void ShouldNotBeReadOnly(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element not to be read-only", "but it is", because);
        }

        public static void ShouldBeRequired(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to be required", "but it is not", because);
        }

        public static void ShouldNotBeRequired(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element not to be required", "but it is", because);
        }

        public static void ShouldHaveFocus(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element to have focus", "but it did not", because);
        }

        public static void ShouldNotHaveFocus(ElementHandle elementHandle, string because)
        {
            throw Exception("Expected element not to have focus", "but it did", because);
        }

        private static ShouldException Exception(string expected, string actual, string because)
        {
            return new ShouldException(new ShouldMessage(expected, because, actual).ToString());
        }
    }
}
