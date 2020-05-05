using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// <see cref="ElementHandle"/> extension methods.
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
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerHTML</c></returns>
        public static string InnerHtml(this ElementHandle elementHandle)
        {
            return elementHandle.InnerHtmlAsync().Result();
        }

        /// <summary>
        /// InnerHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerHTML</c></returns>
        public static string InnerHtml(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().InnerHtml();
        }

        // OuterHtml

        /// <summary>
        /// OuterHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>outerHTML</c></returns>
        public static string OuterHtml(this ElementHandle elementHandle)
        {
            return elementHandle.OuterHtmlAsync().Result();
        }

        /// <summary>
        /// OuterHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>outerHTML</c></returns>
        public static string OuterHtml(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().OuterHtml();
        }

        // TextContent

        /// <summary>
        /// TextContent of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>textContent</c></returns>
        public static string TextContent(this ElementHandle elementHandle)
        {
            return elementHandle.TextContentAsync().Result();
        }

        /// <summary>
        /// TextContent of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>textContent</c></returns>
        public static string TextContent(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().TextContent();
        }

        // InnerText

        /// <summary>
        /// InnerText of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerText</c></returns>
        public static string InnerText(this ElementHandle elementHandle)
        {
            return elementHandle.InnerTextAsync().Result();
        }

        /// <summary>
        /// InnerText of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerText</c></returns>
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
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        /// <returns><c>true</c> if the element has the specified content</returns>
        public static bool HasContent(this ElementHandle elementHandle, string content)
        {
            return elementHandle.HasContentAsync(content).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        /// <returns><c>true</c> if the element has the specified content</returns>
        public static bool HasContent(this Task<ElementHandle> elementHandleTask, string content)
        {
            return elementHandleTask.GuardFromNull().Result().HasContent(content);
        }

        // ClassName

        /// <summary>
        /// ClassName of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/className
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>className</c></returns>
        public static string ClassName(this ElementHandle elementHandle)
        {
            return elementHandle.ClassNameAsync().Result();
        }

        /// <summary>
        /// ClassName of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/className
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>className</c></returns>
        public static string ClassName(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().ClassName();
        }

        // ClassList

        /// <summary>
        /// ClassList of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/classList
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>classList</c></returns>
        public static string[] ClassList(this ElementHandle elementHandle)
        {
            return elementHandle.ClassListAsync().Result();
        }

        /// <summary>
        /// ClassList of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/classList
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>classList</c></returns>
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
        /// See also https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        public static bool IsVisible(this ElementHandle elementHandle)
        {
            return elementHandle.IsVisibleAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// See also https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
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
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns><c>true</c> if the element is selected</returns>
        public static bool IsSelected(this ElementHandle elementHandle)
        {
            return elementHandle.IsSelectedAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns><c>true</c> if the element is selected</returns>
        public static bool IsSelected(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsSelected();
        }

        // IsChecked

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns><c>true</c> if the element is checked</returns>
        public static bool IsChecked(this ElementHandle elementHandle)
        {
            return elementHandle.IsCheckedAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns><c>true</c> if the element is checked</returns>
        public static bool IsChecked(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsChecked();
        }

        // IsDisabled

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is disabled</returns>
        public static bool IsDisabled(this ElementHandle elementHandle)
        {
            return elementHandle.IsDisabledAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is disabled</returns>
        public static bool IsDisabled(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsDisabled();
        }

        // IsEnabled

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is enabled</returns>
        public static bool IsEnabled(this ElementHandle elementHandle)
        {
            return elementHandle.IsEnabledAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is enabled</returns>
        public static bool IsEnabled(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsEnabled();
        }

        // IsReadOnly

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is read-only</returns>
        public static bool IsReadOnly(this ElementHandle elementHandle)
        {
            return elementHandle.IsReadOnlyAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is read-only</returns>
        public static bool IsReadOnly(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsReadOnly();
        }

        // IsRequired

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is required</returns>
        public static bool IsRequired(this ElementHandle elementHandle)
        {
            return elementHandle.IsRequiredAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is required</returns>
        public static bool IsRequired(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().IsRequired();
        }

        // HasFocus

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element has focus</returns>
        public static bool HasFocus(this ElementHandle elementHandle)
        {
            return elementHandle.HasFocusAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element has focus</returns>
        public static bool HasFocus(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().HasFocus();
        }
    }
}
