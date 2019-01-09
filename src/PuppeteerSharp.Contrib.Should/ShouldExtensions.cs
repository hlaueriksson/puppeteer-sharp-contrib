using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// <see cref="ElementHandle"/> extension methods for should assertions.
    /// </summary>
    public static class ShouldExtensions
    {
        // Exist

        /// <summary>
        /// Asserts that the element exists.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldExist(this ElementHandle handle, string message = null)
        {
            if (!handle.Exists()) Throw.ShouldExist(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element exists.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldExist(this Task<ElementHandle> task, string message = null)
        {
            if (!task.Exists()) Throw.ShouldExist(task, message);
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotExist(this ElementHandle handle, string message = null)
        {
            if (handle.Exists()) Throw.ShouldNotExist(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotExist(this Task<ElementHandle> task, string message = null)
        {
            if (task.Exists()) Throw.ShouldNotExist(task, message);
        }

        // Value

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task ShouldHaveValueAsync(this ElementHandle handle, string value, string message = null)
        {
            if (await handle.ValueAsync().ConfigureAwait(false) != value) Throw.ShouldHaveValue(handle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveValue(this ElementHandle handle, string value, string message = null)
        {
            if (handle.Value() != value) Throw.ShouldHaveValue(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static void ShouldHaveValue(this Task<ElementHandle> task, string value, string message = null)
        {
            if (task.Value() != value) Throw.ShouldHaveValue(task, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task ShouldNotHaveValueAsync(this ElementHandle handle, string value, string message = null)
        {
            if (await handle.ValueAsync().ConfigureAwait(false) == value) Throw.ShouldNotHaveValue(handle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveValue(this ElementHandle handle, string value, string message = null)
        {
            if (handle.Value() == value) Throw.ShouldNotHaveValue(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static void ShouldNotHaveValue(this Task<ElementHandle> task, string value, string message = null)
        {
            if (task.Value() == value) Throw.ShouldNotHaveValue(task, message);
        }

        // Attribute

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        public static async Task ShouldHaveAttributeAsync(this ElementHandle handle, string name, string message = null)
        {
            if (!await handle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ShouldHaveAttribute(handle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveAttribute(this ElementHandle handle, string name, string message = null)
        {
            if (!handle.HasAttribute(name)) Throw.ShouldHaveAttribute(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldHaveAttribute(this Task<ElementHandle> task, string name, string message = null)
        {
            if (!task.HasAttribute(name)) Throw.ShouldHaveAttribute(task, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        public static async Task ShouldNotHaveAttributeAsync(this ElementHandle handle, string name, string message = null)
        {
            if (await handle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ShouldNotHaveAttribute(handle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveAttribute(this ElementHandle handle, string name, string message = null)
        {
            if (handle.HasAttribute(name)) Throw.ShouldNotHaveAttribute(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotHaveAttribute(this Task<ElementHandle> task, string name, string message = null)
        {
            if (task.HasAttribute(name)) Throw.ShouldNotHaveAttribute(task, message);
        }

        // Content

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static async Task ShouldHaveContentAsync(this ElementHandle handle, string content, string message = null)
        {
            if (!await handle.HasContentAsync(content).ConfigureAwait(false)) Throw.ShouldHaveContent(handle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static ElementHandle ShouldHaveContent(this ElementHandle handle, string content, string message = null)
        {
            if (!handle.HasContent(content)) Throw.ShouldHaveContent(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static void ShouldHaveContent(this Task<ElementHandle> task, string content, string message = null)
        {
            if (!task.HasContent(content)) Throw.ShouldHaveContent(task, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static async Task ShouldNotHaveContentAsync(this ElementHandle handle, string content, string message = null)
        {
            if (await handle.HasContentAsync(content).ConfigureAwait(false)) Throw.ShouldNotHaveContent(handle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static ElementHandle ShouldNotHaveContent(this ElementHandle handle, string content, string message = null)
        {
            if (handle.HasContent(content)) Throw.ShouldNotHaveContent(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static void ShouldNotHaveContent(this Task<ElementHandle> task, string content, string message = null)
        {
            if (task.HasContent(content)) Throw.ShouldNotHaveContent(task, message);
        }

        // Class

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        public static async Task ShouldHaveClassAsync(this ElementHandle handle, string className, string message = null)
        {
            if (!await handle.HasClassAsync(className).ConfigureAwait(false)) Throw.ShouldHaveClass(handle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveClass(this ElementHandle handle, string className, string message = null)
        {
            if (!handle.HasClass(className)) Throw.ShouldHaveClass(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldHaveClass(this Task<ElementHandle> task, string className, string message = null)
        {
            if (!task.HasClass(className)) Throw.ShouldHaveClass(task, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        public static async Task ShouldNotHaveClassAsync(this ElementHandle handle, string className, string message = null)
        {
            if (await handle.HasClassAsync(className).ConfigureAwait(false)) Throw.ShouldNotHaveClass(handle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveClass(this ElementHandle handle, string className, string message = null)
        {
            if (handle.HasClass(className)) Throw.ShouldNotHaveClass(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotHaveClass(this Task<ElementHandle> task, string className, string message = null)
        {
            if (task.HasClass(className)) Throw.ShouldNotHaveClass(task, message);
        }

        // Visible

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static async Task ShouldBeVisibleAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsHiddenAsync().ConfigureAwait(false)) Throw.ShouldBeVisible(handle, message);
        }

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeVisible(this ElementHandle handle, string message = null)
        {
            if (handle.IsHidden()) Throw.ShouldBeVisible(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldBeVisible(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsHidden()) Throw.ShouldBeVisible(task, message);
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static async Task ShouldBeHiddenAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsVisibleAsync().ConfigureAwait(false)) Throw.ShouldBeHidden(handle, message);
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeHidden(this ElementHandle handle, string message = null)
        {
            if (handle.IsVisible()) Throw.ShouldBeHidden(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldBeHidden(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsVisible()) Throw.ShouldBeHidden(task, message);
        }

        // Selected

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldBeSelectedAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.IsSelectedAsync().ConfigureAwait(false)) Throw.ShouldBeSelected(handle, message);
        }

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeSelected(this ElementHandle handle, string message = null)
        {
            if (!handle.IsSelected()) Throw.ShouldBeSelected(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static void ShouldBeSelected(this Task<ElementHandle> task, string message = null)
        {
            if (!task.IsSelected()) Throw.ShouldBeSelected(task, message);
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldNotBeSelectedAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsSelectedAsync().ConfigureAwait(false)) Throw.ShouldNotBeSelected(handle, message);
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeSelected(this ElementHandle handle, string message = null)
        {
            if (handle.IsSelected()) Throw.ShouldNotBeSelected(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static void ShouldNotBeSelected(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsSelected()) Throw.ShouldNotBeSelected(task, message);
        }

        // Checked

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task ShouldBeCheckedAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.IsCheckedAsync().ConfigureAwait(false)) Throw.ShouldBeChecked(handle, message);
        }

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeChecked(this ElementHandle handle, string message = null)
        {
            if (!handle.IsChecked()) Throw.ShouldBeChecked(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static void ShouldBeChecked(this Task<ElementHandle> task, string message = null)
        {
            if (!task.IsChecked()) Throw.ShouldBeChecked(task, message);
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task ShouldNotBeCheckedAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsCheckedAsync().ConfigureAwait(false)) Throw.ShouldNotBeChecked(handle, message);
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeChecked(this ElementHandle handle, string message = null)
        {
            if (handle.IsChecked()) Throw.ShouldNotBeChecked(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static void ShouldNotBeChecked(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsChecked()) Throw.ShouldNotBeChecked(task, message);
        }

        // Disabled

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeDisabledAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsEnabledAsync().ConfigureAwait(false)) Throw.ShouldBeDisabled(handle, message);
        }

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeDisabled(this ElementHandle handle, string message = null)
        {
            if (handle.IsEnabled()) Throw.ShouldBeDisabled(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static void ShouldBeDisabled(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsEnabled()) Throw.ShouldBeDisabled(task, message);
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeEnabledAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsDisabledAsync().ConfigureAwait(false)) Throw.ShouldBeEnabled(handle, message);
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeEnabled(this ElementHandle handle, string message = null)
        {
            if (handle.IsDisabled()) Throw.ShouldBeEnabled(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static void ShouldBeEnabled(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsDisabled()) Throw.ShouldBeEnabled(task, message);
        }

        // ReadOnly

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldBeReadOnlyAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ShouldBeReadOnly(handle, message);
        }

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeReadOnly(this ElementHandle handle, string message = null)
        {
            if (!handle.IsReadOnly()) Throw.ShouldBeReadOnly(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static void ShouldBeReadOnly(this Task<ElementHandle> task, string message = null)
        {
            if (!task.IsReadOnly()) Throw.ShouldBeReadOnly(task, message);
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldNotBeReadOnlyAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ShouldNotBeReadOnly(handle, message);
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeReadOnly(this ElementHandle handle, string message = null)
        {
            if (handle.IsReadOnly()) Throw.ShouldNotBeReadOnly(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static void ShouldNotBeReadOnly(this Task<ElementHandle> task, string message = null)
        {
            if (task.IsReadOnly()) Throw.ShouldNotBeReadOnly(task, message);
        }

        // Focus

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static async Task ShouldHaveFocusAsync(this ElementHandle handle, string message = null)
        {
            if (!await handle.HasFocusAsync().ConfigureAwait(false)) Throw.ShouldHaveFocus(handle, message);
        }

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveFocus(this ElementHandle handle, string message = null)
        {
            if (!handle.HasFocus()) Throw.ShouldHaveFocus(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static void ShouldHaveFocus(this Task<ElementHandle> task, string message = null)
        {
            if (!task.HasFocus()) Throw.ShouldHaveFocus(task, message);
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotHaveFocusAsync(this ElementHandle handle, string message = null)
        {
            if (await handle.HasFocusAsync().ConfigureAwait(false)) Throw.ShouldNotHaveFocus(handle, message);
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveFocus(this ElementHandle handle, string message = null)
        {
            if (handle.HasFocus()) Throw.ShouldNotHaveFocus(handle, message);

            return handle;
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static void ShouldNotHaveFocus(this Task<ElementHandle> task, string message = null)
        {
            if (task.HasFocus()) Throw.ShouldNotHaveFocus(task, message);
        }
    }
}