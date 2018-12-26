using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PuppeteerSharp.Contrib.Extensions
{
    public static class ElementHandleExtensions
    {
        // Exists

        public static bool Exists(this ElementHandle handle)
        {
            return handle != null;
        }

        public static bool Exists(this Task<ElementHandle> task)
        {
            return task.Result().Exists();
        }

        // InnerHtml

        public static async Task<string> InnerHtmlAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("innerHTML");
        }

        public static string InnerHtml(this ElementHandle handle)
        {
            return handle.InnerHtmlAsync().Result();
        }

        public static string InnerHtml(this Task<ElementHandle> task)
        {
            return task.Result().InnerHtml();
        }

        // OuterHtml

        public static async Task<string> OuterHtmlAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("outerHTML");
        }

        public static string OuterHtml(this ElementHandle handle)
        {
            return handle.OuterHtmlAsync().Result();
        }

        public static string OuterHtml(this Task<ElementHandle> task)
        {
            return task.Result().OuterHtml();
        }

        // TextContent

        public static async Task<string> TextContentAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("textContent");
        }

        public static string TextContent(this ElementHandle handle)
        {
            return handle.TextContentAsync().Result();
        }

        public static string TextContent(this Task<ElementHandle> task)
        {
            return task.Result().TextContent();
        }

        // InnerText

        public static async Task<string> InnerTextAsync(this ElementHandle handle)
        {
            return await handle.GetPropertyValueAsync("innerText");
        }

        public static string InnerText(this ElementHandle handle)
        {
            return handle.InnerTextAsync().Result();
        }

        public static string InnerText(this Task<ElementHandle> task)
        {
            return task.Result().InnerText();
        }

        // Value

        public static async Task<string> ValueAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("value");
        }

        public static string Value(this ElementHandle handle)
        {
            return handle.ValueAsync().Result();
        }

        public static string Value(this Task<ElementHandle> task)
        {
            return task.Result().Value();
        }

        // Href

        public static async Task<string> HrefAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("href");
        }

        public static string Href(this ElementHandle handle)
        {
            return handle.HrefAsync().Result();
        }

        public static string Href(this Task<ElementHandle> task)
        {
            return task.Result().Href();
        }

        // Src

        public static async Task<string> SrcAsync(this ElementHandle handle)
        {
            return await handle.GetAttributeAsync("src");
        }

        public static string Src(this ElementHandle handle)
        {
            return handle.SrcAsync().Result();
        }

        public static string Src(this Task<ElementHandle> task)
        {
            return task.Result().Src();
        }

        // HasAttribute

        public static async Task<bool> HasAttributeAsync(this ElementHandle handle, string name)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            return await handle.EvaluateFunctionAsync<bool>("(element, name) => element.hasAttribute(name)", name);
        }

        public static bool HasAttribute(this ElementHandle handle, string name)
        {
            return handle.HasAttributeAsync(name).Result();
        }

        public static bool HasAttribute(this Task<ElementHandle> task, string name)
        {
            return task.Result().HasAttribute(name);
        }

        // GetAttribute

        public static async Task<string> GetAttributeAsync(this ElementHandle handle, string name)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            return await handle.EvaluateFunctionAsync<string>("(element, name) => element.getAttribute(name)", name);
        }

        public static string GetAttribute(this ElementHandle handle, string name)
        {
            return handle.GetAttributeAsync(name).Result();
        }

        public static string GetAttribute(this Task<ElementHandle> task, string name)
        {
            return task.Result().GetAttribute(name);
        }

        // HasContent

        public static async Task<bool> HasContentAsync(this ElementHandle handle, string content)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            return await handle.EvaluateFunctionAsync<bool>("(node, content) => node.textContent.includes(content)", content);
        }

        public static bool HasContent(this ElementHandle handle, string content)
        {
            return handle.HasContentAsync(content).Result();
        }

        public static bool HasContent(this Task<ElementHandle> task, string content)
        {
            return task.Result().HasContent(content);
        }

        // ClassName

        public static async Task<string> ClassNameAsync(this ElementHandle handle)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            return await handle.EvaluateFunctionAsync<string>("element => element.className");
        }

        public static string ClassName(this ElementHandle handle)
        {
            return handle.ClassNameAsync().Result();
        }

        public static string ClassName(this Task<ElementHandle> task)
        {
            return task.Result().ClassName();
        }

        // ClassList

        public static async Task<string[]> ClassListAsync(this ElementHandle handle)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            var json = await handle.EvaluateFunctionAsync<JObject>("element => element.classList");
            var dictionary = json.ToObject<Dictionary<string, string>>();
            return dictionary.Values.ToArray();
        }

        public static string[] ClassList(this ElementHandle handle)
        {
            return handle.ClassListAsync().Result();
        }

        public static string[] ClassList(this Task<ElementHandle> task)
        {
            return task.Result().ClassList();
        }

        // HasClass

        public static async Task<bool> HasClassAsync(this ElementHandle handle, string className)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            return await handle.EvaluateFunctionAsync<bool>("(element, className) => element.classList.contains(className)", className);
        }

        public static bool HasClass(this ElementHandle handle, string className)
        {
            return handle.HasClassAsync(className).Result();
        }

        public static bool HasClass(this Task<ElementHandle> task, string className)
        {
            return task.Result().HasClass(className);
        }

        // Result

        private static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        // GetPropertyValue

        private static async Task<string> GetPropertyValueAsync(this ElementHandle handle, string propertyName)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
            var property = await handle.GetPropertyAsync(propertyName);
            return await property.JsonValueAsync<string>();
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