namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// Base class for element objects.
    ///
    /// Create element objects by inheriting <see cref="ElementObject" /> and declare properties decorated with <see cref="SelectorAttribute" /> or <see cref="XPathAttribute" />.
    /// </summary>
    /// <example>
    /// Usage:
    /// <code>
    /// <![CDATA[
    /// public class BarElementObject : ElementObject
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
    public abstract class ElementObject
    {
        /// <summary>
        /// The <c>PuppeteerSharp</c> page.
        /// </summary>
        public Page Page { get; private set; }

        /// <summary>
        /// The <c>PuppeteerSharp</c> element handle.
        /// </summary>
        public ElementHandle Element { get; private set; }

        internal void Initialize(Page page, ElementHandle element)
        {
            Page = page;
            Element = element;
        }
    }
}
