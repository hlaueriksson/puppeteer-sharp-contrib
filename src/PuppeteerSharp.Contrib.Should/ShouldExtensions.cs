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
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldExist(this ElementHandle elementHandle, string message = null)
        {
            if (!elementHandle.Exists()) Throw.ShouldExist(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element exists.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldExist(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (!elementHandleTask.Exists()) Throw.ShouldExist(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotExist(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.Exists()) Throw.ShouldNotExist(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotExist(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.Exists()) Throw.ShouldNotExist(elementHandleTask, message);
        }

        // Value

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task ShouldHaveValueAsync(this ElementHandle elementHandle, string value, string message = null)
        {
            if (await elementHandle.ValueAsync().ConfigureAwait(false) != value) Throw.ShouldHaveValue(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveValue(this ElementHandle elementHandle, string value, string message = null)
        {
            if (elementHandle.Value() != value) Throw.ShouldHaveValue(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static void ShouldHaveValue(this Task<ElementHandle> elementHandleTask, string value, string message = null)
        {
            if (elementHandleTask.Value() != value) Throw.ShouldHaveValue(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task ShouldNotHaveValueAsync(this ElementHandle elementHandle, string value, string message = null)
        {
            if (await elementHandle.ValueAsync().ConfigureAwait(false) == value) Throw.ShouldNotHaveValue(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveValue(this ElementHandle elementHandle, string value, string message = null)
        {
            if (elementHandle.Value() == value) Throw.ShouldNotHaveValue(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static void ShouldNotHaveValue(this Task<ElementHandle> elementHandleTask, string value, string message = null)
        {
            if (elementHandleTask.Value() == value) Throw.ShouldNotHaveValue(elementHandleTask, message);
        }

        // Attribute

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldHaveAttributeAsync(this ElementHandle elementHandle, string name, string message = null)
        {
            if (!await elementHandle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ShouldHaveAttribute(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveAttribute(this ElementHandle elementHandle, string name, string message = null)
        {
            if (!elementHandle.HasAttribute(name)) Throw.ShouldHaveAttribute(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldHaveAttribute(this Task<ElementHandle> elementHandleTask, string name, string message = null)
        {
            if (!elementHandleTask.HasAttribute(name)) Throw.ShouldHaveAttribute(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldNotHaveAttributeAsync(this ElementHandle elementHandle, string name, string message = null)
        {
            if (await elementHandle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ShouldNotHaveAttribute(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveAttribute(this ElementHandle elementHandle, string name, string message = null)
        {
            if (elementHandle.HasAttribute(name)) Throw.ShouldNotHaveAttribute(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotHaveAttribute(this Task<ElementHandle> elementHandleTask, string name, string message = null)
        {
            if (elementHandleTask.HasAttribute(name)) Throw.ShouldNotHaveAttribute(elementHandleTask, message);
        }

        // Content

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static async Task ShouldHaveContentAsync(this ElementHandle elementHandle, string content, string message = null)
        {
            if (!await elementHandle.HasContentAsync(content).ConfigureAwait(false)) Throw.ShouldHaveContent(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static ElementHandle ShouldHaveContent(this ElementHandle elementHandle, string content, string message = null)
        {
            if (!elementHandle.HasContent(content)) Throw.ShouldHaveContent(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static void ShouldHaveContent(this Task<ElementHandle> elementHandleTask, string content, string message = null)
        {
            if (!elementHandleTask.HasContent(content)) Throw.ShouldHaveContent(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static async Task ShouldNotHaveContentAsync(this ElementHandle elementHandle, string content, string message = null)
        {
            if (await elementHandle.HasContentAsync(content).ConfigureAwait(false)) Throw.ShouldNotHaveContent(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static ElementHandle ShouldNotHaveContent(this ElementHandle elementHandle, string content, string message = null)
        {
            if (elementHandle.HasContent(content)) Throw.ShouldNotHaveContent(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="message">Optional failure message</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static void ShouldNotHaveContent(this Task<ElementHandle> elementHandleTask, string content, string message = null)
        {
            if (elementHandleTask.HasContent(content)) Throw.ShouldNotHaveContent(elementHandleTask, message);
        }

        // Class

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldHaveClassAsync(this ElementHandle elementHandle, string className, string message = null)
        {
            if (!await elementHandle.HasClassAsync(className).ConfigureAwait(false)) Throw.ShouldHaveClass(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveClass(this ElementHandle elementHandle, string className, string message = null)
        {
            if (!elementHandle.HasClass(className)) Throw.ShouldHaveClass(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldHaveClass(this Task<ElementHandle> elementHandleTask, string className, string message = null)
        {
            if (!elementHandleTask.HasClass(className)) Throw.ShouldHaveClass(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldNotHaveClassAsync(this ElementHandle elementHandle, string className, string message = null)
        {
            if (await elementHandle.HasClassAsync(className).ConfigureAwait(false)) Throw.ShouldNotHaveClass(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveClass(this ElementHandle elementHandle, string className, string message = null)
        {
            if (elementHandle.HasClass(className)) Throw.ShouldNotHaveClass(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotHaveClass(this Task<ElementHandle> elementHandleTask, string className, string message = null)
        {
            if (elementHandleTask.HasClass(className)) Throw.ShouldNotHaveClass(elementHandleTask, message);
        }

        // Visible

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeVisibleAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsHiddenAsync().ConfigureAwait(false)) Throw.ShouldBeVisible(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeVisible(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsHidden()) Throw.ShouldBeVisible(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldBeVisible(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsHidden()) Throw.ShouldBeVisible(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeHiddenAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsVisibleAsync().ConfigureAwait(false)) Throw.ShouldBeHidden(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeHidden(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsVisible()) Throw.ShouldBeHidden(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldBeHidden(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsVisible()) Throw.ShouldBeHidden(elementHandleTask, message);
        }

        // Selected

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldBeSelectedAsync(this ElementHandle elementHandle, string message = null)
        {
            if (!await elementHandle.IsSelectedAsync().ConfigureAwait(false)) Throw.ShouldBeSelected(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeSelected(this ElementHandle elementHandle, string message = null)
        {
            if (!elementHandle.IsSelected()) Throw.ShouldBeSelected(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static void ShouldBeSelected(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (!elementHandleTask.IsSelected()) Throw.ShouldBeSelected(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldNotBeSelectedAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsSelectedAsync().ConfigureAwait(false)) Throw.ShouldNotBeSelected(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeSelected(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsSelected()) Throw.ShouldNotBeSelected(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static void ShouldNotBeSelected(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsSelected()) Throw.ShouldNotBeSelected(elementHandleTask, message);
        }

        // Checked

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task ShouldBeCheckedAsync(this ElementHandle elementHandle, string message = null)
        {
            if (!await elementHandle.IsCheckedAsync().ConfigureAwait(false)) Throw.ShouldBeChecked(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeChecked(this ElementHandle elementHandle, string message = null)
        {
            if (!elementHandle.IsChecked()) Throw.ShouldBeChecked(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static void ShouldBeChecked(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (!elementHandleTask.IsChecked()) Throw.ShouldBeChecked(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task ShouldNotBeCheckedAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsCheckedAsync().ConfigureAwait(false)) Throw.ShouldNotBeChecked(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeChecked(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsChecked()) Throw.ShouldNotBeChecked(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static void ShouldNotBeChecked(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsChecked()) Throw.ShouldNotBeChecked(elementHandleTask, message);
        }

        // Disabled

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeDisabledAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsEnabledAsync().ConfigureAwait(false)) Throw.ShouldBeDisabled(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeDisabled(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsEnabled()) Throw.ShouldBeDisabled(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static void ShouldBeDisabled(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsEnabled()) Throw.ShouldBeDisabled(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeEnabledAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsDisabledAsync().ConfigureAwait(false)) Throw.ShouldBeEnabled(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeEnabled(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsDisabled()) Throw.ShouldBeEnabled(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static void ShouldBeEnabled(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsDisabled()) Throw.ShouldBeEnabled(elementHandleTask, message);
        }

        // ReadOnly

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldBeReadOnlyAsync(this ElementHandle elementHandle, string message = null)
        {
            if (!await elementHandle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ShouldBeReadOnly(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeReadOnly(this ElementHandle elementHandle, string message = null)
        {
            if (!elementHandle.IsReadOnly()) Throw.ShouldBeReadOnly(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static void ShouldBeReadOnly(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (!elementHandleTask.IsReadOnly()) Throw.ShouldBeReadOnly(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldNotBeReadOnlyAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ShouldNotBeReadOnly(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeReadOnly(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsReadOnly()) Throw.ShouldNotBeReadOnly(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static void ShouldNotBeReadOnly(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsReadOnly()) Throw.ShouldNotBeReadOnly(elementHandleTask, message);
        }

        // Required

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeRequiredAsync(this ElementHandle elementHandle, string message = null)
        {
            if (!await elementHandle.IsRequiredAsync().ConfigureAwait(false)) Throw.ShouldBeRequired(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeRequired(this ElementHandle elementHandle, string message = null)
        {
            if (!elementHandle.IsRequired()) Throw.ShouldBeRequired(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static void ShouldBeRequired(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (!elementHandleTask.IsRequired()) Throw.ShouldBeRequired(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotBeRequiredAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsRequiredAsync().ConfigureAwait(false)) Throw.ShouldNotBeRequired(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotBeRequired(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.IsRequired()) Throw.ShouldNotBeRequired(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static void ShouldNotBeRequired(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.IsRequired()) Throw.ShouldNotBeRequired(elementHandleTask, message);
        }

        // Focus

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static async Task ShouldHaveFocusAsync(this ElementHandle elementHandle, string message = null)
        {
            if (!await elementHandle.HasFocusAsync().ConfigureAwait(false)) Throw.ShouldHaveFocus(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveFocus(this ElementHandle elementHandle, string message = null)
        {
            if (!elementHandle.HasFocus()) Throw.ShouldHaveFocus(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static void ShouldHaveFocus(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (!elementHandleTask.HasFocus()) Throw.ShouldHaveFocus(elementHandleTask, message);
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotHaveFocusAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.HasFocusAsync().ConfigureAwait(false)) Throw.ShouldNotHaveFocus(elementHandle, message);
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveFocus(this ElementHandle elementHandle, string message = null)
        {
            if (elementHandle.HasFocus()) Throw.ShouldNotHaveFocus(elementHandle, message);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static void ShouldNotHaveFocus(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            if (elementHandleTask.HasFocus()) Throw.ShouldNotHaveFocus(elementHandleTask, message);
        }
    }
}
