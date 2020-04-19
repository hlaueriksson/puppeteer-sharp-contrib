using System;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    internal static class ProxyFactory
    {
        private static readonly ProxyGenerator ProxyGenerator = new ProxyGenerator();
        private static readonly ProxyGenerationOptions Options = new ProxyGenerationOptions(new ProxyGenerationHook()) { Selector = new InterceptorSelector() };

        public static T PageObject<T>(Page page, Response response) where T : PageObject
        {
            var proxy = ProxyGenerator.CreateClassProxy<T>(Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, response);

            return proxy;
        }

        public static T ElementObject<T>(Page page, ElementHandle elementHandle) where T : ElementObject
        {
            var proxy = ProxyGenerator.CreateClassProxy<T>(Options, new SelectorInterceptor(), new XPathInterceptor());
            proxy.Initialize(page, elementHandle);

            return proxy;
        }

        public static ElementObject ElementObject(Type proxyType, Page page, ElementHandle elementHandle)
        {
            var proxy = ProxyGenerator.CreateClassProxy(proxyType, Options, new SelectorInterceptor(), new XPathInterceptor()) as ElementObject;
            proxy?.Initialize(page, elementHandle);

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