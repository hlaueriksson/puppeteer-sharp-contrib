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

        public static T PageObject<T>(IPage page, IResponse? response)
            where T : PageObject
        {
            var proxy = ProxyGenerator.CreateClassProxy<T>(Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, response);

            return proxy;
        }

        public static T? ElementObject<T>(IPage? page, IElementHandle elementHandle)
            where T : ElementObject
        {
            if (page == null) return default;
            if (elementHandle == null) return default;

            var proxy = ProxyGenerator.CreateClassProxy<T>(Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, elementHandle);

            return proxy;
        }

        public static ElementObject? ElementObject(Type proxyType, IPage page, IElementHandle elementHandle)
        {
            if (elementHandle == null) return default;

            var proxy = (ElementObject)ProxyGenerator.CreateClassProxy(proxyType, Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, elementHandle);

            return proxy;
        }

        public static Array? ElementObjectArray(Type? proxyType, IPage page, IElementHandle[] elementHandles)
        {
            if (proxyType == null) return default;

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
