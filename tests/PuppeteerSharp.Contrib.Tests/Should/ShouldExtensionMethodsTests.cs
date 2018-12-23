using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Should;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ShouldExtensionMethodsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Fact]
        public async Task ShouldExist_should_not_throw_for_existing_element()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            tweet.ShouldExist();

            var tweetTask = Page.QuerySelectorAsync(".tweet");
            tweetTask.ShouldExist();
        }

        [Fact]
        public async Task ShouldExist_should_throw_for_non_existing_element()
        {
            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.Throws<ShouldException>(() => missing.ShouldExist());

            var missingTask = Page.QuerySelectorAsync(".missing");
            Assert.Throws<ShouldException>(() => missingTask.ShouldExist());
        }
    }
}