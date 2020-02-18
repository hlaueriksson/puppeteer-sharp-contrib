namespace PuppeteerSharp.Contrib.PageObjects
{
    public abstract class PageObject
    {
        public Page Page { get; private set; }
        public Response Response { get; private set; }

        internal void Initialize(Page page, Response response)
        {
            Page = page;
            Response = response;
        }
    }
}