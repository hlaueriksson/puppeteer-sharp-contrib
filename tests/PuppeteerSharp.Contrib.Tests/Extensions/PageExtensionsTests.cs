using System.Linq;
using System.Threading.Tasks;
using PuppeteerSharp.Contrib.Extensions;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Extensions
{
    public class PageExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync("<html><body><div id='foo'>Foo</div><div id='bar'>Bar</div><div id='baz'>Baz</div></body></html>");

        [Fact]
        public async Task QuerySelectorWithContentAsync_should_return_the_first_element_that_match_the_selector_and_has_the_content()
        {
            var foo = await Page.QuerySelectorWithContentAsync("div", "Foo");
            Assert.Equal("foo", foo.GetAttribute("id"));

            var bar = await Page.QuerySelectorWithContentAsync("div", "Ba.");
            Assert.Equal("bar", bar.GetAttribute("id"));

            var missing = await Page.QuerySelectorWithContentAsync("div", "Missing");
            Assert.Null(missing);
        }

        [Fact]
        public async Task QuerySelectorAllWithContentAsync_should_return_all_elements_that_match_the_selector_and_has_the_content()
        {
            var divs = await Page.QuerySelectorAllWithContentAsync("div", "Foo");
            Assert.Equal(new[] { "foo" }, divs.Select(x => x.GetAttribute("id")));

            divs = await Page.QuerySelectorAllWithContentAsync("div", "Ba.");
            Assert.Equal(new[] { "bar", "baz" }, divs.Select(x => x.GetAttribute("id")));

            var missing = await Page.QuerySelectorAllWithContentAsync("div", "Missing");
            Assert.Empty(missing);
        }
    }
}