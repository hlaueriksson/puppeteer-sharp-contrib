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
            ArgumentNullException.ThrowIfNull(page);

            return page;
        }

        internal static IResponse GuardFromNull(this IResponse response)
        {
            ArgumentNullException.ThrowIfNull(response);

            return response;
        }

        internal static IFrame GuardFromNull(this IFrame frame)
        {
            ArgumentNullException.ThrowIfNull(frame);

            return frame;
        }

        internal static IElementHandle GuardFromNull(this IElementHandle elementHandle)
        {
            ArgumentNullException.ThrowIfNull(elementHandle);

            return elementHandle;
        }
    }
}
