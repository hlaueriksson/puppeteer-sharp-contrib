using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class ElementHandleExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div class='tweet'><div class='like'>100</div><div class='retweets'>10</div></div></body></html>");

        [Fact]
        public async Task Exists_should_return_true_for_existing_element()
        {
            var tweet = await Page.QuerySelectorAsync(".tweet");
            Assert.True(tweet.Exists());

            var tweetTask = Page.QuerySelectorAsync(".tweet");
            Assert.True(tweetTask.Exists());
        }

        [Fact]
        public async Task Exists_should_return_false_for_non_existing_element()
        {
            var missing = await Page.QuerySelectorAsync(".missing");
            Assert.False(missing.Exists());

            var missingTask = Page.QuerySelectorAsync(".missing");
            Assert.False(missingTask.Exists());
        }
    }
}