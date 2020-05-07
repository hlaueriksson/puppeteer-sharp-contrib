using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    /// <summary>
    /// Extension methods for accessing attributes on <see cref="ElementHandle"/>.
    /// </summary>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes"/>
    public static class ElementHandleAttributeExtensions
    {
        // Id

        /// <summary>
        /// Id of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Id(this ElementHandle elementHandle)
        {
            return elementHandle.IdAsync().Result();
        }

        /// <summary>
        /// Id of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>id</c>, or <c>null</c> if the attribute is missing.</returns>
        public static string Id(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Id();
        }

        // Name

        /// <summary>
        /// Name of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        public static string Name(this ElementHandle elementHandle)
        {
            return elementHandle.NameAsync().Result();
        }

        /// <summary>
        /// Name of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>name</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <button>, <form>, <fieldset>, <iframe>, <input>, <keygen>, <object>, <output>, <select>, <textarea>, <map>, <meta>, <param>]]></remarks>
        public static string Name(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Name();
        }

        // Value

        /// <summary>
        /// Value of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static string Value(this ElementHandle elementHandle)
        {
            return elementHandle.ValueAsync().Result();
        }

        /// <summary>
        /// Value of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>value</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <button>, <option>, <input>, <li>, <meter>, <progress>, <param>]]></remarks>
        public static string Value(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Value();
        }

        // Href

        /// <summary>
        /// Href of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        public static string Href(this ElementHandle elementHandle)
        {
            return elementHandle.HrefAsync().Result();
        }

        /// <summary>
        /// Href of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>href</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <a>, <area>, <base>, <link>]]></remarks>
        public static string Href(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Href();
        }

        // Src

        /// <summary>
        /// Src of the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        public static string Src(this ElementHandle elementHandle)
        {
            return elementHandle.SrcAsync().Result();
        }

        /// <summary>
        /// Src of the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <returns>The element's <c>src</c>, or <c>null</c> if the attribute is missing.</returns>
        /// <remarks><![CDATA[Elements: <audio>, <embed>, <iframe>, <img>, <input>, <script>, <source>, <track>, <video>]]></remarks>
        public static string Src(this Task<ElementHandle> elementHandleTask)
        {
            return elementHandleTask.GuardFromNull().Result().Src();
        }

        // HasAttribute

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute"/>
        public static bool HasAttribute(this ElementHandle elementHandle, string name)
        {
            return elementHandle.HasAttributeAsync(name).Result();
        }

        /// <summary>
        /// Indicates whether the element has the specified attribute or not.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns><c>true</c> if the element has the specified attribute</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/hasAttribute"/>
        public static bool HasAttribute(this Task<ElementHandle> elementHandleTask, string name)
        {
            return elementHandleTask.GuardFromNull().Result().HasAttribute(name);
        }

        // GetAttribute

        /// <summary>
        /// The value of a specified attribute on the element.
        /// </summary>
        /// <param name="elementHandle">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute"/>
        public static string GetAttribute(this ElementHandle elementHandle, string name)
        {
            return elementHandle.GetAttributeAsync(name).Result();
        }

        /// <summary>
        /// The value of a specified attribute on the element.
        /// </summary>
        /// <param name="elementHandleTask">An <see cref="ElementHandle"/></param>
        /// <param name="name">The attribute name</param>
        /// <returns>The attribute value</returns>
        /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/Element/getAttribute"/>
        public static string GetAttribute(this Task<ElementHandle> elementHandleTask, string name)
        {
            return elementHandleTask.GuardFromNull().Result().GetAttribute(name);
        }
    }
}
