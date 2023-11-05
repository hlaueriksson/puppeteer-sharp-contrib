namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <para>Base class for element objects.</para>
    /// <para>Create element objects by inheriting <see cref="ElementObject"/> and declare properties decorated with <see cref="SelectorAttribute"/> or <see cref="XPathAttribute"/>.</para>
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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Page Page { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// The <c>PuppeteerSharp</c> element handle.
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ElementHandle Element { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        internal void Initialize(Page page, ElementHandle element)
        {
            Page = page;
            Element = element;
        }
    }
}
