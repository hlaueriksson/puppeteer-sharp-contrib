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
                return [.. interceptors.Where(x => x is SelectorInterceptor)];
            }

#pragma warning disable CS0618 // Type or member is obsolete
            if (method.IsGetterPropertyWithAttribute<XPathAttribute>())
#pragma warning restore CS0618 // Type or member is obsolete
            {
                return [.. interceptors.Where(x => x is XPathInterceptor)];
            }

            return [.. interceptors.Where(x => x is not SelectorInterceptor && x is not XPathInterceptor)];
        }
    }
}
