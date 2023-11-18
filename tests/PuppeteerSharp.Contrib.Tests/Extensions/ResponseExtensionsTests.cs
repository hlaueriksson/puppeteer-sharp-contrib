using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Extensions;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class ResponseExtensionsTests : PuppeteerPageBaseTest
    {
        [Test]
        public async Task HasUrl_should_return_true_if_response_has_the_url()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            Assert.True(response.HasUrl("pupp."));
            Assert.True(response.HasUrl("Pupp.", RegexOptions.IgnoreCase));
            Assert.False(response.HasUrl("Missing"));
            Assert.Throws<ArgumentNullException>(() => ((IResponse)null).HasUrl(""));
        }
    }
}
