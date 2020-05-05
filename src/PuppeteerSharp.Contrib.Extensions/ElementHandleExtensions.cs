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
        /// <summary>
        /// The method runs <c>element.querySelectorAll</c> and then tests a <c>RegExp</c> against the elements <c>textContent</c>. The first element match is returned. If no element matches the selector and regular expression, the return value resolve to <c>null</c>.
        /// See also https://stackoverflow.com/a/37098508
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/> to query</param>
        /// <param name="selector">A selector to query element for</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c></param>
        /// <returns>Task which resolves to <see cref="ElementHandle"/> pointing to the element</returns>
        public static async Task<ElementHandle> QuerySelectorWithContentAsync(this ElementHandle elementHandle, string selector, string regex)
        {
            return await elementHandle.GuardFromNull().EvaluateFunctionHandleAsync(
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
        /// <param name="elementHandle">An <see cref="ElementHandle"/> to query</param>
        /// <param name="selector">A selector to query element for</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c></param>
        /// <returns>Task which resolves to ElementHandles pointing to the elements</returns>
        public static async Task<ElementHandle[]> QuerySelectorAllWithContentAsync(this ElementHandle elementHandle, string selector, string regex)
        {
            var arrayHandle = await elementHandle.GuardFromNull().EvaluateFunctionHandleAsync(
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

        /// <summary>
        /// Indicates whether the element exists or not. A non null <see cref="ElementHandle"/> is considered existing.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element exists</returns>
        public static bool Exists(this ElementHandle elementHandle)
        {
            return elementHandle != null;
        }

        /// <summary>
        /// InnerHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerHTML</c></returns>
        public static async Task<string> InnerHtmlAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("innerHTML").ConfigureAwait(false);
        }

        /// <summary>
        /// OuterHtml of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>outerHTML</c></returns>
        public static async Task<string> OuterHtmlAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("outerHTML").ConfigureAwait(false);
        }

        /// <summary>
        /// TextContent of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>textContent</c></returns>
        public static async Task<string> TextContentAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("textContent").ConfigureAwait(false);
        }

        /// <summary>
        /// InnerText of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>innerText</c></returns>
        public static async Task<string> InnerTextAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("innerText").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="content">The content</param>
        /// <remarks>Evaluates <c>node.textContent</c></remarks>
        /// <returns><c>true</c> if the element has the specified content</returns>
        public static async Task<bool> HasContentAsync(this ElementHandle elementHandle, string content)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("(node, content) => node.textContent.includes(content)", content).ConfigureAwait(false);
        }

        /// <summary>
        /// ClassName of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/className
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>className</c></returns>
        public static async Task<string> ClassNameAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<string>("element => element.className").ConfigureAwait(false);
        }

        /// <summary>
        /// ClassList of the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/classList
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>classList</c></returns>
        public static async Task<string[]> ClassListAsync(this ElementHandle elementHandle)
        {
            var json = await elementHandle.EvaluateFunctionWithoutDisposeAsync<JObject>("element => element.classList").ConfigureAwait(false);
            var dictionary = json.ToObject<Dictionary<string, string>>();
            return dictionary.Values.ToArray();
        }

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="className">The class name</param>
        /// <returns><c>true</c> if the element has the specified class</returns>
        public static async Task<bool> HasClassAsync(this ElementHandle elementHandle, string className)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("(element, className) => element.classList.contains(className)", className).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is visible or not.
        /// See also https://blog.jquery.com/2009/02/20/jquery-1-3-2-released/#visible-hidden-overhauled
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is visible</returns>
        public static async Task<bool> IsVisibleAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.offsetWidth > 0 && element.offsetHeight > 0").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is hidden or not. This is the logical negation of <see cref="IsVisibleAsync"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns><c>true</c> if the element is hidden</returns>
        public static async Task<bool> IsHiddenAsync(this ElementHandle elementHandle)
        {
            return !await elementHandle.IsVisibleAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        /// <returns><c>true</c> if the element is selected</returns>
        public static async Task<bool> IsSelectedAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.selected").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        /// <returns><c>true</c> if the element is checked</returns>
        public static async Task<bool> IsCheckedAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.checked").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is disabled</returns>
        public static async Task<bool> IsDisabledAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.disabled").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is enabled</returns>
        public static async Task<bool> IsEnabledAsync(this ElementHandle elementHandle)
        {
            return !await elementHandle.IsDisabledAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is read-only</returns>
        public static async Task<bool> IsReadOnlyAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.readOnly").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element is required</returns>
        public static async Task<bool> IsRequiredAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element.required").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <returns><c>true</c> if the element has focus</returns>
        public static async Task<bool> HasFocusAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("element => element === document.activeElement").ConfigureAwait(false);
        }

        private static async Task<string> GetPropertyValueAsync(this ElementHandle elementHandle, string propertyName)
        {
            var property = await elementHandle.GuardFromNull().GetPropertyAsync(propertyName).ConfigureAwait(false);
            return await property.JsonValueAsync<string>().ConfigureAwait(false);
        }
    }
}
