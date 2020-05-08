using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PuppeteerSharp.Contrib.Tests")]

namespace PuppeteerSharp.Contrib.Should
{
    internal class ShouldMessage
    {
        private string Expected { get; }

        private string Because { get; set; }

        private string Actual { get; }

        public ShouldMessage(string expected, string because, string actual)
        {
            Expected = expected;
            Because = because;
            Actual = actual;
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Actual)) return $"{Expected}{BecausePhrase()}.";

            return $"{Expected}{BecausePhrase()}, {Actual}.";
        }

        private string BecausePhrase()
        {
            if (string.IsNullOrWhiteSpace(Because)) return string.Empty;

            const string prefix = "because";
            const string space = " ";

            Because = Because.Trim();
            if (!Because.StartsWith(prefix)) Because = prefix + space + Because;
            return space + Because;
        }
    }
}
