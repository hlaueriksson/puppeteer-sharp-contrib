using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.Should;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class ResponseShouldExtensionsTests : PuppeteerPageBaseTest
    {
        [Test]
        public async Task ShouldHaveUrl_throws_if_response_does_not_have_the_url()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            response.ShouldHaveUrl("pupp.");

            var ex = Assert.Throws<ShouldException>(() => response.ShouldHaveUrl("Miss.", RegexOptions.IgnoreCase));
            Assert.That(ex.Message, Is.EqualTo("Expected response to have URL \"Miss.\" (IgnoreCase), but found \"https://github.com/hardkoded/puppeteer-sharp\"."));
        }

        [Test]
        public async Task ShouldNotHaveUrl_throws_if_response_has_the_url()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            response.ShouldNotHaveUrl("Miss.");

            var ex = Assert.Throws<ShouldException>(() => response.ShouldNotHaveUrl("pupp.", RegexOptions.IgnoreCase));
            Assert.That(ex.Message, Is.EqualTo("Expected response not to have URL \"pupp.\" (IgnoreCase)."));
        }

        [Test]
        public async Task ShouldHaveStatusCode_throws_if_response_does_not_have_the_status_code()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            response.ShouldHaveStatusCode(HttpStatusCode.OK);

            var ex = Assert.Throws<ShouldException>(() => response.ShouldHaveStatusCode(HttpStatusCode.InternalServerError));
            Assert.That(ex.Message, Is.EqualTo("Expected response to have status code \"InternalServerError\", but found \"OK\"."));
        }

        [Test]
        public async Task ShouldNotHaveStatusCode_throws_if_response_has_the_status_code()
        {
            var response = await Page.GoToAsync("https://github.com/hardkoded/puppeteer-sharp");

            response.ShouldNotHaveStatusCode(HttpStatusCode.InternalServerError);

            var ex = Assert.Throws<ShouldException>(() => response.ShouldNotHaveStatusCode(HttpStatusCode.OK));
            Assert.That(ex.Message, Is.EqualTo("Expected response not to have status code \"OK\"."));
        }

        [Test]
        public void ShouldBeSuccessful_throws_if_response_does_not_have_status_2xx()
        {
            new FakeResponse { Ok = true }.ShouldBeSuccessful();

            var ex = Assert.Throws<ShouldException>(() => new FakeResponse { Ok = false, Status = HttpStatusCode.InternalServerError }.ShouldBeSuccessful());
            Assert.That(ex.Message, Is.EqualTo("Expected response status to be successful (2xx), but found \"InternalServerError\"."));
        }

        [Test]
        public void ShouldBeRedirection_throws_if_response_does_not_have_status_3xx()
        {
            new FakeResponse { Status = HttpStatusCode.Moved }.ShouldBeRedirection();

            var ex = Assert.Throws<ShouldException>(() => new FakeResponse { Status = HttpStatusCode.OK }.ShouldBeRedirection());
            Assert.That(ex.Message, Is.EqualTo("Expected response status to be redirection (3xx), but found \"OK\"."));
        }

        [Test]
        public void ShouldHaveClientError_throws_if_response_does_not_have_status_4xx()
        {
            new FakeResponse { Status = HttpStatusCode.BadRequest }.ShouldHaveClientError();

            var ex = Assert.Throws<ShouldException>(() => new FakeResponse { Status = HttpStatusCode.OK }.ShouldHaveClientError());
            Assert.That(ex.Message, Is.EqualTo("Expected response status to be client error (4xx), but found \"OK\"."));
        }

        [Test]
        public void ShouldHaveServerError_throws_if_response_does_not_have_status_5xx()
        {
            new FakeResponse { Status = HttpStatusCode.InternalServerError }.ShouldHaveServerError();

            var ex = Assert.Throws<ShouldException>(() => new FakeResponse { Status = HttpStatusCode.OK }.ShouldHaveServerError());
            Assert.That(ex.Message, Is.EqualTo("Expected response status to be server error (5xx), but found \"OK\"."));
        }

        [Test]
        public void ShouldHaveError_throws_if_response_does_not_have_status_4xx_or_5xx()
        {
            new FakeResponse { Status = HttpStatusCode.BadRequest }.ShouldHaveError();
            new FakeResponse { Status = HttpStatusCode.InternalServerError }.ShouldHaveError();

            var ex = Assert.Throws<ShouldException>(() => new FakeResponse { Status = HttpStatusCode.OK }.ShouldHaveError());
            Assert.That(ex.Message, Is.EqualTo("Expected response status to be an error, but found \"OK\"."));
        }
    }
}
