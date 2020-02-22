using PuppeteerSharp.Contrib.PageObjects;
using PuppeteerSharp.Contrib.PageObjects.DynamicProxy;
using Xunit;

namespace PuppeteerSharp.Contrib.Tests.PageObjects
{
    public class ReflectionExtensionsTests
    {
        [Fact]
        public void IsGetter_returns_true_for_getter_property()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsGetter());
        }

        [Fact]
        public void IsGetterPropertyWithAttribute_returns_true_for_getter_property_marked_with_given_attribute()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsGetterPropertyWithAttribute<SelectorAttribute>());
        }

        [Fact]
        public void HasAttribute_returns_true_for_property_marked_with_given_attribute()
        {
            var propertyInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle));
            Assert.True(propertyInfo.HasAttribute<SelectorAttribute>());
        }

        [Fact]
        public void GetAttribute_returns_the_given_attribute()
        {
            var propertyInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle));
            Assert.NotNull(propertyInfo.GetAttribute<SelectorAttribute>());
        }

        [Fact]
        public void IsCompilerGenerated_returns_true_for_auto_getter_property()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsCompilerGenerated());
        }

        [Fact]
        public void GetProperty_returns_PropertyInfo_for_given_getter_property_method()
        {
            var type = typeof(FakePageObject);
            var methodInfo = type.GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.NotNull(type.GetProperty(methodInfo));
        }

        [Fact]
        public void IsReturningAsyncResult_returns_true_for_methods_that_returns_Task_of_T()
        {
            var methodInfo = typeof(FakePageObject).GetProperty(nameof(FakePageObject.SelectorForElementHandle)).GetMethod;
            Assert.True(methodInfo.IsReturningAsyncResult());
        }
    }
}