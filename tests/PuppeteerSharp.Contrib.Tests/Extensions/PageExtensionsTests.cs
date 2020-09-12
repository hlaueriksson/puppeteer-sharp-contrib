using System;
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
            Assert.Equal("foo", await foo.IdAsync());

            var bar = await Page.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", await bar.IdAsync());

            var flags = await Page.QuerySelectorWithContentAsync("div", "foo", "i");
            Assert.Equal("foo", await flags.IdAsync());

            var missing = await Page.QuerySelectorWithContentAsync("div", "Missing");
            Assert.Null(missing);

            await Assert.ThrowsAsync<ArgumentNullException>(() => ((Page)null).QuerySelectorWithContentAsync("", ""));
        }

        [Fact]
        public async Task QuerySelectorAllWithContentAsync_should_return_all_elements_that_match_the_selector_and_has_the_content()
        {
            var divs = await Page.QuerySelectorAllWithContentAsync("div", "Foo");
            Assert.Equal(new[] { "foo" }, await Task.WhenAll(divs.Select(x => x.IdAsync())));

            divs = await Page.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, await Task.WhenAll(divs.Select(x => x.IdAsync())));

            var flags = await Page.QuerySelectorAllWithContentAsync("div", "foo", "i");
            Assert.Equal(new[] { "foo" }, await Task.WhenAll(flags.Select(x => x.IdAsync())));

            var missing = await Page.QuerySelectorAllWithContentAsync("div", "Missing");
            Assert.Empty(missing);

            await Assert.ThrowsAsync<ArgumentNullException>(() => ((Page)null).QuerySelectorAllWithContentAsync("", ""));
        }

        [Fact]
        public async Task HasContentAsync_should_return_true_if_page_has_the_content()
        {
            Assert.True(await Page.HasContentAsync("Ba."));
            Assert.True(await Page.HasContentAsync("ba.", "i"));
            Assert.False(await Page.HasContentAsync("Missing"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => ((Page)null).HasContentAsync(""));
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
            Assert.True(await Page.HasTitleAsync("ba.", "i"));
            Assert.False(await Page.HasTitleAsync("Missing"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => ((Page)null).HasTitleAsync(""));
        }
    }
}
