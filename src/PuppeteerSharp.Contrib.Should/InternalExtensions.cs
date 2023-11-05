using System;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class InternalExtensions
    {
        internal static IPage GuardFromNull(this IPage page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));

            return page;
        }
    }
}
