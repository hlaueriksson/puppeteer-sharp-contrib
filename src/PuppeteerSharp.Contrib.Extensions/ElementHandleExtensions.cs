using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// <see cref="ElementHandle"/> extension methods.
    /// </summary>
    public static class ElementHandleExtensions
    {
        // Query

        /// <summary>
        /// The method runs <c>element.querySelectorAll</c> and then tests a <c>RegExp</c> against the elements <c>textContent</c>. The first element match is returned. If no element matches the selector and regular expression, the return value resolve to <c>null</c>.
        /// See also https://stackoverflow.com/a/37098508
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/> to query</param>
        /// <param name="selector">A selector to query element for</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c></param>
        /// <returns>Task which resolves to <see cref="ElementHandle"/> pointing to the element</returns>
        public static async Task<ElementHandle> QuerySelectorWithContentAsync(this ElementHandle handle, string selector, string regex)
        {
            return await handle.EvaluateFunctionHandleAsync(
                @"(element, selector, regex) => {
                    var elements = element.querySelectorAll(selector);
                    return Array.prototype.find.call(elements, function(element) {
                        return RegExp(regex).test(element.textContent);
                    });
                }", selector, regex).ConfigureAwait(false) as ElementHandle;
        }

        /// <summary>
        /// The method runs <c>element.querySelectorAll</c> and then tests a <c>RegExp</c> against the elements <c>textContent</c>. All element matches are returned. If no element matches the selector and regular expression, the return value resolve to <see cref="System.Array.Empty{T}"/>.
        /// See also https://stackoverflow.com/a/37098508
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/> to query</param>
        /// <param name="selector">A selector to query element for</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c></param>
        /// <returns>Task which resolves to ElementHandles pointing to the elements</returns>
        public static async Task<ElementHandle[]> QuerySelectorAllWithContentAsync(this ElementHandle handle, string selector, string regex)
        {
            var arrayHandle = await handle.EvaluateFunctionHandleAsync(
                @"(element, selector, regex) => {
                    var elements = element.querySelectorAll(selector);
                    return Array.prototype.filter.call(elements, function(element) {
                        return RegExp(regex).test(element.textContent);
                    });
                }", selector, regex).ConfigureAwait(false);

            if (arrayHandle == null) throw new InvalidOperationException("EvaluateFunctionHandleAsync returned null.");

            var properties = await arrayHandle.GetPropertiesAsync().ConfigureAwait(false);
            await arrayHandle.DisposeAsync().ConfigureAwait(false);

            return properties.Values.OfType<ElementHandle>().ToArray();
        }

        // Exists

        /// <summary>
        /// Indicates whether the element exists or not. A non null <see cref="ElementHandle"/> is considered existing.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element exists</returns>
        public static bool Exists(this ElementHandle handle)
        {
            return handle != null;
        }

        /// <summary>
        /// Indicates whether the element exists or not. A non null <see cref="ElementHandle"/> is considered existing.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element exists</returns>
        public static bool Exists(this Task<ElementHandle> task)
        {
            return task.Result().Exists();
        }

        // InnerHtml

        /// <summary>
        /// InnerHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerHTML</c></returns>
        public static async Task<string> InnerHtmlAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("innerHTML").ConfigureAwait(false);
        }

        /// <summary>
        /// InnerHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerHTML</c></returns>
        public static string InnerHtml(this ElementHandle handle)
        {
            return handle.InnerHtmlAsync().Result();
        }

        /// <summary>
        /// InnerHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerHTML</c></returns>
        public static string InnerHtml(this Task<ElementHandle> task)
        {
            return task.Result().InnerHtml();
        }

        // OuterHtml

        /// <summary>
        /// OuterHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>outerHTML</c></returns>
        public static async Task<string> OuterHtmlAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("outerHTML").ConfigureAwait(false);
        }

        /// <summary>
        /// OuterHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>outerHTML</c></returns>
        public static string OuterHtml(this ElementHandle handle)
        {
            return handle.OuterHtmlAsync().Result();
        }

        /// <summary>
        /// OuterHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>outerHTML</c></returns>
        public static string OuterHtml(this Task<ElementHandle> task)
        {
            return task.Result().OuterHtml();
        }

        // TextContent

        /// <summary>
        /// TextContent of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>textContent</c></returns>
        public static async Task<string> TextContentAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("textContent").ConfigureAwait(false);
        }

        /// <summary>
        /// TextContent of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>textContent</c></returns>
        public static string TextContent(this ElementHandle handle)
        {
            return handle.TextContentAsync().Result();
        }

        /// <summary>
        /// TextContent of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>textContent</c></returns>
        public static string TextContent(this Task<ElementHandle> task)
        {
            return task.Result().TextContent();
        }

        // InnerText

        /// <summary>
        /// InnerText of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerText</c></returns>
        public static async Task<string> InnerTextAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("innerText").ConfigureAwait(false);
        }

        /// <summary>
        /// InnerText of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerText</c></returns>
        public static string InnerText(this ElementHandle handle)
        {
            return handle.InnerTextAsync().Result();
        }

        /// <summary>
        /// InnerText of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerText</c></returns>
        public static string InnerText(this Task<ElementHandle> task)
        {
            return task.Result().InnerText();
        }

        // HasContent

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        /// <returns><c>true</c> if the element has the specified content</returns>
        public static async Task<bool> HasContentAsync(this ElementHandle handle, string content)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("(node, content) => node.textContent.includes(content)", content).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        /// <returns><c>true</c> if the element has the specified content</returns>
        public static bool HasContent(this ElementHandle handle, string content)
        {
            return handle.HasContentAsync(content).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        /// <returns><c>true</c> if the element has the specified content</returns>
        public static bool HasContent(this Task<ElementHandle> task, string content)
        {
            return task.Result().HasContent(content);
        }

        // ClassName

        /// <summary>
        /// ClassName of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/className
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>className</c></returns>
        public static async Task<string> ClassNameAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<string>("element => element.className").ConfigureAwait(false);
        }

        /// <summary>
        /// ClassName of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/className
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>className</c></returns>
        public static string ClassName(this ElementHandle handle)
        {
            return handle.ClassNameAsync().Result();
        }

        /// <summary>
        /// ClassName of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/className
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>className</c></returns>
        public static string ClassName(this Task<ElementHandle> task)
        {
            return task.Result().ClassName();
        }

        // ClassList

        /// <summary>
        /// ClassList of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/classList
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>classList</c></returns>
        public static async Task<string[]> ClassListAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            var json = await handle.EvaluateFunctionWithoutDisposeAsync<JObject>("element => element.classList").ConfigureAwait(false);
            var dictionary = json.ToObject<Dictionary<string, string>>();
            return dictionary.Values.ToArray();
        }

        /// <summary>
        /// ClassList of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/classList
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>classList</c></returns>
        public static string[] ClassList(this ElementHandle handle)
        {
            return handle.ClassListAsync().Result();
        }

        /// <summary>
        /// ClassList of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/classList
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>classList</c></returns>
        public static string[] ClassList(this Task<ElementHandle> task)
        {
            return task.Result().ClassList();
        }

        // HasClass

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <returns><c>true</c> if the element has the specified class</returns>
        public static async Task<bool> HasClassAsync(this ElementHandle handle, string className)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("(element, className) => element.classList.contains(className)", className).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <returns><c>true</c> if the element has the specified class</returns>
        public static bool HasClass(this ElementHandle handle, string className)
        {
            return handle.HasClassAsync(className).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <returns><c>true</c> if the element has the specified class</returns>
        public static bool HasClass(this Task<ElementHandle> task, string className)
        {
            return task.Result().HasClass(className);
        }

        // IsVisible

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// See also https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        public static async Task<bool> IsVisibleAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.offsetWidth > 0 && element.offsetHeight > 0").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// See also https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        public static bool IsVisible(this ElementHandle handle)
        {
            return handle.IsVisibleAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// See also https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        public static bool IsVisible(this Task<ElementHandle> task)
        {
            return task.Result().IsVisible();
        }

        // IsHidden

        /// <summary>
        /// Indicates whether the element is hidden or not. This is the logical negation of <see cref="IsVisibleAsync"/>.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is hidden</returns>
        public static async Task<bool> IsHiddenAsync(this ElementHandle handle)
        {
            return !await handle.IsVisibleAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is hidden or not. This is the logical negation of <see cref="IsVisibleAsync"/>.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is hidden</returns>
        public static bool IsHidden(this ElementHandle handle)
        {
            return handle.IsHiddenAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is hidden or not. This is the logical negation of <see cref="IsVisibleAsync"/>.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is hidden</returns>
        public static bool IsHidden(this Task<ElementHandle> task)
        {
            return task.Result().IsHidden();
        }

        // IsSelected

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns><c>true</c> if the element is selected</returns>
        public static async Task<bool> IsSelectedAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.selected").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns><c>true</c> if the element is selected</returns>
        public static bool IsSelected(this ElementHandle handle)
        {
            return handle.IsSelectedAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns><c>true</c> if the element is selected</returns>
        public static bool IsSelected(this Task<ElementHandle> task)
        {
            return task.Result().IsSelected();
        }

        // IsChecked

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns><c>true</c> if the element is checked</returns>
        public static async Task<bool> IsCheckedAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.checked").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns><c>true</c> if the element is checked</returns>
        public static bool IsChecked(this ElementHandle handle)
        {
            return handle.IsCheckedAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns><c>true</c> if the element is checked</returns>
        public static bool IsChecked(this Task<ElementHandle> task)
        {
            return task.Result().IsChecked();
        }

        // IsDisabled

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is disabled</returns>
        public static async Task<bool> IsDisabledAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.disabled").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is disabled</returns>
        public static bool IsDisabled(this ElementHandle handle)
        {
            return handle.IsDisabledAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is disabled</returns>
        public static bool IsDisabled(this Task<ElementHandle> task)
        {
            return task.Result().IsDisabled();
        }

        // IsEnabled

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is enabled</returns>
        public static async Task<bool> IsEnabledAsync(this ElementHandle handle)
        {
            return !await handle.IsDisabledAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is enabled</returns>
        public static bool IsEnabled(this ElementHandle handle)
        {
            return handle.IsEnabledAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is enabled</returns>
        public static bool IsEnabled(this Task<ElementHandle> task)
        {
            return task.Result().IsEnabled();
        }

        // IsReadOnly

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is read-only</returns>
        public static async Task<bool> IsReadOnlyAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.readOnly").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is read-only</returns>
        public static bool IsReadOnly(this ElementHandle handle)
        {
            return handle.IsReadOnlyAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is read-only</returns>
        public static bool IsReadOnly(this Task<ElementHandle> task)
        {
            return task.Result().IsReadOnly();
        }

        // IsRequired

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is required</returns>
        public static async Task<bool> IsRequiredAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.required").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is required</returns>
        public static bool IsRequired(this ElementHandle handle)
        {
            return handle.IsRequiredAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is required</returns>
        public static bool IsRequired(this Task<ElementHandle> task)
        {
            return task.Result().IsRequired();
        }

        // HasFocus

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element has focus</returns>
        public static async Task<bool> HasFocusAsync(this ElementHandle handle)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element === document.activeElement").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element has focus</returns>
        public static bool HasFocus(this ElementHandle handle)
        {
            return handle.HasFocusAsync().Result();
        }

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element has focus</returns>
        public static bool HasFocus(this Task<ElementHandle> task)
        {
            return task.Result().HasFocus();
        }

        // GetPropertyValue

        private static async Task<string> GetPropertyValueAsync(this ElementHandle handle, string propertyName)
        {
            handle.GuardFromNull();
            var property = await handle.GetPropertyAsync(propertyName).ConfigureAwait(false);
            return await property.JsonValueAsync<string>().ConfigureAwait(false);
        }

        private static string GetPropertyValue(this ElementHandle handle, string propertyName)
        {
            return handle.GetPropertyValueAsync(propertyName).Result();
        }

        private static string GetPropertyValue(this Task<ElementHandle> task, string propertyName)
        {
            return task.Result().GetPropertyValue(propertyName);
        }
    }
}