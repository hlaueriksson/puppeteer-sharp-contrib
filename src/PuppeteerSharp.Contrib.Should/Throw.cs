using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PuppeteerSharp.Contrib.Should.Unsafe")]
[assembly: InternalsVisibleTo("PuppeteerSharp.Contrib.Tests")]

namespace PuppeteerSharp.Contrib.Should
{
    internal static class Throw
    {
        /* Page */

        public static void ShouldHaveContent(Page page, string message)
        {
            throw Exception("Should have content, but did not.", message);
        }

        public static void ShouldNotHaveContent(Page page, string message)
        {
            throw Exception("Should not have content, but did.", message);
        }

        public static void ShouldHaveTitle(Page page, string message)
        {
            throw Exception("Should have title, but did not.", message);
        }

        public static void ShouldNotHaveTitle(Page page, string message)
        {
            throw Exception("Should not have title, but did.", message);
        }

        /* ElementHandle */

        public static void ShouldExist(ElementHandle elementHandle, string message)
        {
            throw Exception("Should exist, but did not.", message);
        }

        public static void ShouldNotExist(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not exist, but did.", message);
        }

        public static void ShouldHaveValue(ElementHandle elementHandle, string message)
        {
            throw Exception("Should have value, but did not.", message);
        }

        public static void ShouldNotHaveValue(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not have value, but did.", message);
        }

        public static void ShouldHaveAttribute(ElementHandle elementHandle, string message)
        {
            throw Exception("Should have attribute, but did not.", message);
        }

        public static void ShouldNotHaveAttribute(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not have attribute, but did.", message);
        }

        public static void ShouldHaveContent(ElementHandle elementHandle, string message)
        {
            throw Exception("Should have content, but did not.", message);
        }

        public static void ShouldNotHaveContent(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not have content, but did.", message);
        }

        public static void ShouldHaveClass(ElementHandle elementHandle, string message)
        {
            throw Exception("Should have class, but did not.", message);
        }

        public static void ShouldNotHaveClass(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not have class, but did.", message);
        }

        public static void ShouldBeVisible(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be visible, but is not.", message);
        }

        public static void ShouldBeHidden(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be hidden, but is not.", message);
        }

        public static void ShouldBeSelected(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be selected, but is not.", message);
        }

        public static void ShouldNotBeSelected(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not be selected, but is.", message);
        }

        public static void ShouldBeChecked(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be checked, but is not.", message);
        }

        public static void ShouldNotBeChecked(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not be checked, but is.", message);
        }

        public static void ShouldBeDisabled(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be disabled, but is not.", message);
        }

        public static void ShouldBeEnabled(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be enabled, but is not.", message);
        }

        public static void ShouldBeReadOnly(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be read-only, but is not.", message);
        }

        public static void ShouldNotBeReadOnly(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not be read-only, but is.", message);
        }

        public static void ShouldBeRequired(ElementHandle elementHandle, string message)
        {
            throw Exception("Should be required, but is not.", message);
        }

        public static void ShouldNotBeRequired(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not be required, but is.", message);
        }

        public static void ShouldHaveFocus(ElementHandle elementHandle, string message)
        {
            throw Exception("Should have focus, but did not.", message);
        }

        public static void ShouldNotHaveFocus(ElementHandle elementHandle, string message)
        {
            throw Exception("Should not have focus, but did.", message);
        }

        private static ShouldException Exception(string message, string customMessage)
        {
            return new ShouldException(new ShouldMessage(message, customMessage).ToString());
        }
    }
}
