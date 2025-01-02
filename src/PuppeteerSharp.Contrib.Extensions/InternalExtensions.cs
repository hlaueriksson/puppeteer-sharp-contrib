using System;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    internal static class InternalExtensions
    {
        internal static async Task<T> EvaluateFunctionWithGuardAsync<T>(this IElementHandle elementHandle, string pageFunction, params object[] args)
        {
            return await elementHandle.GuardFromNull().EvaluateFunctionAsync<T>(pageFunction, args).ConfigureAwait(false);
        }

        internal static IPage GuardFromNull(this IPage page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));

            return page;
        }

        internal static IResponse GuardFromNull(this IResponse response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            return response;
        }

        internal static IFrame GuardFromNull(this IFrame frame)
        {
            if (frame == null) throw new ArgumentNullException(nameof(frame));

            return frame;
        }

        internal static IElementHandle GuardFromNull(this IElementHandle elementHandle)
        {
            if (elementHandle == null) throw new ArgumentNullException(nameof(elementHandle));

            return elementHandle;
        }
    }
}
