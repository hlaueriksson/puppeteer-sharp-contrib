using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    [Serializable]
    internal class InterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (method.IsGetterPropertyWithAttribute<SelectorAttribute>())
            {
                return interceptors.Where(x => x is SelectorInterceptor).ToArray();
            }

            if (method.IsGetterPropertyWithAttribute<XPathAttribute>())
            {
                return interceptors.Where(x => x is XPathInterceptor).ToArray();
            }

            return interceptors.Where(x => x is not SelectorInterceptor && x is not XPathInterceptor).ToArray();
        }
    }
}
