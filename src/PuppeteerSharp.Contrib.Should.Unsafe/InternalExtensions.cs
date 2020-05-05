using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class InternalExtensions
    {
        internal static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}
