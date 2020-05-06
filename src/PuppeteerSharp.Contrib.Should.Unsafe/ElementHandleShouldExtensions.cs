using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// Unsafe should assertions for <see cref="ElementHandle"/>.
    /// </summary>
    public static class ElementHandleShouldExtensions
    {
        // Exist

        /// <summary>
        /// Asserts that the element exists.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldExist(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            elementHandleTask.Result().ShouldExist(message);
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldNotExist(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            elementHandleTask.Result().ShouldNotExist(message);
        }

        // Value

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
            elementHandle.ShouldHaveValueAsync(value, message).Result();

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
            elementHandleTask.Result().ShouldHaveValueAsync(value, message).Result();
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
            elementHandle.ShouldNotHaveValueAsync(value, message).Result();

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
            elementHandleTask.Result().ShouldNotHaveValueAsync(value, message).Result();
        }

        // Attribute

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveAttribute(this ElementHandle elementHandle, string name, string message = null)
        {
            elementHandle.ShouldHaveAttributeAsync(name, message).Result();

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
            elementHandleTask.Result().ShouldHaveAttributeAsync(name, message).Result();
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
            elementHandle.ShouldNotHaveAttributeAsync(name, message).Result();

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
            elementHandleTask.Result().ShouldNotHaveAttributeAsync(name, message).Result();
        }

        // Content

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
            elementHandle.ShouldHaveContentAsync(content, message).Result();

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
            elementHandleTask.Result().ShouldHaveContentAsync(content, message).Result();
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
            elementHandle.ShouldNotHaveContentAsync(content, message).Result();

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
            elementHandleTask.Result().ShouldNotHaveContentAsync(content, message).Result();
        }

        // Class

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveClass(this ElementHandle elementHandle, string className, string message = null)
        {
            elementHandle.ShouldHaveClassAsync(className, message).Result();

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
            elementHandleTask.Result().ShouldHaveClassAsync(className, message).Result();
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
            elementHandle.ShouldNotHaveClassAsync(className, message).Result();

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
            elementHandleTask.Result().ShouldNotHaveClassAsync(className, message).Result();
        }

        // Visible

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeVisible(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeVisibleAsync(message).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldBeVisible(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            elementHandleTask.Result().ShouldBeVisibleAsync(message).Result();
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeHidden(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeHiddenAsync(message).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        public static void ShouldBeHidden(this Task<ElementHandle> elementHandleTask, string message = null)
        {
            elementHandleTask.Result().ShouldBeHiddenAsync(message).Result();
        }

        // Selected

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeSelected(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeSelectedAsync(message).Result();

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
            elementHandleTask.Result().ShouldBeSelectedAsync(message).Result();
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
            elementHandle.ShouldNotBeSelectedAsync(message).Result();

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
            elementHandleTask.Result().ShouldNotBeSelectedAsync(message).Result();
        }

        // Checked

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeChecked(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeCheckedAsync(message).Result();

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
            elementHandleTask.Result().ShouldBeCheckedAsync(message).Result();
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
            elementHandle.ShouldNotBeCheckedAsync(message).Result();

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
            elementHandleTask.Result().ShouldNotBeCheckedAsync(message).Result();
        }

        // Disabled

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeDisabled(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeDisabledAsync(message).Result();

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
            elementHandleTask.Result().ShouldBeDisabledAsync(message).Result();
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
            elementHandle.ShouldBeEnabledAsync(message).Result();

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
            elementHandleTask.Result().ShouldBeEnabledAsync(message).Result();
        }

        // ReadOnly

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeReadOnly(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeReadOnlyAsync(message).Result();

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
            elementHandleTask.Result().ShouldBeReadOnlyAsync(message).Result();
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
            elementHandle.ShouldNotBeReadOnlyAsync(message).Result();

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
            elementHandleTask.Result().ShouldNotBeReadOnlyAsync(message).Result();
        }

        // Required

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeRequired(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldBeRequiredAsync(message).Result();

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
            elementHandleTask.Result().ShouldBeRequiredAsync(message).Result();
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
            elementHandle.ShouldNotBeRequiredAsync(message).Result();

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
            elementHandleTask.Result().ShouldNotBeRequiredAsync(message).Result();
        }

        // Focus

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="message">Optional failure message</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveFocus(this ElementHandle elementHandle, string message = null)
        {
            elementHandle.ShouldHaveFocusAsync(message).Result();

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
            elementHandleTask.Result().ShouldHaveFocusAsync(message).Result();
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
            elementHandle.ShouldNotHaveFocusAsync(message).Result();

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
            elementHandleTask.Result().ShouldNotHaveFocusAsync(message).Result();
        }
    }
}
