using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for accessing attributes on <see cref="ElementHandle"/>.
    /// </summary>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes"/>
    public static class ElementHandleAttributeExtensions
    {
        /// <summary>
        /// Id of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <returns>The element's <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static async Task<string> IdAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetAttributeAsync("id").ConfigureAwait(false);
        }

        /// <summary>
        /// Name of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <returns>The element's <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        public static async Task<string> NameAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetAttributeAsync("name").ConfigureAwait(false);
        }

        /// <summary>
        /// Value of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <returns>The element's <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static async Task<string> ValueAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetAttributeAsync("value").ConfigureAwait(false);
        }

        /// <summary>
        /// Href of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <returns>The element's <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        public static async Task<string> HrefAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetAttributeAsync("href").ConfigureAwait(false);
        }

        /// <summary>
        /// Src of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <returns>The element's <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        public static async Task<string> SrcAsync(this ElementHandle elementHandle)
        {
            return await elementHandle.GetAttributeAsync("src").ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <returns><c>true</c> if the element has the specified attribute.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute"/>
        public static async Task<bool> HasAttributeAsync(this ElementHandle elementHandle, string name)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<bool>("(element, name) => element.hasAttribute(name)", name).ConfigureAwait(false);
        }

        /// <summary>
        /// The value of a specified attribute on the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/>.</param>
        /// <param name="name">The attribute name.</param>
        /// <returns>The attribute value.</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute"/>
        public static async Task<string> GetAttributeAsync(this ElementHandle elementHandle, string name)
        {
            return await elementHandle.EvaluateFunctionWithoutDisposeAsync<string>("(element, name) => element.getAttribute(name)", name).ConfigureAwait(false);
        }
    }
}
