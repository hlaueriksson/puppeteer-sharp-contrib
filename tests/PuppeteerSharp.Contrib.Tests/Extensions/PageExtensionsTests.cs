using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    [Collection(PuppeteerFixture.Name)]
    public class PageExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync(@"
<html>
  <div id='foo'>Foo</div>
  <div id='bar'>Bar</div>
  <div id='baz'>Baz</div>
</html>");

        [Fact]
        public async Task QuerySelectorWithContentAsync_should_return_the_first_element_that_match_the_selector_and_has_the_content()
        {
            var foo = await Page.QuerySelectorWithContentAsync("div", "Foo");
            Assert.Equal("foo", foo.Id());

            var bar = await Page.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", bar.Id());

            var missing = await Page.QuerySelectorWithContentAsync("div", "Missing");
            Assert.Null(missing);
        }

        [Fact]
        public async Task QuerySelectorAllWithContentAsync_should_return_all_elements_that_match_the_selector_and_has_the_content()
        {
            var divs = await Page.QuerySelectorAllWithContentAsync("div", "Foo");
            Assert.Equal(new[] { "foo" }, divs.Select(x => x.Id()));

            divs = await Page.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, divs.Select(x => x.Id()));

            var missing = await Page.QuerySelectorAllWithContentAsync("div", "Missing");
            Assert.Empty(missing);
        }

        [Fact]
        public async Task HasContentAsync_should_return_true_if_page_has_the_content()
        {
            Assert.True(await Page.HasContentAsync("Ba."));
            Assert.False(await Page.HasContentAsync("Missing"));
        }

        [Fact]
        public async Task HasTitleAsync_should_return_true_if_page_has_the_title()
        {
            await Page.SetContentAsync(@"
<html>
 <head>
  <title>Foo Bar Baz</title>
 </head>
</html>");

            Assert.True(await Page.HasTitleAsync("Ba."));
            Assert.False(await Page.HasTitleAsync("Missing"));
        }
    }
}
