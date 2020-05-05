using PuppeteerSharp.Contrib.Should;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ShouldMessageTests
    {
        [Fact]
        public void ToString_should_return_include_custom_message()
        {
            var subject = new ShouldMessage("Foo", "Bar");
            Assert.Equal("Foo\nAdditional Info: Bar", subject.ToString());
        }
    }
}
