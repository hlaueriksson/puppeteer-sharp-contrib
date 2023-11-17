using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PuppeteerSharp.Contrib.Tests.Should
{
    public class FakeResponse : IResponse
    {
        public string Url { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public HttpStatusCode Status { get; set; }

        public bool Ok { get; set; }

        public IRequest Request { get; set; }

        public bool FromCache { get; set; }

        public SecurityDetails SecurityDetails { get; set; }

        public bool FromServiceWorker { get; set; }

        public string StatusText { get; set; }

        public RemoteAddress RemoteAddress { get; set; }

        public IFrame Frame { get; set; }

        public ValueTask<byte[]> BufferAsync() => throw new System.NotImplementedException();
        public Task<JObject> JsonAsync() => throw new System.NotImplementedException();
        public Task<T> JsonAsync<T>() => throw new System.NotImplementedException();
        public Task<string> TextAsync() => throw new System.NotImplementedException();
    }
}
