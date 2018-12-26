using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    public static class ShouldExtensionMethods
    {
        // Exist

        public static void ShouldExist(this ElementHandle handle)
        {
            if (!handle.Exists()) throw new ShouldException("Should exist, but did not.");
        }

        public static void ShouldExist(this Task<ElementHandle> task)
        {
            if (!task.Exists()) throw new ShouldException("Should exist, but did not.");
        }

        public static void ShouldNotExist(this ElementHandle handle)
        {
            if (handle.Exists()) throw new ShouldException("Should not exist, but did.");
        }

        public static void ShouldNotExist(this Task<ElementHandle> task)
        {
            if (task.Exists()) throw new ShouldException("Should not exist, but did.");
        }

        // Value

        public static void ShouldHaveValue(this ElementHandle handle, string value)
        {
            if (handle.Value() != value) throw new ShouldException("Should have value, but did not.");
        }

        public static void ShouldHaveValue(this Task<ElementHandle> task, string value)
        {
            if (task.Value() != value) throw new ShouldException("Should have value, but did not.");
        }

        public static void ShouldNotHaveValue(this ElementHandle handle, string value)
        {
            if (handle.Value() == value) throw new ShouldException("Should not have value, but did.");
        }

        public static void ShouldNotHaveValue(this Task<ElementHandle> task, string value)
        {
            if (task.Value() == value) throw new ShouldException("Should not have value, but did.");
        }

        // Attribute

        public static void ShouldHaveAttribute(this ElementHandle handle, string name)
        {
            if (!handle.HasAttribute(name)) throw new ShouldException("Should have attribute, but did not.");
        }

        public static void ShouldHaveAttribute(this Task<ElementHandle> task, string name)
        {
            if (!task.HasAttribute(name)) throw new ShouldException("Should have attribute, but did not.");
        }

        public static void ShouldNotHaveAttribute(this ElementHandle handle, string name)
        {
            if (handle.HasAttribute(name)) throw new ShouldException("Should not have attribute, but did.");
        }

        public static void ShouldNotHaveAttribute(this Task<ElementHandle> task, string name)
        {
            if (task.HasAttribute(name)) throw new ShouldException("Should not have attribute, but did.");
        }

        // Content

        public static void ShouldHaveContent(this ElementHandle handle, string content)
        {
            if (!handle.HasContent(content)) throw new ShouldException("Should have content, but did not.");
        }

        public static void ShouldHaveContent(this Task<ElementHandle> task, string content)
        {
            if (!task.HasContent(content)) throw new ShouldException("Should have content, but did not.");
        }

        public static void ShouldNotHaveContent(this ElementHandle handle, string content)
        {
            if (handle.HasContent(content)) throw new ShouldException("Should not have content, but did.");
        }

        public static void ShouldNotHaveContent(this Task<ElementHandle> task, string content)
        {
            if (task.HasContent(content)) throw new ShouldException("Should not have content, but did.");
        }

        // Class

        public static void ShouldHaveClass(this ElementHandle handle, string className)
        {
            if (!handle.HasClass(className)) throw new ShouldException("Should have class, but did not.");
        }

        public static void ShouldHaveClass(this Task<ElementHandle> task, string className)
        {
            if (!task.HasClass(className)) throw new ShouldException("Should have class, but did not.");
        }

        public static void ShouldNotHaveClass(this ElementHandle handle, string className)
        {
            if (handle.HasClass(className)) throw new ShouldException("Should not have class, but did.");
        }

        public static void ShouldNotHaveClass(this Task<ElementHandle> task, string className)
        {
            if (task.HasClass(className)) throw new ShouldException("Should not have class, but did.");
        }

        // Visible

        public static void ShouldBeVisible(this ElementHandle handle)
        {
            if (handle.IsHidden()) throw new ShouldException("Should be visible, but is not.");
        }

        public static void ShouldBeVisible(this Task<ElementHandle> task)
        {
            if (task.IsHidden()) throw new ShouldException("Should be visible, but is not.");
        }

        public static void ShouldBeHidden(this ElementHandle handle)
        {
            if (handle.IsVisible()) throw new ShouldException("Should be hidden, but is not.");
        }

        public static void ShouldBeHidden(this Task<ElementHandle> task)
        {
            if (task.IsVisible()) throw new ShouldException("Should be hidden, but is not.");
        }

        // Selected

        public static void ShouldBeSelected(this ElementHandle handle)
        {
            if (!handle.IsSelected()) throw new ShouldException("Should be selected, but is not.");
        }

        public static void ShouldBeSelected(this Task<ElementHandle> task)
        {
            if (!task.IsSelected()) throw new ShouldException("Should be selected, but is not.");
        }

        public static void ShouldNotBeSelected(this ElementHandle handle)
        {
            if (handle.IsSelected()) throw new ShouldException("Should not be selected, but is.");
        }

        public static void ShouldNotBeSelected(this Task<ElementHandle> task)
        {
            if (task.IsSelected()) throw new ShouldException("Should not be selected, but is.");
        }

        // Checked

        public static void ShouldBeChecked(this ElementHandle handle)
        {
            if (!handle.IsChecked()) throw new ShouldException("Should be checked, but is not.");
        }

        public static void ShouldBeChecked(this Task<ElementHandle> task)
        {
            if (!task.IsChecked()) throw new ShouldException("Should be checked, but is not.");
        }

        public static void ShouldNotBeChecked(this ElementHandle handle)
        {
            if (handle.IsChecked()) throw new ShouldException("Should not be checked, but is.");
        }

        public static void ShouldNotBeChecked(this Task<ElementHandle> task)
        {
            if (task.IsChecked()) throw new ShouldException("Should not be checked, but is.");
        }

        // Disabled

        public static void ShouldBeDisabled(this ElementHandle handle)
        {
            if (handle.IsEnabled()) throw new ShouldException("Should be disabled, but is not.");
        }

        public static void ShouldBeDisabled(this Task<ElementHandle> task)
        {
            if (task.IsEnabled()) throw new ShouldException("Should be disabled, but is not.");
        }

        public static void ShouldBeEnabled(this ElementHandle handle)
        {
            if (handle.IsDisabled()) throw new ShouldException("Should be enabled, but is not.");
        }

        public static void ShouldBeEnabled(this Task<ElementHandle> task)
        {
            if (task.IsDisabled()) throw new ShouldException("Should be enabled, but is not.");
        }

        // ReadOnly

        public static void ShouldBeReadOnly(this ElementHandle handle)
        {
            if (!handle.IsReadOnly()) throw new ShouldException("Should be read-only, but is not.");
        }

        public static void ShouldBeReadOnly(this Task<ElementHandle> task)
        {
            if (!task.IsReadOnly()) throw new ShouldException("Should be read-only, but is not.");
        }

        public static void ShouldNotBeReadOnly(this ElementHandle handle)
        {
            if (handle.IsReadOnly()) throw new ShouldException("Should not be read-only, but is.");
        }

        public static void ShouldNotBeReadOnly(this Task<ElementHandle> task)
        {
            if (task.IsReadOnly()) throw new ShouldException("Should not be read-only, but is.");
        }

        // Focus

        public static void ShouldHaveFocus(this ElementHandle handle)
        {
            if (!handle.HasFocus()) throw new ShouldException("Should have focus, but did not.");
        }

        public static void ShouldHaveFocus(this Task<ElementHandle> task)
        {
            if (!task.HasFocus()) throw new ShouldException("Should have focus, but did not.");
        }

        public static void ShouldNotHaveFocus(this ElementHandle handle)
        {
            if (handle.HasFocus()) throw new ShouldException("Should not have focus, but did.");
        }

        public static void ShouldNotHaveFocus(this Task<ElementHandle> task)
        {
            if (task.HasFocus()) throw new ShouldException("Should not have focus, but did.");
        }
    }
}