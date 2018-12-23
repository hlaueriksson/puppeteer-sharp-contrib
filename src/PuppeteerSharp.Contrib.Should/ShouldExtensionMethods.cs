using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    public static class ShouldExtensionMethods
    {
        public static void ShouldExist(this ElementHandle handle)
        {
            if (!handle.Exists()) throw new ShouldException("Should exist, but did not.");
        }

        public static void ShouldExist(this Task<ElementHandle> task)
        {
            if (!task.Exists()) throw new ShouldException("Should exist, but did not.");
        }

        public static void ShouldNotExist(this ElementHandle handle)
        {
            if (handle.Exists()) throw new ShouldException("Should not exist, but did.");
        }

        public static void ShouldNotExist(this Task<ElementHandle> task)
        {
            if (task.Exists()) throw new ShouldException("Should not exist, but did.");
        }
    }
}