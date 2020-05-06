using System;

namespace PuppeteerSharp.Contrib.Should
{
    internal static class InternalExtensions
    {
        internal static Page GuardFromNull(this Page page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));

            return page;
        }
    }
}
