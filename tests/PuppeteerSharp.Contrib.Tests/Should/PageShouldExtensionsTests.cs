using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class PageShouldExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync(
            "<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Test]
        public async Task ShouldHaveContentAsync_throws_if_page_does_not_have_the_content()
        {
            await Page.ShouldHaveContentAsync("10.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldHaveContentAsync("20.", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected page to have content \"/20./i\", but it did not."));
        }

        [Test]
        public async Task ShouldNotHaveContentAsync_throws_if_page_has_the_content()
        {
            await Page.ShouldNotHaveContentAsync("20.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldNotHaveContentAsync("10.", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected page not to have content \"/10./i\"."));
        }

        [Test]
        public async Task ShouldHaveTitleAsync_throws_if_page_does_not_have_the_title()
        {
            await Page.SetContentAsync("<html><head><title>100</title></head></html>");

            await Page.ShouldHaveTitleAsync("10.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldHaveTitleAsync("20.", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected page to have title \"/20./i\", but found \"100\"."));
        }

        [Test]
        public async Task ShouldNotHaveTitleAsync_throws_if_page_has_the_title()
        {
            await Page.SetContentAsync("<html><head><title>100</title></head></html>");

            await Page.ShouldNotHaveTitleAsync("20.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldNotHaveTitleAsync("10.", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected page not to have title \"/10./i\"."));
        }

        [Test]
        public async Task ShouldHaveUrlAsync_throws_if_page_does_not_have_the_url()
        {
            await Page.ShouldHaveUrlAsync("bla.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldHaveUrlAsync("Miss.", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected page to have URL \"/Miss./i\", but found \"about:blank\"."));
        }

        [Test]
        public async Task ShouldNotHaveUrlAsync_throws_if_page_has_the_url()
        {
            await Page.ShouldNotHaveUrlAsync("Miss.");

            var ex = Assert.ThrowsAsync<ShouldException>(async () => await Page.ShouldNotHaveUrlAsync("bla.", "i"));
            Assert.That(ex.Message, Is.EqualTo("Expected page not to have URL \"/bla./i\"."));
        }
    }
}
