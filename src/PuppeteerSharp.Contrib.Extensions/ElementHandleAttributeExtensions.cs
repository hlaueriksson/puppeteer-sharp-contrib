using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    public static class ElementHandleAttributeExtensions
    {
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
            handle.GuardFromNull();
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
            handle.GuardFromNull();
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
    }
}