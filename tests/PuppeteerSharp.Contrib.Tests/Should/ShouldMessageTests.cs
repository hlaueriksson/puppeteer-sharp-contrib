using PuppeteerSharp.Contrib.Should;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ShouldMessageTests
    {
        [Fact]
        public void ToString_should_return_proper_assertion_message()
        {
            var subject = new ShouldMessage("Expected foo to bar", null, null);
            Assert.Equal("Expected foo to bar.", subject.ToString());

            subject = new ShouldMessage("Expected foo to bar", "it should", null);
            Assert.Equal("Expected foo to bar because it should.", subject.ToString());

            subject = new ShouldMessage("Expected foo to bar", null, "but it did not");
            Assert.Equal("Expected foo to bar, but it did not.", subject.ToString());
        }
    }
}
