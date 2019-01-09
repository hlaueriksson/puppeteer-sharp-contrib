using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// <see cref="ElementHandle"/> extension methods for accessing attributes.
    /// See also https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes
    /// </summary>
    public static class ElementHandleAttributeExtensions
    {
        // Id

        /// <summary>
        /// Id of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static async Task<string> IdAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("id").ConfigureAwait(false);
        }

        /// <summary>
        /// Id of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Id(this ElementHandle handle)
        {
            return handle.IdAsync().Result();
        }

        /// <summary>
        /// Id of the element
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Id(this Task<ElementHandle> task)
        {
            return task.Result().Id();
        }

        // Name

        /// <summary>
        /// Name of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        /// <returns>The element <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        public static async Task<string> NameAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("name").ConfigureAwait(false);
        }

        /// <summary>
        /// Name of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        /// <returns>The element <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Name(this ElementHandle handle)
        {
            return handle.NameAsync().Result();
        }

        /// <summary>
        /// Name of the element
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        /// <returns>The element <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Name(this Task<ElementHandle> task)
        {
            return task.Result().Name();
        }

        // Value

        /// <summary>
        /// Value of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The element <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        public static async Task<string> ValueAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("value").ConfigureAwait(false);
        }

        /// <summary>
        /// Value of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The element <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Value(this ElementHandle handle)
        {
            return handle.ValueAsync().Result();
        }

        /// <summary>
        /// Value of the element
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The element <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Value(this Task<ElementHandle> task)
        {
            return task.Result().Value();
        }

        // Href

        /// <summary>
        /// Href of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        /// <returns>The element <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        public static async Task<string> HrefAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("href").ConfigureAwait(false);
        }

        /// <summary>
        /// Href of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        /// <returns>The element <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Href(this ElementHandle handle)
        {
            return handle.HrefAsync().Result();
        }

        /// <summary>
        /// Href of the element
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        /// <returns>The element <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Href(this Task<ElementHandle> task)
        {
            return task.Result().Href();
        }

        // Src

        /// <summary>
        /// Src of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        /// <returns>The element <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        public static async Task<string> SrcAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("src").ConfigureAwait(false);
        }

        /// <summary>
        /// Src of the element
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        /// <returns>The element <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Src(this ElementHandle handle)
        {
            return handle.SrcAsync().Result();
        }

        /// <summary>
        /// Src of the element
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        /// <returns>The element <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Src(this Task<ElementHandle> task)
        {
            return task.Result().Src();
        }

        // HasAttribute

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        public static async Task<bool> HasAttributeAsync(this ElementHandle handle, string name)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<bool>("(element, name) => element.hasAttribute(name)", name).ConfigureAwait(false);
        }

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        public static bool HasAttribute(this ElementHandle handle, string name)
        {
            return handle.HasAttributeAsync(name).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        public static bool HasAttribute(this Task<ElementHandle> task, string name)
        {
            return task.Result().HasAttribute(name);
        }

        // GetAttribute

        /// <summary>
        /// The value of a specified attribute on the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        public static async Task<string> GetAttributeAsync(this ElementHandle handle, string name)
        {
            handle.GuardFromNull();
            return await handle.EvaluateFunctionWithoutDisposeAsync<string>("(element, name) => element.getAttribute(name)", name).ConfigureAwait(false);
        }

        /// <summary>
        /// The value of a specified attribute on the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute
        /// </summary>
        /// <param name="handle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        public static string GetAttribute(this ElementHandle handle, string name)
        {
            return handle.GetAttributeAsync(name).Result();
        }

        /// <summary>
        /// The value of a specified attribute on the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute
        /// </summary>
        /// <param name="task">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        public static string GetAttribute(this Task<ElementHandle> task, string name)
        {
            return task.Result().GetAttribute(name);
        }
    }
}