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

            Assert.That(response.HasUrl("pupp."));
            Assert.That(response.HasUrl("Pupp.", RegexOptions.IgnoreCase));
            Assert.That(response.HasUrl("Missing"), Is.False);
            Assert.Throws<ArgumentNullException>(() => ((IResponse)null).HasUrl(""));
        }
    }
}
