using System;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    internal static class InternalExtensions
    {
        internal static async Task<T> EvaluateFunctionWithoutDisposeAsync<T>(this IElementHandle elementHandle, string pageFunction, params object[] args)
        {
            return await elementHandle.GuardFromNull().EvaluateFunctionAsync<T>(pageFunction, args).ConfigureAwait(false);
        }

        internal static IPage GuardFromNull(this IPage page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));

            return page;
        }

        internal static IElementHandle GuardFromNull(this IElementHandle elementHandle)
        {
            if (elementHandle == null) throw new ArgumentNullException(nameof(elementHandle));

            return elementHandle;
        }
    }
}
