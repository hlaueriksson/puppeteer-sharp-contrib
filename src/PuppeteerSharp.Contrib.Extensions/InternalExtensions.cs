using System;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    internal static class InternalExtensions
    {
        internal static async Task<T> EvaluateFunctionWithoutDisposeAsync<T>(this ElementHandle elementHandle, string pageFunction, params object[] args)
        {
            return await elementHandle.GuardFromNull().EvaluateFunctionAsync<T>(pageFunction, args).ConfigureAwait(false);
        }

        internal static Page GuardFromNull(this Page page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));

            return page;
        }

        internal static ElementHandle GuardFromNull(this ElementHandle elementHandle)
        {
            if (elementHandle == null) throw new ArgumentNullException(nameof(elementHandle));

            return elementHandle;
        }

        internal static Task<ElementHandle> GuardFromNull(this Task<ElementHandle> elementHandleTask)
        {
            if (elementHandleTask == null) throw new ArgumentNullException(nameof(elementHandleTask));

            return elementHandleTask;
        }

        internal static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}
