namespace PuppeteerSharp.Contrib.PageObjects
{
    public abstract class ElementObject
    {
        public Page Page { get; private set; }
        public ElementHandle Element { get; private set; }

        internal void Initialize(Page page, ElementHandle element)
        {
            Page = page;
            Element = element;
        }
    }
}