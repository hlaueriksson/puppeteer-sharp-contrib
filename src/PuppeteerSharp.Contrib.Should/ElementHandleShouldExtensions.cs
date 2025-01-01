using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// Should assertions for <see cref="IElementHandle"/>.
    /// </summary>
    public static class ElementHandleShouldExtensions
    {
        // Exist

        /// <summary>
        /// Asserts that the element exists.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IElementHandle"/> for method chaining.</returns>
        public static IElementHandle ShouldExist(this IElementHandle elementHandle, string? because = null)
        {
            if (!elementHandle.Exists()) Throw.ElementShouldExist(because);

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="IElementHandle"/> for method chaining.</returns>
        public static IElementHandle ShouldNotExist(this IElementHandle elementHandle, string? because = null)
        {
            if (elementHandle.Exists()) Throw.ElementShouldNotExist(because);

            return elementHandle;
        }

        // Value

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="value">The value.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <data>, <input>, <li>, <meter>, <option>, <progress>, <param>]]></remarks>
        public static async Task ShouldHaveValueAsync(this IElementHandle elementHandle, string value, string? because = null)
        {
            var actual = await elementHandle.ValueAsync().ConfigureAwait(false);

            if (actual != value) Throw.ElementShouldHaveValue(value, actual, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="value">The value.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <data>, <input>, <li>, <meter>, <option>, <progress>, <param>]]></remarks>
        public static async Task ShouldNotHaveValueAsync(this IElementHandle elementHandle, string value, string? because = null)
        {
            if (await elementHandle.ValueAsync().ConfigureAwait(false) == value) Throw.ElementShouldNotHaveValue(value, because);
        }

        // Attribute

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldHaveAttributeAsync(this IElementHandle elementHandle, string name, string? because = null)
        {
            if (!await elementHandle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ElementShouldHaveAttribute(name, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldNotHaveAttributeAsync(this IElementHandle elementHandle, string name, string? because = null)
        {
            if (await elementHandle.HasAttributeAsync(name).ConfigureAwait(false)) Throw.ElementShouldNotHaveAttribute(name, because);
        }

        // AttributeValue

        /// <summary>
        /// Asserts that the element has the specified attribute value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="regex">A regular expression to test against <c>element.getAttribute(name)</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldHaveAttributeValueAsync(this IElementHandle elementHandle, string name, string regex, string flags = "", string? because = null)
        {
            if (!await elementHandle.HasAttributeValueAsync(name, regex, flags).ConfigureAwait(false)) Throw.ElementShouldHaveAttributeValue(name, regex, flags, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <param name="regex">A regular expression to test against <c>element.getAttribute(name)</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldNotHaveAttributeValueAsync(this IElementHandle elementHandle, string name, string regex, string flags = "", string? because = null)
        {
            if (await elementHandle.HasAttributeValueAsync(name, regex, flags).ConfigureAwait(false)) Throw.ElementShouldNotHaveAttributeValue(name, regex, flags, because);
        }

        // Content

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldHaveContentAsync(this IElementHandle elementHandle, string regex, string flags = "", string? because = null)
        {
            if (!await elementHandle.HasContentAsync(regex, flags).ConfigureAwait(false)) Throw.ElementShouldHaveContent(regex, flags, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task ShouldNotHaveContentAsync(this IElementHandle elementHandle, string regex, string flags = "", string? because = null)
        {
            if (await elementHandle.HasContentAsync(regex, flags).ConfigureAwait(false)) Throw.ElementShouldNotHaveContent(regex, flags, because);
        }

        // Class

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="className">The class name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldHaveClassAsync(this IElementHandle elementHandle, string className, string? because = null)
        {
            if (!await elementHandle.HasClassAsync(className).ConfigureAwait(false)) Throw.ElementShouldHaveClass(className, because);
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="className">The class name.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldNotHaveClassAsync(this IElementHandle elementHandle, string className, string? because = null)
        {
            if (await elementHandle.HasClassAsync(className).ConfigureAwait(false)) Throw.ElementShouldNotHaveClass(className, because);
        }

        // Visible

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeVisibleAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.GuardFromNull().IsHiddenAsync().ConfigureAwait(false)) Throw.ElementShouldBeVisible(because);
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task ShouldBeHiddenAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.GuardFromNull().IsVisibleAsync().ConfigureAwait(false)) Throw.ElementShouldBeHidden(because);
        }

        // Selected

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldBeSelectedAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsSelectedAsync().ConfigureAwait(false)) Throw.ElementShouldBeSelected(because);
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task ShouldNotBeSelectedAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsSelectedAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeSelected(because);
        }

        // Checked

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>]]></remarks>
        public static async Task ShouldBeCheckedAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsCheckedAsync().ConfigureAwait(false)) Throw.ElementShouldBeChecked(because);
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>]]></remarks>
        public static async Task ShouldNotBeCheckedAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsCheckedAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeChecked(because);
        }

        // Disabled

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <fieldset>, <input>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeDisabledAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsEnabledAsync().ConfigureAwait(false)) Throw.ElementShouldBeDisabled(because);
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <fieldset>, <input>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeEnabledAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsDisabledAsync().ConfigureAwait(false)) Throw.ElementShouldBeEnabled(because);
        }

        // ReadOnly

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldBeReadOnlyAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ElementShouldBeReadOnly(because);
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldNotBeReadOnlyAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsReadOnlyAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeReadOnly(because);
        }

        // Required

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldBeRequiredAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsRequiredAsync().ConfigureAwait(false)) Throw.ElementShouldBeRequired(because);
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotBeRequiredAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsRequiredAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeRequired(because);
        }

        // Focus

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldHaveFocusAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.HasFocusAsync().ConfigureAwait(false)) Throw.ElementShouldHaveFocus(because);
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <select>, <textarea>]]></remarks>
        public static async Task ShouldNotHaveFocusAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.HasFocusAsync().ConfigureAwait(false)) Throw.ElementShouldNotHaveFocus(because);
        }

        // Empty

        /// <summary>
        /// Asserts that the element is empty, e.g. an empty editable element or a DOM node that has no text.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldBeEmptyAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (!await elementHandle.IsEmptyAsync().ConfigureAwait(false)) Throw.ElementShouldBeEmpty(because);
        }

        /// <summary>
        /// Asserts that the element is not empty, e.g. an non empty editable element or a DOM node that has text.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task ShouldNotBeEmptyAsync(this IElementHandle elementHandle, string? because = null)
        {
            if (await elementHandle.IsEmptyAsync().ConfigureAwait(false)) Throw.ElementShouldNotBeEmpty(because);
        }
    }
}
