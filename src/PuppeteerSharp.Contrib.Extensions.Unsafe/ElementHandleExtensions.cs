using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="ElementHandle"/>.
    /// </summary>
    public static class ElementHandleExtensions
    {
        // Exists

        /// <summary>
        /// Indicates whether the element exists or not. A non null <see cref="ElementHandle"/> is considered existing.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element exists</returns>
        public static bool Exists(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Exists();
        }

        // InnerHtml

        /// <summary>
        /// InnerHtml of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>innerHTML</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML"/>
        public static string InnerHtml(this ElementHandle elementHandle)
        {
            return elementHandle.InnerHtmlAsync().Result();
        }

        /// <summary>
        /// InnerHtml of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>innerHTML</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML"/>
        public static string InnerHtml(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().InnerHtml();
        }

        // OuterHtml

        /// <summary>
        /// OuterHtml of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>outerHTML</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML"/>
        public static string OuterHtml(this ElementHandle elementHandle)
        {
            return elementHandle.OuterHtmlAsync().Result();
        }

        /// <summary>
        /// OuterHtml of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>outerHTML</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML"/>
        public static string OuterHtml(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().OuterHtml();
        }

        // TextContent

        /// <summary>
        /// TextContent of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>textContent</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent"/>
        public static string TextContent(this ElementHandle elementHandle)
        {
            return elementHandle.TextContentAsync().Result();
        }

        /// <summary>
        /// TextContent of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>textContent</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent"/>
        public static string TextContent(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().TextContent();
        }

        // InnerText

        /// <summary>
        /// InnerText of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>innerText</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"/>
        public static string InnerText(this ElementHandle elementHandle)
        {
            return elementHandle.InnerTextAsync().Result();
        }

        /// <summary>
        /// InnerText of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>innerText</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"/>
        public static string InnerText(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().InnerText();
        }

        // HasContent

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <returns><c>true</c> if the element has the specified content</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static bool HasContent(this ElementHandle elementHandle, string content)
        {
            return elementHandle.HasContentAsync(content).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <returns><c>true</c> if the element has the specified content</returns>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        public static bool HasContent(this Task<ElementHandle> elementHandleTask, string content)
        {
            return elementHandleTask.GuardFromNull().Result().HasContent(content);
        }

        // ClassName

        /// <summary>
        /// ClassName of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>className</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/className"/>
        public static string ClassName(this ElementHandle elementHandle)
        {
            return elementHandle.ClassNameAsync().Result();
        }

        /// <summary>
        /// ClassName of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>className</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/className"/>
        public static string ClassName(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().ClassName();
        }

        // ClassList

        /// <summary>
        /// ClassList of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>classList</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/classList"/>
        public static string[] ClassList(this ElementHandle elementHandle)
        {
            return elementHandle.ClassListAsync().Result();
        }

        /// <summary>
        /// ClassList of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>classList</c></returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/classList"/>
        public static string[] ClassList(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().ClassList();
        }

        // HasClass

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <returns><c>true</c> if the element has the specified class</returns>
        public static bool HasClass(this ElementHandle elementHandle, string className)
        {
            return elementHandle.HasClassAsync(className).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <returns><c>true</c> if the element has the specified class</returns>
        public static bool HasClass(this Task<ElementHandle> elementHandleTask, string className)
        {
            return elementHandleTask.GuardFromNull().Result().HasClass(className);
        }

        // IsVisible

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        /// <seealso href="https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled"/>
        public static bool IsVisible(this ElementHandle elementHandle)
        {
            return elementHandle.IsVisibleAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        /// <seealso href="https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled"/>
        public static bool IsVisible(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsVisible();
        }

        // IsHidden

        /// <summary>
        /// Indicates whether the element is hidden or not. This is the logical negation of <see cref="IsVisibleAsync"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is hidden</returns>
        public static bool IsHidden(this ElementHandle elementHandle)
        {
            return elementHandle.IsHiddenAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is hidden or not. This is the logical negation of <see cref="IsVisibleAsync"/>.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is hidden</returns>
        public static bool IsHidden(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsHidden();
        }

        // IsSelected

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is selected</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static bool IsSelected(this ElementHandle elementHandle)
        {
            return elementHandle.IsSelectedAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is selected</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static bool IsSelected(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsSelected();
        }

        // IsChecked

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is checked</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static bool IsChecked(this ElementHandle elementHandle)
        {
            return elementHandle.IsCheckedAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is checked</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static bool IsChecked(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsChecked();
        }

        // IsDisabled

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is disabled</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static bool IsDisabled(this ElementHandle elementHandle)
        {
            return elementHandle.IsDisabledAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is disabled</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static bool IsDisabled(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsDisabled();
        }

        // IsEnabled

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is enabled</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static bool IsEnabled(this ElementHandle elementHandle)
        {
            return elementHandle.IsEnabledAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is enabled</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static bool IsEnabled(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsEnabled();
        }

        // IsReadOnly

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is read-only</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static bool IsReadOnly(this ElementHandle elementHandle)
        {
            return elementHandle.IsReadOnlyAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is read-only</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static bool IsReadOnly(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsReadOnly();
        }

        // IsRequired

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is required</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static bool IsRequired(this ElementHandle elementHandle)
        {
            return elementHandle.IsRequiredAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is required</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static bool IsRequired(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsRequired();
        }

        // HasFocus

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element has focus</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement"/>
        public static bool HasFocus(this ElementHandle elementHandle)
        {
            return elementHandle.HasFocusAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element has focus</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement"/>
        public static bool HasFocus(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().HasFocus();
        }
    }
}
