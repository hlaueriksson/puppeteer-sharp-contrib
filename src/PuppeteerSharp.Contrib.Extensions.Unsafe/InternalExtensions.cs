using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("PuppeteerSharp.Contrib.Should.Unsafe")]

namespace PuppeteerSharp.Contrib.Extensions
{
    internal static class InternalExtensions
    {
        internal static Task<ElementHandle> GuardFromNull(this Task<ElementHandle> elementHandleTask)
        {
            if (elementHandleTask == null) throw new ArgumentNullException(nameof(elementHandleTask));

            return elementHandleTask;
        }

        internal static T Result<T>(this Task<T> task)
        {
            return AsyncUtil.RunSync(() => task);
        }
    }
}
