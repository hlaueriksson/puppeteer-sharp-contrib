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

        internal static ElementHandle GuardFromNull(this ElementHandle handle)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));

            return handle;
        }

        internal static Task<ElementHandle> GuardFromNull(this Task<ElementHandle> task)
        {
            if (task == null) throw new ArgumentNullException(nameof(task));

            return task;
        }

        internal static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}
