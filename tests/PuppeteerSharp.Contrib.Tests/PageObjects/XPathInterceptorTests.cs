using System.Threading.Tasks;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using PuppeteerSharp.Contrib.Tests.Base;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    [Collection(PuppeteerFixture.Name)]
    public class XPathInterceptorTests : PuppeteerPageBaseTest
    {
        private XPathInterceptor _subject;
        private FakePageObject _pageObject;
        private FakeElementObject _elementObject;

        protected override async Task SetUp()
        {
            await Page.SetContentAsync(Fake.Html);

            _subject = new XPathInterceptor();
            _pageObject = new FakePageObject();
            _pageObject.Initialize(Page, null);
            _elementObject = new FakeElementObject();
            _elementObject.Initialize(Page, await Page.QuerySelectorAsync("html"));
        }

        // PageObject

        [Fact]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_ElementHandle_array_for_property_on_PageObject_marked_with_XPathAttribute()
        {
            var methodInfo = _pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _pageObject);

            _subject.Intercept(invocation);
            var result = await (Task<ElementHandle[]>)invocation.ReturnValue;

            Assert.NotNull(result);
            Assert.IsType<ElementHandle[]>(result);
        }

        // ElementObject

        [Fact]
        public async Task Intercept_sets_the_ReturnValue_to_Task_of_ElementHandle_array_for_property_on_ElementObject_marked_with_XPathAttribute()
        {
            var methodInfo = _elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo, _elementObject);

            _subject.Intercept(invocation);
            var result = await (Task<ElementHandle[]>)invocation.ReturnValue;

            Assert.NotNull(result);
            Assert.IsType<ElementHandle[]>(result);
        }
    }
}