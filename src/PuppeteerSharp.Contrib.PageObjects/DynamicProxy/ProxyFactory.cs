using System;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    internal static class ProxyFactory
    {
#pragma warning disable IDE1006 // Naming Styles
        private static readonly ProxyGenerator ProxyGenerator = new();
        private static readonly ProxyGenerationOptions Options = new(new ProxyGenerationHook()) { Selector = new InterceptorSelector() };
#pragma warning restore IDE1006 // Naming Styles

        public static T PageObject<T>(Page page, Response response)
            where T : PageObject
        {
            var proxy = ProxyGenerator.CreateClassProxy<T>(Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, response);

            return proxy;
        }

        public static T? ElementObject<T>(Page page, ElementHandle elementHandle)
            where T : ElementObject
        {
            if (elementHandle == null) return default;

            var proxy = ProxyGenerator.CreateClassProxy<T>(Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, elementHandle);

            return proxy;
        }

        public static ElementObject? ElementObject(Type proxyType, Page page, ElementHandle elementHandle)
        {
            if (elementHandle == null) return default;

            var proxy = (ElementObject)ProxyGenerator.CreateClassProxy(proxyType, Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, elementHandle);

            return proxy;
        }

        public static Array ElementObjectArray(Type proxyType, Page page, ElementHandle[] elementHandles)
        {
            var array = Array.CreateInstance(proxyType, elementHandles.Length);
            for (var i = 0; i < elementHandles.Length; i++)
            {
                var elementHandle = elementHandles[i];
                array.SetValue(ElementObject(proxyType, page, elementHandle), i);
            }

            return array;
        }
    }
}
