using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class Throw
    {
        /* Page */

        public static void ShouldHaveContent(Page page, string message)
        {
            Exception("Should have content, but did not.", message);
        }

        public static void ShouldNotHaveContent(Page page, string message)
        {
            Exception("Should not have content, but did.", message);
        }

        public static void ShouldHaveTitle(Page page, string message)
        {
            Exception("Should have title, but did not.", message);
        }

        public static void ShouldNotHaveTitle(Page page, string message)
        {
            Exception("Should not have title, but did.", message);
        }

        /* ElementHandle */

        public static void ShouldExist(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldExist(elementHandleTask.Result(), message);
        }

        public static void ShouldExist(ElementHandle elementHandle, string message)
        {
            Exception("Should exist, but did not.", message);
        }

        public static void ShouldNotExist(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotExist(elementHandleTask.Result(), message);
        }

        public static void ShouldNotExist(ElementHandle elementHandle, string message)
        {
            Exception("Should not exist, but did.", message);
        }

        public static void ShouldHaveValue(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldHaveValue(elementHandleTask.Result(), message);
        }

        public static void ShouldHaveValue(ElementHandle elementHandle, string message)
        {
            Exception("Should have value, but did not.", message);
        }

        public static void ShouldNotHaveValue(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotHaveValue(elementHandleTask.Result(), message);
        }

        public static void ShouldNotHaveValue(ElementHandle elementHandle, string message)
        {
            Exception("Should not have value, but did.", message);
        }

        public static void ShouldHaveAttribute(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldHaveAttribute(elementHandleTask.Result(), message);
        }

        public static void ShouldHaveAttribute(ElementHandle elementHandle, string message)
        {
            Exception("Should have attribute, but did not.", message);
        }

        public static void ShouldNotHaveAttribute(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotHaveAttribute(elementHandleTask.Result(), message);
        }

        public static void ShouldNotHaveAttribute(ElementHandle elementHandle, string message)
        {
            Exception("Should not have attribute, but did.", message);
        }

        public static void ShouldHaveContent(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldHaveContent(elementHandleTask.Result(), message);
        }

        public static void ShouldHaveContent(ElementHandle elementHandle, string message)
        {
            Exception("Should have content, but did not.", message);
        }

        public static void ShouldNotHaveContent(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotHaveContent(elementHandleTask.Result(), message);
        }

        public static void ShouldNotHaveContent(ElementHandle elementHandle, string message)
        {
            Exception("Should not have content, but did.", message);
        }

        public static void ShouldHaveClass(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldHaveClass(elementHandleTask.Result(), message);
        }

        public static void ShouldHaveClass(ElementHandle elementHandle, string message)
        {
            Exception("Should have class, but did not.", message);
        }

        public static void ShouldNotHaveClass(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotHaveClass(elementHandleTask.Result(), message);
        }

        public static void ShouldNotHaveClass(ElementHandle elementHandle, string message)
        {
            Exception("Should not have class, but did.", message);
        }

        public static void ShouldBeVisible(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeVisible(elementHandleTask.Result(), message);
        }

        public static void ShouldBeVisible(ElementHandle elementHandle, string message)
        {
            Exception("Should be visible, but is not.", message);
        }

        public static void ShouldBeHidden(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeHidden(elementHandleTask.Result(), message);
        }

        public static void ShouldBeHidden(ElementHandle elementHandle, string message)
        {
            Exception("Should be hidden, but is not.", message);
        }

        public static void ShouldBeSelected(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeSelected(elementHandleTask.Result(), message);
        }

        public static void ShouldBeSelected(ElementHandle elementHandle, string message)
        {
            Exception("Should be selected, but is not.", message);
        }

        public static void ShouldNotBeSelected(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotBeSelected(elementHandleTask.Result(), message);
        }

        public static void ShouldNotBeSelected(ElementHandle elementHandle, string message)
        {
            Exception("Should not be selected, but is.", message);
        }

        public static void ShouldBeChecked(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeChecked(elementHandleTask.Result(), message);
        }

        public static void ShouldBeChecked(ElementHandle elementHandle, string message)
        {
            Exception("Should be checked, but is not.", message);
        }

        public static void ShouldNotBeChecked(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotBeChecked(elementHandleTask.Result(), message);
        }

        public static void ShouldNotBeChecked(ElementHandle elementHandle, string message)
        {
            Exception("Should not be checked, but is.", message);
        }

        public static void ShouldBeDisabled(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeDisabled(elementHandleTask.Result(), message);
        }

        public static void ShouldBeDisabled(ElementHandle elementHandle, string message)
        {
            Exception("Should be disabled, but is not.", message);
        }

        public static void ShouldBeEnabled(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeEnabled(elementHandleTask.Result(), message);
        }

        public static void ShouldBeEnabled(ElementHandle elementHandle, string message)
        {
            Exception("Should be enabled, but is not.", message);
        }

        public static void ShouldBeReadOnly(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeReadOnly(elementHandleTask.Result(), message);
        }

        public static void ShouldBeReadOnly(ElementHandle elementHandle, string message)
        {
            Exception("Should be read-only, but is not.", message);
        }

        public static void ShouldNotBeReadOnly(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotBeReadOnly(elementHandleTask.Result(), message);
        }

        public static void ShouldNotBeReadOnly(ElementHandle elementHandle, string message)
        {
            Exception("Should not be read-only, but is.", message);
        }

        public static void ShouldBeRequired(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldBeRequired(elementHandleTask.Result(), message);
        }

        public static void ShouldBeRequired(ElementHandle elementHandle, string message)
        {
            Exception("Should be required, but is not.", message);
        }

        public static void ShouldNotBeRequired(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotBeRequired(elementHandleTask.Result(), message);
        }

        public static void ShouldNotBeRequired(ElementHandle elementHandle, string message)
        {
            Exception("Should not be required, but is.", message);
        }

        public static void ShouldHaveFocus(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldHaveFocus(elementHandleTask.Result(), message);
        }

        public static void ShouldHaveFocus(ElementHandle elementHandle, string message)
        {
            Exception("Should have focus, but did not.", message);
        }

        public static void ShouldNotHaveFocus(Task<ElementHandle> elementHandleTask, string message)
        {
            ShouldNotHaveFocus(elementHandleTask.Result(), message);
        }

        public static void ShouldNotHaveFocus(ElementHandle elementHandle, string message)
        {
            Exception("Should not have focus, but did.", message);
        }

        private static T Result<T>(this Task<T> elementHandleTask)
        {
            return elementHandleTask.GetAwaiter().GetResult();
        }

        private static void Exception(string message, string customMessage)
        {
            throw new ShouldException(new ShouldMessage(message, customMessage).ToString());
        }
    }
}
