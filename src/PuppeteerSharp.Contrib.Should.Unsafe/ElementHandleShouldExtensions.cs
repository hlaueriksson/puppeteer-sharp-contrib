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
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldExist(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldExist(because);
        }

        /// <summary>
        /// Asserts that the element does not exist.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldNotExist(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldNotExist(because);
        }

        // Value

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static ElementHandle ShouldHaveValue(this ElementHandle elementHandle, string value, string because = null)
        {
            elementHandle.ShouldHaveValueAsync(value, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified value.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static void ShouldHaveValue(this Task<ElementHandle> elementHandleTask, string value, string because = null)
        {
            elementHandleTask.Result().ShouldHaveValueAsync(value, because).Result();
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static ElementHandle ShouldNotHaveValue(this ElementHandle elementHandle, string value, string because = null)
        {
            elementHandle.ShouldNotHaveValueAsync(value, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified value.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="value">The value</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static void ShouldNotHaveValue(this Task<ElementHandle> elementHandleTask, string value, string because = null)
        {
            elementHandleTask.Result().ShouldNotHaveValueAsync(value, because).Result();
        }

        // Attribute

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveAttribute(this ElementHandle elementHandle, string name, string because = null)
        {
            elementHandle.ShouldHaveAttributeAsync(name, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified attribute.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldHaveAttribute(this Task<ElementHandle> elementHandleTask, string name, string because = null)
        {
            elementHandleTask.Result().ShouldHaveAttributeAsync(name, because).Result();
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveAttribute(this ElementHandle elementHandle, string name, string because = null)
        {
            elementHandle.ShouldNotHaveAttributeAsync(name, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified attribute.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldNotHaveAttribute(this Task<ElementHandle> elementHandleTask, string name, string because = null)
        {
            elementHandleTask.Result().ShouldNotHaveAttributeAsync(name, because).Result();
        }

        // Content

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static ElementHandle ShouldHaveContent(this ElementHandle elementHandle, string content, string because = null)
        {
            elementHandle.ShouldHaveContentAsync(content, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified content.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static void ShouldHaveContent(this Task<ElementHandle> elementHandleTask, string content, string because = null)
        {
            elementHandleTask.Result().ShouldHaveContentAsync(content, because).Result();
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static ElementHandle ShouldNotHaveContent(this ElementHandle elementHandle, string content, string because = null)
        {
            elementHandle.ShouldNotHaveContentAsync(content, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified content.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static void ShouldNotHaveContent(this Task<ElementHandle> elementHandleTask, string content, string because = null)
        {
            elementHandleTask.Result().ShouldNotHaveContentAsync(content, because).Result();
        }

        // Class

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldHaveClass(this ElementHandle elementHandle, string className, string because = null)
        {
            elementHandle.ShouldHaveClassAsync(className, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has the specified class.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldHaveClass(this Task<ElementHandle> elementHandleTask, string className, string because = null)
        {
            elementHandleTask.Result().ShouldHaveClassAsync(className, because).Result();
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldNotHaveClass(this ElementHandle elementHandle, string className, string because = null)
        {
            elementHandle.ShouldNotHaveClassAsync(className, because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have the specified class.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldNotHaveClass(this Task<ElementHandle> elementHandleTask, string className, string because = null)
        {
            elementHandleTask.Result().ShouldNotHaveClassAsync(className, because).Result();
        }

        // Visible

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeVisible(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeVisibleAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is visible.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldBeVisible(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeVisibleAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        public static ElementHandle ShouldBeHidden(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeHiddenAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is hidden.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        public static void ShouldBeHidden(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeHiddenAsync(because).Result();
        }

        // Selected

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static ElementHandle ShouldBeSelected(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeSelectedAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is selected.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static void ShouldBeSelected(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeSelectedAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static ElementHandle ShouldNotBeSelected(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldNotBeSelectedAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not selected.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static void ShouldNotBeSelected(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldNotBeSelectedAsync(because).Result();
        }

        // Checked

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static ElementHandle ShouldBeChecked(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeCheckedAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is checked.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static void ShouldBeChecked(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeCheckedAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static ElementHandle ShouldNotBeChecked(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldNotBeCheckedAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not checked.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static void ShouldNotBeChecked(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldNotBeCheckedAsync(because).Result();
        }

        // Disabled

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static ElementHandle ShouldBeDisabled(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeDisabledAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is disabled.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static void ShouldBeDisabled(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeDisabledAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static ElementHandle ShouldBeEnabled(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeEnabledAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is enabled.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static void ShouldBeEnabled(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeEnabledAsync(because).Result();
        }

        // ReadOnly

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static ElementHandle ShouldBeReadOnly(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeReadOnlyAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is read-only.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static void ShouldBeReadOnly(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeReadOnlyAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static ElementHandle ShouldNotBeReadOnly(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldNotBeReadOnlyAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not read-only.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static void ShouldNotBeReadOnly(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldNotBeReadOnlyAsync(because).Result();
        }

        // Required

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static ElementHandle ShouldBeRequired(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldBeRequiredAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is required.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static void ShouldBeRequired(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldBeRequiredAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static ElementHandle ShouldNotBeRequired(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldNotBeRequiredAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element is not required.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static void ShouldNotBeRequired(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldNotBeRequiredAsync(because).Result();
        }

        // Focus

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static ElementHandle ShouldHaveFocus(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldHaveFocusAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element has focus.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static void ShouldHaveFocus(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldHaveFocusAsync(because).Result();
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <returns>The <see cref="ElementHandle"/> for method chaining</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static ElementHandle ShouldNotHaveFocus(this ElementHandle elementHandle, string because = null)
        {
            elementHandle.ShouldNotHaveFocusAsync(because).Result();

            return elementHandle;
        }

        /// <summary>
        /// Asserts that the element does not have focus.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="because">A phrase explaining why the assertion is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.</param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        public static void ShouldNotHaveFocus(this Task<ElementHandle> elementHandleTask, string because = null)
        {
            elementHandleTask.Result().ShouldNotHaveFocusAsync(because).Result();
        }
    }
}
