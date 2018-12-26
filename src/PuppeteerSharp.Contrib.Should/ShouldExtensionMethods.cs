using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Should
{
    public static class ShouldExtensionMethods
    {
        // Exist

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

        // Value

        public static void ShouldHaveValue(this ElementHandle handle, string value)
        {
            if (handle.Value() != value) throw new ShouldException("Should have value, but did not.");
        }

        public static void ShouldHaveValue(this Task<ElementHandle> task, string value)
        {
            if (task.Value() != value) throw new ShouldException("Should have value, but did not.");
        }

        public static void ShouldNotHaveValue(this ElementHandle handle, string value)
        {
            if (handle.Value() == value) throw new ShouldException("Should not have value, but did.");
        }

        public static void ShouldNotHaveValue(this Task<ElementHandle> task, string value)
        {
            if (task.Value() == value) throw new ShouldException("Should not have value, but did.");
        }

        // Attribute

        public static void ShouldHaveAttribute(this ElementHandle handle, string name)
        {
            if (!handle.HasAttribute(name)) throw new ShouldException("Should have attribute, but did not.");
        }

        public static void ShouldHaveAttribute(this Task<ElementHandle> task, string name)
        {
            if (!task.HasAttribute(name)) throw new ShouldException("Should have attribute, but did not.");
        }

        public static void ShouldNotHaveAttribute(this ElementHandle handle, string name)
        {
            if (handle.HasAttribute(name)) throw new ShouldException("Should not have attribute, but did.");
        }

        public static void ShouldNotHaveAttribute(this Task<ElementHandle> task, string name)
        {
            if (task.HasAttribute(name)) throw new ShouldException("Should not have attribute, but did.");
        }

        // Content

        public static void ShouldHaveContent(this ElementHandle handle, string content)
        {
            if (!handle.HasContent(content)) throw new ShouldException("Should have content, but did not.");
        }

        public static void ShouldHaveContent(this Task<ElementHandle> task, string content)
        {
            if (!task.HasContent(content)) throw new ShouldException("Should have content, but did not.");
        }

        public static void ShouldNotHaveContent(this ElementHandle handle, string content)
        {
            if (handle.HasContent(content)) throw new ShouldException("Should not have content, but did.");
        }

        public static void ShouldNotHaveContent(this Task<ElementHandle> task, string content)
        {
            if (task.HasContent(content)) throw new ShouldException("Should not have content, but did.");
        }

        // Class

        public static void ShouldHaveClass(this ElementHandle handle, string className)
        {
            if (!handle.HasClass(className)) throw new ShouldException("Should have class, but did not.");
        }

        public static void ShouldHaveClass(this Task<ElementHandle> task, string className)
        {
            if (!task.HasClass(className)) throw new ShouldException("Should have class, but did not.");
        }

        public static void ShouldNotHaveClass(this ElementHandle handle, string className)
        {
            if (handle.HasClass(className)) throw new ShouldException("Should not have class, but did.");
        }

        public static void ShouldNotHaveClass(this Task<ElementHandle> task, string className)
        {
            if (task.HasClass(className)) throw new ShouldException("Should not have class, but did.");
        }
    }
}