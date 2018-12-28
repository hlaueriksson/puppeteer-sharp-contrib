using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Sample
{
    public static class TaskExtensions
    {
        internal static T Result<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}