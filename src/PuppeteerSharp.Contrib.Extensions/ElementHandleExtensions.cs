using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IElementHandle"/>.
    /// </summary>
    public static class ElementHandleExtensions
    {
        /// <summary>
        /// The method runs <c>element.querySelectorAll</c> and then tests a <c>RegExp</c> against the elements <c>textContent</c>. The first element match is returned. If no element matches the selector and regular expression, the return value resolve to <c>null</c>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/> to query.</param>
        /// <param name="selector">A selector to query element for.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns>Task which resolves to an <see cref="IElementHandle"/> pointing to the element.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<IElementHandle?> QuerySelectorWithContentAsync(this IElementHandle elementHandle, string selector, string regex, string flags = "")
        {
            return await elementHandle.GuardFromNull().EvaluateFunctionHandleAsync(
                @"(element, selector, regex, flags) => {
                    var elements = element.querySelectorAll(selector);
                    return Array.prototype.find.call(elements, function(element) {
                        return RegExp(regex, flags).test(element.textContent);
                    });
                }",
                selector,
                regex,
                flags).ConfigureAwait(false) as IElementHandle;
        }

        /// <summary>
        /// The method runs <c>element.querySelectorAll</c> and then tests a <c>RegExp</c> against the elements <c>textContent</c>. All element matches are returned. If no element matches the selector and regular expression, the return value resolve to <see cref="Array.Empty{T}"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/> to query.</param>
        /// <param name="selector">A selector to query element for.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns>Task which resolves to an <see cref="IElementHandle"/> array pointing to the elements.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<IElementHandle[]> QuerySelectorAllWithContentAsync(this IElementHandle elementHandle, string selector, string regex, string flags = "")
        {
            var arrayHandle = await elementHandle.GuardFromNull().EvaluateFunctionHandleAsync(
                @"(element, selector, regex, flags) => {
                    var elements = element.querySelectorAll(selector);
                    return Array.prototype.filter.call(elements, function(element) {
                        return RegExp(regex, flags).test(element.textContent);
                    });
                }",
                selector,
                regex,
                flags).ConfigureAwait(false) ?? throw new InvalidOperationException("EvaluateFunctionHandleAsync returned null.");
            var properties = await arrayHandle.GetPropertiesAsync().ConfigureAwait(false);
            await arrayHandle.DisposeAsync().ConfigureAwait(false);

            return [.. properties.Values.OfType<IElementHandle>()];
        }

        /// <summary>
        /// Indicates whether the element exists or not. A non null <see cref="IElementHandle"/> is considered existing.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element exists.</returns>
        public static bool Exists(this IElementHandle elementHandle)
        {
            return elementHandle != null;
        }

        /// <summary>
        /// InnerHtml of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>The element's <c>innerHTML</c>.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML"/>
        public static async Task<string> InnerHtmlAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("innerHTML").ConfigureAwait(false);
        }

        /// <summary>
        /// OuterHtml of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>The element's <c>outerHTML</c>.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/outerHTML"/>
        public static async Task<string> OuterHtmlAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("outerHTML").ConfigureAwait(false);
        }

        /// <summary>
        /// TextContent of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>The element's <c>textContent</c>.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent"/>
        public static async Task<string> TextContentAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("textContent").ConfigureAwait(false);
        }

        /// <summary>
        /// InnerText of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>The element's <c>innerText</c>.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/HTMLElement/innerText"/>
        public static async Task<string> InnerTextAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.GetPropertyValueAsync("innerText").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has the specified content or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="regex">A regular expression to test against <c>element.textContent</c>.</param>
        /// <param name="flags">A set of flags for the regular expression.</param>
        /// <returns><c>true</c> if the element has the specified content.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp"/>
        public static async Task<bool> HasContentAsync(this IElementHandle elementHandle, string regex, string flags = "")
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("(element, regex, flags) => RegExp(regex, flags).test(element.textContent)", regex, flags).ConfigureAwait(false);
        }

        /// <summary>
        /// ClassName of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>The element's <c>className</c>.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/className"/>
        public static async Task<string> ClassNameAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<string>("element => element.className").ConfigureAwait(false);
        }

        /// <summary>
        /// ClassList of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns>The element's <c>classList</c>.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/classList"/>
        public static async Task<string[]> ClassListAsync(this IElementHandle elementHandle)
        {
            var json = await elementHandle.EvaluateFunctionWithGuardAsync<JsonElement>("element => element.classList").ConfigureAwait(false);
            var dictionary = json.Deserialize<Dictionary<string, string>>();
            return dictionary?.Values.ToArray() ?? [];
        }

        /// <summary>
        /// Indicates whether the element has the specified class or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <param name="className">The class name.</param>
        /// <returns><c>true</c> if the element has the specified class.</returns>
        public static async Task<bool> HasClassAsync(this IElementHandle elementHandle, string className)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("(element, className) => element.classList.contains(className)", className).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is selected or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is selected.</returns>
        /// <remarks><![CDATA[Elements: <option>]]></remarks>
        public static async Task<bool> IsSelectedAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("element => element.selected").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is checked or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is checked.</returns>
        /// <remarks><![CDATA[Elements: <command>, <input>]]></remarks>
        public static async Task<bool> IsCheckedAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("element => element.checked").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is disabled or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is disabled.</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task<bool> IsDisabledAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("element => element.disabled").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is enabled or not. This is the logical negation of <see cref="IsDisabledAsync"/>.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is enabled.</returns>
        /// <remarks><![CDATA[Elements: <button>, <command>, <fieldset>, <input>, <keygen>, <optgroup>, <option>, <select>, <textarea>]]></remarks>
        public static async Task<bool> IsEnabledAsync(this IElementHandle elementHandle)
        {
            return !await elementHandle.IsDisabledAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is read-only or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is read-only.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        public static async Task<bool> IsReadOnlyAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("element => element.readOnly").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is required or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is required.</returns>
        /// <remarks><![CDATA[Elements: <input>, <select>, <textarea>]]></remarks>
        public static async Task<bool> IsRequiredAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("element => element.required").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has focus or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element has focus.</returns>
        /// <remarks><![CDATA[Elements: <button>, <input>, <keygen>, <select>, <textarea>]]></remarks>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/DocumentOrShadowRoot/activeElement"/>
        public static async Task<bool> HasFocusAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>("element => element === document.activeElement").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element is empty or not, e.g. an empty editable element or a DOM node that has no text.
        /// </summary>
        /// <param name="elementHandle">An <see cref="IElementHandle"/>.</param>
        /// <returns><c>true</c> if the element is empty.</returns>
        /// <remarks><![CDATA[Elements: <input>, <textarea>]]></remarks>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Node/textContent"/>
        public static async Task<bool> IsEmptyAsync(this IElementHandle elementHandle)
        {
            return await elementHandle.EvaluateFunctionWithGuardAsync<bool>(
                @"element => {
                    if (element.nodeName === 'INPUT' || element.nodeName === 'TEXTAREA')
                        return !element.value;
                    else
                        return !element.textContent?.trim();
                }").ConfigureAwait(false);
        }

        private static async Task<string> GetPropertyValueAsync(this IElementHandle elementHandle, string propertyName)
        {
            var property = await elementHandle.GuardFromNull().GetPropertyAsync(propertyName).ConfigureAwait(false);
            return await property.JsonValueAsync<string>().ConfigureAwait(false);
        }
    }
}
