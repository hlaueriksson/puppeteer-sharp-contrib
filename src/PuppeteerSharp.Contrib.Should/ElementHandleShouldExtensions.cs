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
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining.</returns>
        public static ElementHandle ShouldExist(this ElementHandle elementHandle, string? because = null)
        {
            if (!elementHandle.Exists()) Throw.ElementShouldExist(because);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining.</returns>
        public static ElementHandle ShouldNotExist(this ElementHandle elementHandle, string? because = null)
        {
            if (elementHandle.Exists()) Throw.ElementShouldNotExist(because);

            return elementHandle;
        }

        // Value

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="value">The value.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task ShouldHaveValueAsync(this ElementHandle elementHandle, string value, string? because = null)
        {
            var actual = await elementHandle.ValueAsync().ConfigureAwait(false);

            if (actual != value) Throw.ElementShouldHaveValue(value, actual, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="value">The value.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task ShouldNotHaveValueAsync(this ElementHandle elementHandle, string value, string? because = null)
        {
            if (await elementHandle.ValueAsync().ConfigureAwait(false) == value) Throw.ElementShouldNotHaveValue(value, because);
        }

        // Attribute

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldHaveAttributeAsync(this ElementHandle elementHandle, string name, string? because = null)
        {
            if (!await elementHandle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ElementShouldHaveAttribute(name, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldNotHaveAttributeAsync(this ElementHandle elementHandle, string name, string? because = null)
        {
            if (await elementHandle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ElementShouldNotHaveAttribute(name, because);
        }

        // Content

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldHaveContentAsync(this ElementHandle elementHandle, string regex, string flags = "", string? because = null)
        {
            if (!await elementHandle.HasContentAsync(regex, flags).ConfigureAwait(false)) Throw.ElementShouldHaveContent(regex, flags, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldNotHaveContentAsync(this ElementHandle elementHandle, string regex, string flags = "", string? because = null)
        {
            if (await elementHandle.HasContentAsync(regex, flags).ConfigureAwait(false)) Throw.ElementShouldNotHaveContent(regex, flags, because);
        }

        // Class

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="className">The class name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldHaveClassAsync(this ElementHandle elementHandle, string className, string? because = null)
        {
            if (!await elementHandle.HasClassAsync(className).ConfigureAwait(false)) Throw.ElementShouldHaveClass(className, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="className">The class name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldNotHaveClassAsync(this ElementHandle elementHandle, string className, string? because = null)
        {
            if (await elementHandle.HasClassAsync(className).ConfigureAwait(false)) Throw.ElementShouldNotHaveClass(className, because);
        }

        // Visible

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeVisibleAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsHiddenAsync().ConfigureAwait(false)) Throw.ElementShouldBeVisible(because);
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeHiddenAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsVisibleAsync().ConfigureAwait(false)) Throw.ElementShouldBeHidden(because);
        }

        // Selected

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldBeSelectedAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsSelectedAsync().ConfigureAwait(false)) Throw.ElementShouldBeSelected(because);
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldNotBeSelectedAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsSelectedAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeSelected(because);
        }

        // Checked

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task ShouldBeCheckedAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsCheckedAsync().ConfigureAwait(false)) Throw.ElementShouldBeChecked(because);
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task ShouldNotBeCheckedAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsCheckedAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeChecked(because);
        }

        // Disabled

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeDisabledAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsEnabledAsync().ConfigureAwait(false)) Throw.ElementShouldBeDisabled(because);
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeEnabledAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsDisabledAsync().ConfigureAwait(false)) Throw.ElementShouldBeEnabled(because);
        }

        // ReadOnly

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldBeReadOnlyAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ElementShouldBeReadOnly(because);
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldNotBeReadOnlyAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeReadOnly(because);
        }

        // Required

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeRequiredAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsRequiredAsync().ConfigureAwait(false)) Throw.ElementShouldBeRequired(because);
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotBeRequiredAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsRequiredAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeRequired(because);
        }

        // Focus

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static async Task ShouldHaveFocusAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.HasFocusAsync().ConfigureAwait(false)) Throw.ElementShouldHaveFocus(because);
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotHaveFocusAsync(this ElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.HasFocusAsync().ConfigureAwait(false)) Throw.ElementShouldNotHaveFocus(because);
        }
    }
}
