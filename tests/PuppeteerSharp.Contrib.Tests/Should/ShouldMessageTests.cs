using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ShouldMessageTests
    {
        [Test]
        public void ToString_should_return_proper_assertion_message()
        {
            var subject = new ShouldMessage("Expected foo to bar", null, null);
            Assert.That(subject.ToString(), Is.EqualTo("Expected foo to bar."));

            subject = new ShouldMessage("Expected foo to bar", "it should", null);
            Assert.That(subject.ToString(), Is.EqualTo("Expected foo to bar because it should."));

            subject = new ShouldMessage("Expected foo to bar", null, "but it did not");
            Assert.That(subject.ToString(), Is.EqualTo("Expected foo to bar, but it did not."));
        }
    }
}
