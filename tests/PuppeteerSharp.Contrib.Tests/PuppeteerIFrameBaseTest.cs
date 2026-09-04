using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuppeteerSharp.Contrib.Tests
{
    public abstract class PuppeteerIFrameBaseTest : PuppeteerPageBaseTest
    {
        protected IFrame IFrame { get; private set; }

        protected const string IFrameId = "frameId";

        protected async Task AppendFrameAsync(IPage page, string frameId, string url)
        {
            await page.EvaluateFunctionAsync(@"(frameId, url) => {
              const frame = document.createElement('iframe');
              frame.src = url;
              frame.id = frameId;
              document.body.appendChild(frame);
              return new Promise(x => frame.onload = x);
            }", frameId, url);
        }

        protected async Task NavigateFrameAsync(IPage page, string frameId, string url)
        {
            await page.EvaluateFunctionAsync(@"function navigateFrame(frameId, url) {
              const frame = document.getElementById(frameId);
              frame.src = url;
              return new Promise(x => frame.onload = x);
            }", frameId, url);
        }
        protected async Task BlankFrame(string frameId) => await NavigateFrameAsync(Page, frameId, "about:blank");

        /// <remarks>
        /// Seems like neither srcdoc attribute, nor loading html from filesystem are working, so tests here are a bit fragile, cause rely on a public common url.
        /// </remarks>
        protected override async Task SetUp()
        {
            await Page.SetContentAsync("<html></html>");
            await AppendFrameAsync(Page, IFrameId, "https://wikipedia.org");
            await Page.WaitForSelectorAsync("iframe");
            var frames = Page.Frames;
            IFrame = frames.First(f => f.ParentFrame == Page.MainFrame);
        }
    }
}
