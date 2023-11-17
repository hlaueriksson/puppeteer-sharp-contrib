using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ResponseShouldExtensionsTests : PuppeteerPageBaseTest
    {
        [Test]
        public async Task ShouldHaveUrl_throws_if_response_does_not_have_the_url()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            response.ShouldHaveUrl("pupp.");

            var ex = Assert.Throws<ShouldException>(() => response.ShouldHaveUrl("Miss.", RegexOptions.IgnoreCase));
            Assert.AreEqual("Expected response to have URL \"Miss.\" (IgnoreCase), but found \"https://github.com/hardkoded/puppeteer-sharp\".", ex.Message);
        }

        [Test]
        public async Task ShouldNotHaveUrl_throws_if_response_has_the_url()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            response.ShouldNotHaveUrl("Miss.");

            var ex = Assert.Throws<ShouldException>(() => response.ShouldNotHaveUrl("pupp.", RegexOptions.IgnoreCase));
            Assert.AreEqual("Expected response not to have URL \"pupp.\" (IgnoreCase).", ex.Message);
        }
    }
}
