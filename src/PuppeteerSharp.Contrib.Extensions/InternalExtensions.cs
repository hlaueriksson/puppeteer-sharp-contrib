using System;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    internal static class InternalExtensions
    {
        // EvaluateFunction

        internal static async Task<T> EvaluateFunctionWithoutDisposeAsync<T>(this ElementHandle elementHandle, string pageFunction, params object[] args)
        {
            var newArgs = new object[args.Length + 1];
            newArgs[0] = elementHandle ?? throw new SelectorException("Error: failed to find element matching selector");
            args.CopyTo(newArgs, 1);

            return await elementHandle.ExecutionContext.EvaluateFunctionAsync<T>(pageFunction, newArgs).ConfigureAwait(false);
        }

        internal static async Task<T> EvaluateFunctionWithoutDisposeAsync<T>(this JSHandle arrayHandle, string pageFunction, params object[] args)
        {
            var newArgs = new object[args.Length + 1];
            newArgs[0] = arrayHandle;
            args.CopyTo(newArgs, 1);

            return await arrayHandle.ExecutionContext.EvaluateFunctionAsync<T>(pageFunction, newArgs).ConfigureAwait(false);
        }

        // Guard

        internal static void GuardFromNull(this ElementHandle handle)
        {
            if (handle == null) throw new ArgumentNullException(nameof(handle));
        }

        // Result

        internal static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}