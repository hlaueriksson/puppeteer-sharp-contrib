using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// Should assertions for <see cref="ElementHandle"/>.
    /// </summary>
    public static class ElementHandleShouldExtensions
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
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeHiddenAsync(this ElementHandle elementHandle, string message = null)
        {
            if (await elementHandle.IsVisibleAsync().ConfigureAwait(false)) Throw.ShouldBeHidden(elementHandle, message);
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
    }
}
