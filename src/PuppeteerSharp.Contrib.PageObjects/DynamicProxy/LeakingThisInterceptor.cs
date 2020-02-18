using System;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    [Serializable]
    internal class LeakingThisInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            if (invocation.ReturnValue == invocation.InvocationTarget)
            {
                invocation.ReturnValue = invocation.Proxy;
            }
        }
    }
}