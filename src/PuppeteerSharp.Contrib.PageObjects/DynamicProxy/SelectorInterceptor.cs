using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    [Serializable]
    internal class SelectorInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var returnType = invocation.Method.ReturnType;

            Debug.Assert(typeof(Task).IsAssignableFrom(returnType) && returnType.IsGenericType);

            var tcsType = typeof(TaskCompletionSource<>).MakeGenericType(returnType.GetGenericArguments()[0]);
            var tcs = Activator.CreateInstance(tcsType);
            invocation.ReturnValue = tcsType.GetProperty("Task").GetValue(tcs, null);

            InterceptAsync(invocation).ContinueWith(_ =>
            {
                tcsType.GetMethod("SetResult").Invoke(tcs, new[] { invocation.ReturnValue });
            });
        }

        private async Task InterceptAsync(IInvocation invocation)
        {
            var proceed = invocation.CaptureProceedInfo();

            if (invocation.IsGetterPropertyWithAttribute<SelectorAttribute>())
            {
                var attribute = invocation.GetAttribute<SelectorAttribute>();

                if (invocation.InvocationTarget is PageObject pageObject)
                {
                    var result = await invocation.GetReturnValue(pageObject, attribute).ConfigureAwait(false);

                    if (result != null)
                    {
                        invocation.ReturnValue = result;
                        return;
                    }
                }
                if (invocation.InvocationTarget is ElementObject elementObject)
                {
                    var result = await invocation.GetReturnValue(elementObject, attribute).ConfigureAwait(false);

                    if (result != null)
                    {
                        invocation.ReturnValue = result;
                        return;
                    }
                }
            }

            proceed.Invoke();
        }
    }
}