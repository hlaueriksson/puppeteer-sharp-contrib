using System;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    public static class InternalExtensions
    {
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