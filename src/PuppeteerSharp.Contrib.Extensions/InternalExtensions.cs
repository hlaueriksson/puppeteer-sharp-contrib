using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PuppeteerSharp.Contrib.Extensions.Unsafe")]

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
    }
}
