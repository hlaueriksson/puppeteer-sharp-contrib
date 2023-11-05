namespace PuppeteerSharp.Contrib.PageObjects
{
    /// <summary>
    /// <para>Base class for element objects.</para>
    /// <para>Create element objects by inheriting <see cref="ElementObject"/> and declare properties decorated with <see cref="SelectorAttribute"/>.</para>
    /// </summary>
    /// <example>
    /// Usage:
    /// <code>
    /// <![CDATA[
    /// public class BarElementObject : ElementObject
    /// {
    ///     [Selector("#foo")]
    ///     public virtual Task<IElementHandle> SelectorForElementHandle { get; }
    ///
    ///     [Selector(".bar")]
    ///     public virtual Task<IElementHandle[]> SelectorForElementHandleArray { get; }
    ///
    ///     [Selector("#foo")]
    ///     public virtual Task<FooElementObject> SelectorForElementObject { get; }
    ///
    ///     [Selector(".bar")]
    ///     public virtual Task<BarElementObject[]> SelectorForElementObjectArray { get; }
    /// }
    /// ]]>
    /// </code>
    /// </example>
    public abstract class ElementObject
    {
        /// <summary>
        /// The <c>PuppeteerSharp</c> page.
        /// </summary>
        public IPage Page { get; private set; } = null!;

        /// <summary>
        /// The <c>PuppeteerSharp</c> element handle.
        /// </summary>
        public IElementHandle Element { get; private set; } = null!;

        internal void Initialize(IPage page, IElementHandle element)
        {
            Page = page;
            Element = element;
        }
    }
}
