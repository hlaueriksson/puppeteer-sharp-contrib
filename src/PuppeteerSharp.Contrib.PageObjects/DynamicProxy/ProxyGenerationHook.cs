using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    [Serializable]
    internal class ProxyGenerationHook : IProxyGenerationHook
    {
        public void MethodsInspected()
        {
        }

        public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
        {
        }

        public bool ShouldInterceptMethod(Type type, MethodInfo methodInfo)
        {
            return (methodInfo.IsGetterPropertyWithAttribute<SelectorAttribute>() ||
                    methodInfo.IsGetterPropertyWithAttribute<XPathAttribute>()) &&
                    methodInfo.IsReturningAsyncResult();
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj.GetType() == typeof(ProxyGenerationHook);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode();
        }
    }
}