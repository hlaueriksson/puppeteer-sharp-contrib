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
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Id(this ElementHandle elementHandle)
        {
            return elementHandle.IdAsync().Result();
        }

        /// <summary>
        /// Id of the element
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Id(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Id();
        }

        // Name

        /// <summary>
        /// Name of the element
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        /// <returns>The element <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Name(this ElementHandle elementHandle)
        {
            return elementHandle.NameAsync().Result();
        }

        /// <summary>
        /// Name of the element
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        /// <returns>The element <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Name(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Name();
        }

        // Value

        /// <summary>
        /// Value of the element
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The element <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Value(this ElementHandle elementHandle)
        {
            return elementHandle.ValueAsync().Result();
        }

        /// <summary>
        /// Value of the element
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        /// <returns>The element <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Value(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Value();
        }

        // Href

        /// <summary>
        /// Href of the element
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        /// <returns>The element <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Href(this ElementHandle elementHandle)
        {
            return elementHandle.HrefAsync().Result();
        }

        /// <summary>
        /// Href of the element
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        /// <returns>The element <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Href(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Href();
        }

        // Src

        /// <summary>
        /// Src of the element
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        /// <returns>The element <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Src(this ElementHandle elementHandle)
        {
            return elementHandle.SrcAsync().Result();
        }

        /// <summary>
        /// Src of the element
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        /// <returns>The element <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Src(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Src();
        }

        // HasAttribute

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        public static bool HasAttribute(this ElementHandle elementHandle, string name)
        {
            return elementHandle.HasAttributeAsync(name).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        public static bool HasAttribute(this Task<ElementHandle> elementHandleTask, string name)
        {
            return elementHandleTask.GuardFromNull().Result().HasAttribute(name);
        }

        // GetAttribute

        /// <summary>
        /// The value of a specified attribute on the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        public static string GetAttribute(this ElementHandle elementHandle, string name)
        {
            return elementHandle.GetAttributeAsync(name).Result();
        }

        /// <summary>
        /// The value of a specified attribute on the element.
        /// See also https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        public static string GetAttribute(this Task<ElementHandle> elementHandleTask, string name)
        {
            return elementHandleTask.GuardFromNull().Result().GetAttribute(name);
        }
    }
}
