using System.Threading.Tasks;
using NUnit.Framework;
using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class InvocationExtensionsTests : PuppeteerPageBaseTest
    {
        protected override async Task SetUp() => await Page.SetContentAsync(Fake.Html);

        [Test]
        public void HasValidReturnType_returns_true_for_invocation_that_return_Task_of_T()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.True(invocation.HasValidReturnType());
        }

        [Test]
        public void HasValidReturnType_returns_false_for_invocation_that_does_not_return_Task_of_T()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.False(invocation.HasValidReturnType());
        }

        [Test]
        public void IsGetterPropertyWithAttribute_returns_true_for_invocation_of_getter_property_marked_with_given_attribute()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.True(invocation.IsGetterPropertyWithAttribute<SelectorAttribute>());
        }

        [Test]
        public void IsGetterPropertyWithAttribute_returns_false_for_invocation_of_non_getter_property()
        {
            var methodInfo = typeof(string).GetMethod(nameof(string.GetTypeCode));
            var invocation = new FakeInvocation(methodInfo);
            Assert.False(invocation.IsGetterPropertyWithAttribute<SelectorAttribute>());
        }

        [Test]
        public void GetAttribute_returns_the_given_attribute()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.NotNull(invocation.GetAttribute<SelectorAttribute>());
        }

        [Test]
        public void IsReturning_returns_true_for_invocation_of_method_that_returns_Task_of_given_type()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.True(invocation.IsReturning<IElementHandle>());
        }

        [Test]
        public void IsReturning_returns_false_for_invocation_of_method_that_does_not_return_Task_of_given_type()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.False(invocation.IsReturning<IElementHandle>());
        }

        [Test]
        public void IsReturningElementObject_returns_true_for_invocation_of_method_that_returns_Task_of_ElementObject_subclass()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObject)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.True(invocation.IsReturningElementObject());
        }

        [Test]
        public void IsReturningElementObject_returns_false_for_invocation_of_method_that_does_not_return_Task_of_ElementObject_subclass()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObjectWithNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.False(invocation.IsReturningElementObject());
        }

        [Test]
        public void IsReturningElementObjectArray_returns_true_for_invocation_of_method_that_returns_Task_of_ElementObject_subclass_array()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObjectArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.True(invocation.IsReturningElementObjectArray());
        }

        [Test]
        public void IsReturningElementObjectArray_returns_false_for_invocation_of_method_that_does_not_return_Task_of_ElementObject_subclass_array()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementObjectArrayWithNonTaskReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);
            Assert.False(invocation.IsReturningElementObjectArray());
        }

        // PageObject

        [Test]
        public async Task GetReturnValueAsync_returns_ElementHandle_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new SelectorAttribute(".tweet"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<IElementHandle>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementHandle_array_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new SelectorAttribute("div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<IElementHandle[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementObject_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementObject)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new SelectorAttribute(".retweets"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementObject_array_for_property_on_PageObject_marked_with_SelectorAttribute()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementObjectArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new SelectorAttribute("div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_PageObject_marked_with_SelectorAttribute_when_Page_is_null()
        {
            var pageObject = new FakePageObject();
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new SelectorAttribute(".retweets"));

            Assert.Null(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_PageObject_marked_with_SelectorAttribute_but_wrong_return_type()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.SelectorForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new SelectorAttribute(".tweet"));

            Assert.Null(result);
        }

        // ElementObject

        [Test]
        public async Task GetReturnValueAsync_returns_ElementHandle_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new SelectorAttribute(".tweet"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<IElementHandle>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementHandle_array_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new SelectorAttribute("div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<IElementHandle[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementObject_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementObject)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new SelectorAttribute(".retweets"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementObject_array_for_property_on_ElementObject_marked_with_SelectorAttribute()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementObjectArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new SelectorAttribute("div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_ElementObject_marked_with_SelectorAttribute_when_Page_is_null()
        {
            var elementObject = new FakeElementObject();
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForElementHandle)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new SelectorAttribute(".tweet"));

            Assert.Null(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_ElementObject_marked_with_SelectorAttribute_but_wrong_return_type()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.SelectorForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new SelectorAttribute(".tweet"));

            Assert.Null(result);
        }

        // PageObject

        [Test]
        public async Task GetReturnValueAsync_returns_ElementHandle_array_for_property_on_PageObject_marked_with_XPathAttribute()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new XPathAttribute("//div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<IElementHandle[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementObject_array_for_property_on_PageObject_marked_with_XPathAttribute()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForElementObjectArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new XPathAttribute("//div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_PageObject_marked_with_XPathAttribute_when_Page_is_null()
        {
            var pageObject = new FakePageObject();
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new XPathAttribute("//div"));

            Assert.Null(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_PageObject_marked_with_XPathAttribute_but_wrong_return_type()
        {
            var pageObject = new FakePageObject();
            pageObject.Initialize(Page, null);
            var methodInfo = pageObject.GetType().GetProperty(nameof(FakePageObject.XPathForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(pageObject, new XPathAttribute("//div"));

            Assert.Null(result);
        }

        // ElementObject

        [Test]
        public async Task GetReturnValueAsync_returns_ElementHandle_array_for_property_on_ElementObject_marked_with_XPathAttribute()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new XPathAttribute("//div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<IElementHandle[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_ElementObject_array_for_property_on_ElementObject_marked_with_XPathAttribute()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForElementObjectArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new XPathAttribute("//div"));

            Assert.NotNull(result);
            Assert.IsInstanceOf<FakeElementObject[]>(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_ElementObject_marked_with_XPathAttribute_when_Page_is_null()
        {
            var elementObject = new FakeElementObject();
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForElementHandleArray)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new XPathAttribute("//div"));

            Assert.Null(result);
        }

        [Test]
        public async Task GetReturnValueAsync_returns_null_for_property_on_ElementObject_marked_with_XPathAttribute_but_wrong_return_type()
        {
            var elementHandle = await Page.QuerySelectorAsync("html");
            var elementObject = new FakeElementObject();
            elementObject.Initialize(Page, elementHandle);
            var methodInfo = elementObject.GetType().GetProperty(nameof(FakeElementObject.XPathForWrongReturnType)).GetMethod;
            var invocation = new FakeInvocation(methodInfo);

            var result = await invocation.GetReturnValueAsync(elementObject, new XPathAttribute("//div"));

            Assert.Null(result);
        }
    }
}
