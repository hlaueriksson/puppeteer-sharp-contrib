using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using NUnit.Framework;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    
    public class PageShouldExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp () => await Page.SetContentAsync(
            "<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Test]
        public async Task ShouldHaveContentAsync_throws_if_element_does_not_have_the_content()
        {
            await Page.ShouldHaveContentAsync("10.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldHaveContentAsync("20.", "i"));
            Assert.AreEqual("Expected page to have content \"/20./i\", but it did not.", ex.Message);
        }

        [Test]
        public async Task ShouldNotHaveContentAsync_throws_if_element_has_the_content()
        {
            await Page.ShouldNotHaveContentAsync("20.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldNotHaveContentAsync("10.", "i"));
            Assert.AreEqual("Expected page not to have content \"/10./i\".", ex.Message);
        }

        [Test]
        public async Task ShouldHaveTitleAsync_throws_if_element_does_not_have_the_title()
        {
            await Page.SetContentAsync("<html><head><title>100</title></head></html>");

            await Page.ShouldHaveTitleAsync("10.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldHaveTitleAsync("20.", "i"));
            Assert.AreEqual("Expected page to have title \"/20./i\", but found \"100\".", ex.Message);
        }

        [Test]
        public async Task ShouldNotHaveTitleAsync_throws_if_element_has_the_content()
        {
            await Page.SetContentAsync("<html><head><title>100</title></head></html>");

            await Page.ShouldNotHaveTitleAsync("20.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldNotHaveTitleAsync("10.", "i"));
            Assert.AreEqual("Expected page not to have title \"/10./i\".", ex.Message);
        }
    }
}
