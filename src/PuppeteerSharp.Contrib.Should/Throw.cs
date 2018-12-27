using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class Throw
    {
        public static void ShouldExist(Task<ElementHandle> task, string message)
        {
            ShouldExist(task.Result(), message);
        }

        public static void ShouldExist(ElementHandle handle, string message)
        {
            Exception("Should exist, but did not.", message);
        }

        public static void ShouldNotExist(Task<ElementHandle> task, string message)
        {
            ShouldNotExist(task.Result(), message);
        }

        public static void ShouldNotExist(ElementHandle handle, string message)
        {
            Exception("Should not exist, but did.", message);
        }

        public static void ShouldHaveValue(Task<ElementHandle> task, string message)
        {
            ShouldHaveValue(task.Result(), message);
        }

        public static void ShouldHaveValue(ElementHandle handle, string message)
        {
            Exception("Should have value, but did not.", message);
        }

        public static void ShouldNotHaveValue(Task<ElementHandle> task, string message)
        {
            ShouldNotHaveValue(task.Result(), message);
        }

        public static void ShouldNotHaveValue(ElementHandle handle, string message)
        {
            Exception("Should not have value, but did.", message);
        }

        public static void ShouldHaveAttribute(Task<ElementHandle> task, string message)
        {
            ShouldHaveAttribute(task.Result(), message);
        }

        public static void ShouldHaveAttribute(ElementHandle handle, string message)
        {
            Exception("Should have attribute, but did not.", message);
        }

        public static void ShouldNotHaveAttribute(Task<ElementHandle> task, string message)
        {
            ShouldNotHaveAttribute(task.Result(), message);
        }

        public static void ShouldNotHaveAttribute(ElementHandle handle, string message)
        {
            Exception("Should not have attribute, but did.", message);
        }

        public static void ShouldHaveContent(Task<ElementHandle> task, string message)
        {
            ShouldHaveContent(task.Result(), message);
        }

        public static void ShouldHaveContent(ElementHandle handle, string message)
        {
            Exception("Should have content, but did not.", message);
        }

        public static void ShouldNotHaveContent(Task<ElementHandle> task, string message)
        {
            ShouldNotHaveContent(task.Result(), message);
        }

        public static void ShouldNotHaveContent(ElementHandle handle, string message)
        {
            Exception("Should not have content, but did.", message);
        }

        public static void ShouldHaveClass(Task<ElementHandle> task, string message)
        {
            ShouldHaveClass(task.Result(), message);
        }

        public static void ShouldHaveClass(ElementHandle handle, string message)
        {
            Exception("Should have class, but did not.", message);
        }

        public static void ShouldNotHaveClass(Task<ElementHandle> task, string message)
        {
            ShouldNotHaveClass(task.Result(), message);
        }

        public static void ShouldNotHaveClass(ElementHandle handle, string message)
        {
            Exception("Should not have class, but did.", message);
        }

        public static void ShouldBeVisible(Task<ElementHandle> task, string message)
        {
            ShouldBeVisible(task.Result(), message);
        }

        public static void ShouldBeVisible(ElementHandle handle, string message)
        {
            Exception("Should be visible, but is not.", message);
        }

        public static void ShouldBeHidden(Task<ElementHandle> task, string message)
        {
            ShouldBeHidden(task.Result(), message);
        }

        public static void ShouldBeHidden(ElementHandle handle, string message)
        {
            Exception("Should be hidden, but is not.", message);
        }

        public static void ShouldBeSelected(Task<ElementHandle> task, string message)
        {
            ShouldBeSelected(task.Result(), message);
        }

        public static void ShouldBeSelected(ElementHandle handle, string message)
        {
            Exception("Should be selected, but is not.", message);
        }

        public static void ShouldNotBeSelected(Task<ElementHandle> task, string message)
        {
            ShouldNotBeSelected(task.Result(), message);
        }

        public static void ShouldNotBeSelected(ElementHandle handle, string message)
        {
            Exception("Should not be selected, but is.", message);
        }

        public static void ShouldBeChecked(Task<ElementHandle> task, string message)
        {
            ShouldBeChecked(task.Result(), message);
        }

        public static void ShouldBeChecked(ElementHandle handle, string message)
        {
            Exception("Should be checked, but is not.", message);
        }

        public static void ShouldNotBeChecked(Task<ElementHandle> task, string message)
        {
            ShouldNotBeChecked(task.Result(), message);
        }

        public static void ShouldNotBeChecked(ElementHandle handle, string message)
        {
            Exception("Should not be checked, but is.", message);
        }

        public static void ShouldBeDisabled(Task<ElementHandle> task, string message)
        {
            ShouldBeDisabled(task.Result(), message);
        }

        public static void ShouldBeDisabled(ElementHandle handle, string message)
        {
            Exception("Should be disabled, but is not.", message);
        }

        public static void ShouldBeEnabled(Task<ElementHandle> task, string message)
        {
            ShouldBeEnabled(task.Result(), message);
        }

        public static void ShouldBeEnabled(ElementHandle handle, string message)
        {
            Exception("Should be enabled, but is not.", message);
        }

        public static void ShouldBeReadOnly(Task<ElementHandle> task, string message)
        {
            ShouldBeReadOnly(task.Result(), message);
        }

        public static void ShouldBeReadOnly(ElementHandle handle, string message)
        {
            Exception("Should be read-only, but is not.", message);
        }

        public static void ShouldNotBeReadOnly(Task<ElementHandle> task, string message)
        {
            ShouldNotBeReadOnly(task.Result(), message);
        }

        public static void ShouldNotBeReadOnly(ElementHandle handle, string message)
        {
            Exception("Should not be read-only, but is.", message);
        }

        public static void ShouldHaveFocus(Task<ElementHandle> task, string message)
        {
            ShouldHaveFocus(task.Result(), message);
        }

        public static void ShouldHaveFocus(ElementHandle handle, string message)
        {
            Exception("Should have focus, but did not.", message);
        }

        public static void ShouldNotHaveFocus(Task<ElementHandle> task, string message)
        {
            ShouldNotHaveFocus(task.Result(), message);
        }

        public static void ShouldNotHaveFocus(ElementHandle handle, string message)
        {
            Exception("Should not have focus, but did.", message);
        }

        // Result

        private static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        // Throw

        private static void Exception(string message, string customMessage)
        {
            throw new ShouldException(new ShouldMessage(message, customMessage).ToString());
        }
    }
}