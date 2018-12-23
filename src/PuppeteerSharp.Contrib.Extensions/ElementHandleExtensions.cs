using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Extensions
{
    public static class ElementHandleExtensions
    {
        public static bool Exists(this ElementHandle handle)
        {
            return handle != null;
        }

        public static bool Exists(this Task<ElementHandle> task)
        {
            return task.GetAwaiter().GetResult().Exists();
        }
    }
}