using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class InternalExtensions
    {
        internal static void Result(this Task task)
        {
            AsyncUtil.RunSync(() => task);
        }

        internal static T Result<T>(this Task<T> task)
        {
            return AsyncUtil.RunSync(() => task);
        }
    }
}
