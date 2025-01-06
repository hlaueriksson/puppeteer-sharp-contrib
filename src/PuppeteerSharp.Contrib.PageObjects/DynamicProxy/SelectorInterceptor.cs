using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace PuppeteerSharp.Contrib.PageObjects.DynamicProxy
{
    [Serializable]
    internal class SelectorInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!invocation.HasValidReturnType())
            {
                invocation.ReturnValue = null;
                return;
            }

            var tcsType = typeof(TaskCompletionSource<>).MakeGenericType(invocation.Method.ReturnType.GetGenericArguments()[0]);
            var tcs = Activator.CreateInstance(tcsType);
            invocation.ReturnValue = tcsType?.GetProperty("Task")?.GetValue(tcs, null);

#pragma warning disable VSTHRD105 // Avoid method overloads that assume TaskScheduler.Current
#pragma warning disable VSTHRD110 // Observe result of async calls
            InterceptAsync(invocation).ContinueWith(_ => tcsType?.GetMethod("SetResult")?.Invoke(tcs, [invocation.ReturnValue]), TaskScheduler.Default);
#pragma warning restore VSTHRD110 // Observe result of async calls
#pragma warning restore VSTHRD105 // Avoid method overloads that assume TaskScheduler.Current
        }

        private static async Task InterceptAsync(IInvocation invocation)
        {
            if (invocation.IsGetterPropertyWithAttribute<SelectorAttribute>())
            {
                var attribute = invocation.GetAttribute<SelectorAttribute>();

                if (invocation.InvocationTarget is PageObject pageObject)
                {
                    invocation.ReturnValue = await invocation.GetReturnValueAsync(pageObject, attribute).ConfigureAwait(false);
                    return;
                }

                if (invocation.InvocationTarget is ElementObject elementObject)
                {
                    invocation.ReturnValue = await invocation.GetReturnValueAsync(elementObject, attribute).ConfigureAwait(false);
                    return;
                }
            }

            invocation.ReturnValue = null;
        }
    }
}
