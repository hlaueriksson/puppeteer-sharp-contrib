using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    public static class ShouldExtensions
    {
        // Exist

        public static void ShouldExist(this ElementHandle handle, string message = null)
        {
            if (!handle.Exists()) Throw.ShouldExist(handle, message);
        }

        public static void ShouldExist(this Task<ElementHandle> task, string message = null)
        {
            if (!task.Exists()) Throw.ShouldExist(task, message);
        }

        public static void ShouldNotExist(this ElementHandle handle, string message = null)
        {
            if (handle.Exists()) Throw.ShouldNotExist(handle, message);
        }

        public static void ShouldNotExist(this Task<ElementHandle> task, string message = null)
        {
            if (task.Exists()) Throw.ShouldNotExist(task, message);
        }

        // Value

        public static async Task ShouldHaveValueAsync(this ElementHandle handle, string value, string message = null)
        {
            if (await handle.ValueAsync().ConfigureAwait(false) != value) Throw.ShouldHaveValue(handle, message);
        }

        public static void ShouldHaveValue(this ElementHandle handle, string value, string message = null)
        {
            if (handle.Value() != value) Throw.ShouldHaveValue(handle, message);
        }

        public static void ShouldHaveValue(this Task<ElementHandle> task, string value, string message = null)
        {
            if (task.Value() != value) Throw.ShouldHaveValue(task, message);
        }

        public static async Task ShouldNotHaveValueAsync(this ElementHandle handle, string value, string message = null)
        {
            if (await handle.ValueAsync().ConfigureAwait(false) == value) Throw.ShouldNotHaveValue(handle, message);
        }

        public static void ShouldNotHaveValue(this ElementHandle handle, string value, string message = null)
        {
            if (handle.Value() == value) Throw.ShouldNotHaveValue(handle, message);
        }

        public static void ShouldNotHaveValue(this Task<ElementHandle> task, string value, string message = null)
        {
            if (task.Value() == value) Throw.ShouldNotHaveValue(task, message);
        }

        // Attribute

        public static async Task ShouldHaveAttributeAsync(this ElementHandle handle, string name, string message = null)
        {
            if (!await handle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ShouldHaveAttribute(handle, message);
        }

        public static void ShouldHaveAttribute(this ElementHandle handle, string name, string message = null)
        {
            if (!handle.HasAttribute(name)) Throw.ShouldHaveAttribute(handle, message);
        }

        public static void ShouldHaveAttribute(this Task<ElementHandle> task, string name, string message = null)
        {
            if (!task.HasAttribute(name)) Throw.ShouldHaveAttribute(task, message);
        }

        public static async Task ShouldNotHaveAttributeAsync(this ElementHandle handle, string name, string message = null)
        {
            if (await handle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ShouldNotHaveAttribute(handle, message);
        }

        public static void ShouldNotHaveAttribute(this ElementHandle handle, string name, string message = null)
        {
            if (handle.HasAttribute(name)) Throw.ShouldNotHaveAttribute(handle, message);
        }

        public static void ShouldNotHaveAttribute(this Task<ElementHandle> task, string name, string message = null)
        {
            if (task.HasAttribute(name)) Throw.ShouldNotHaveAttribute(task, message);
        }

        // Content

        public static async Task ShouldHaveContentAsync(this ElementHandle handle, string content, string message = null)
        {
            if (!await handle.HasContentAsync(content).ConfigureAwait(false)) Throw.ShouldHaveContent(handle, message);
        }

        public static void ShouldHaveContent(this ElementHandle handle, string content, string message = null)
        {
            if (!handle.HasContent(content)) Throw.ShouldHaveContent(handle, message);
        }

        public static void ShouldHaveContent(this Task<ElementHandle> task, string content, string message = null)
        {
            if (!task.HasContent(content)) Throw.ShouldHaveContent(task, message);
        }

        public static async Task ShouldNotHaveContentAsync(this ElementHandle handle, string content, string message = null)
        {
            if (await handle.HasContentAsync(content).ConfigureAwait(false)) Throw.ShouldNotHaveContent(handle, message);
        }

        public static void ShouldNotHaveContent(this ElementHandle handle, string content, string message = null)
        {
            if (handle.HasContent(content)) Throw.ShouldNotHaveContent(handle, message);
        }

        public static void ShouldNotHaveContent(this Task<ElementHandle> task, string content, string message = null)
        {
            if (task.HasContent(content)) Throw.ShouldNotHaveContent(task, message);
        }

        // Class

        public static async Task ShouldHaveClassAsync(this ElementHandle handle, string className, string message = null)
        {
            if (!await handle.HasClassAsync(className).ConfigureAwait(false)) Throw.ShouldHaveClass(handle, message);
        }

        public static void ShouldHaveClass(this ElementHandle handle, string className, string message = null)
        {
            if (!handle.HasClass(className)) Throw.ShouldHaveClass(handle, message);
        }

        public static void ShouldHaveClass(this Task<ElementHandle> task, string className, string message = null)
        {
            if (!task.HasClass(className)) Throw.ShouldHaveClass(task, message);
        }

        public static async Task ShouldNotHaveClassAsync(this ElementHandle handle, string className, string message = null)
        {
            if (await handle.HasClassAsync(className).ConfigureAwait(false)) Throw.ShouldNotHaveClass(handle, message);
        }

        public static void ShouldNotHaveClass(this ElementHandle handle, string className, string message = null)
        {
            if (handle.HasClass(className)) Throw.ShouldNotHaveClass(handle, message);
        }

        public static void ShouldNotHaveClass(this Task<ElementHandle> task, string className, string message = null)
        {
            if (task.HasClass(className)) Throw.ShouldNotHaveClass(task, message);
        }

        // Visible

        public static async Task ShouldBeVisibleAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsHiddenAsync().ConfigureAwait(false)) Throw.ShouldBeVisible(handle, message);
        }

        public static void ShouldBeVisible(this ElementHandle handle, string message = null)
        {
            if (handle.IsHidden()) Throw.ShouldBeVisible(handle, message);
        }

        public static void ShouldBeVisible(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsHidden()) Throw.ShouldBeVisible(task, message);
        }

        public static async Task ShouldBeHiddenAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsVisibleAsync().ConfigureAwait(false)) Throw.ShouldBeHidden(handle, message);
        }

        public static void ShouldBeHidden(this ElementHandle handle, string message = null)
        {
            if (handle.IsVisible()) Throw.ShouldBeHidden(handle, message);
        }

        public static void ShouldBeHidden(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsVisible()) Throw.ShouldBeHidden(task, message);
        }

        // Selected

        public static async Task ShouldBeSelectedAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.IsSelectedAsync().ConfigureAwait(false)) Throw.ShouldBeSelected(handle, message);
        }

        public static void ShouldBeSelected(this ElementHandle handle, string message = null)
        {
            if (!handle.IsSelected()) Throw.ShouldBeSelected(handle, message);
        }

        public static void ShouldBeSelected(this Task<ElementHandle> task, string message = null)
        {
            if (!task.IsSelected()) Throw.ShouldBeSelected(task, message);
        }

        public static async Task ShouldNotBeSelectedAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsSelectedAsync().ConfigureAwait(false)) Throw.ShouldNotBeSelected(handle, message);
        }

        public static void ShouldNotBeSelected(this ElementHandle handle, string message = null)
        {
            if (handle.IsSelected()) Throw.ShouldNotBeSelected(handle, message);
        }

        public static void ShouldNotBeSelected(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsSelected()) Throw.ShouldNotBeSelected(task, message);
        }

        // Checked

        public static async Task ShouldBeCheckedAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.IsCheckedAsync().ConfigureAwait(false)) Throw.ShouldBeChecked(handle, message);
        }

        public static void ShouldBeChecked(this ElementHandle handle, string message = null)
        {
            if (!handle.IsChecked()) Throw.ShouldBeChecked(handle, message);
        }

        public static void ShouldBeChecked(this Task<ElementHandle> task, string message = null)
        {
            if (!task.IsChecked()) Throw.ShouldBeChecked(task, message);
        }

        public static async Task ShouldNotBeCheckedAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsCheckedAsync().ConfigureAwait(false)) Throw.ShouldNotBeChecked(handle, message);
        }

        public static void ShouldNotBeChecked(this ElementHandle handle, string message = null)
        {
            if (handle.IsChecked()) Throw.ShouldNotBeChecked(handle, message);
        }

        public static void ShouldNotBeChecked(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsChecked()) Throw.ShouldNotBeChecked(task, message);
        }

        // Disabled

        public static async Task ShouldBeDisabledAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsEnabledAsync().ConfigureAwait(false)) Throw.ShouldBeDisabled(handle, message);
        }

        public static void ShouldBeDisabled(this ElementHandle handle, string message = null)
        {
            if (handle.IsEnabled()) Throw.ShouldBeDisabled(handle, message);
        }

        public static void ShouldBeDisabled(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsEnabled()) Throw.ShouldBeDisabled(task, message);
        }

        public static async Task ShouldBeEnabledAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsDisabledAsync().ConfigureAwait(false)) Throw.ShouldBeEnabled(handle, message);
        }

        public static void ShouldBeEnabled(this ElementHandle handle, string message = null)
        {
            if (handle.IsDisabled()) Throw.ShouldBeEnabled(handle, message);
        }

        public static void ShouldBeEnabled(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsDisabled()) Throw.ShouldBeEnabled(task, message);
        }

        // ReadOnly

        public static async Task ShouldBeReadOnlyAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ShouldBeReadOnly(handle, message);
        }

        public static void ShouldBeReadOnly(this ElementHandle handle, string message = null)
        {
            if (!handle.IsReadOnly()) Throw.ShouldBeReadOnly(handle, message);
        }

        public static void ShouldBeReadOnly(this Task<ElementHandle> task, string message = null)
        {
            if (!task.IsReadOnly()) Throw.ShouldBeReadOnly(task, message);
        }

        public static async Task ShouldNotBeReadOnlyAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ShouldNotBeReadOnly(handle, message);
        }

        public static void ShouldNotBeReadOnly(this ElementHandle handle, string message = null)
        {
            if (handle.IsReadOnly()) Throw.ShouldNotBeReadOnly(handle, message);
        }

        public static void ShouldNotBeReadOnly(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsReadOnly()) Throw.ShouldNotBeReadOnly(task, message);
        }

        // Focus

        public static async Task ShouldHaveFocusAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.HasFocusAsync().ConfigureAwait(false)) Throw.ShouldHaveFocus(handle, message);
        }

        public static void ShouldHaveFocus(this ElementHandle handle, string message = null)
        {
            if (!handle.HasFocus()) Throw.ShouldHaveFocus(handle, message);
        }

        public static void ShouldHaveFocus(this Task<ElementHandle> task, string message = null)
        {
            if (!task.HasFocus()) Throw.ShouldHaveFocus(task, message);
        }

        public static async Task ShouldNotHaveFocusAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.HasFocusAsync().ConfigureAwait(false)) Throw.ShouldNotHaveFocus(handle, message);
        }

        public static void ShouldNotHaveFocus(this ElementHandle handle, string message = null)
        {
            if (handle.HasFocus()) Throw.ShouldNotHaveFocus(handle, message);
        }

        public static void ShouldNotHaveFocus(this Task<ElementHandle> task, string message = null)
        {
            if (task.HasFocus()) Throw.ShouldNotHaveFocus(task, message);
        }
    }
}