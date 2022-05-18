namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// Base class for page objects.
    ///
    /// Create page objects by inheriting <see cref="PageObject"/> and declare properties decorated with <see cref="SelectorAttribute"/> or <see cref="XPathAttribute"/>.
    /// </summary>
    /// <example>
    /// Usage:
    /// <code>
    /// <![CDATA[
    /// public class FooPageObject : PageObject
    /// {
    ///     [Selector("#foo")]
    ///     public virtual Task<ElementHandle> SelectorForElementHandle { get; }
    ///
    ///     [Selector(".bar")]
    ///     public virtual Task<ElementHandle[]> SelectorForElementHandleArray { get; }
    ///
    ///     [Selector("#foo")]
    ///     public virtual Task<FooElementObject> SelectorForElementObject { get; }
    ///
    ///     [Selector(".bar")]
    ///     public virtual Task<BarElementObject[]> SelectorForElementObjectArray { get; }
    ///
    ///     [XPath("//div")]
    ///     public virtual Task<ElementHandle[]> XPathForElementHandleArray { get; }
    ///
    ///     [XPath("//div")]
    ///     public virtual Task<FooElementObject[]> XPathForElementObjectArray { get; }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public abstract class PageObject
    {
        /// <summary>
        /// The <c>PuppeteerSharp</c> page.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Page Page { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// The response from page navigation.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Response Response { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        internal void Initialize(Page page, Response response)
        {
            Page = page;
            Response = response;
        }
    }
}
