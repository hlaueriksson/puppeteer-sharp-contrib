using System;

namespace PuppeteerSharp.Contrib.Should
{
    internal class ShouldMessage
    {
        public ShouldMessage(string expected, string? because, string? actual)
        {
            Expected = expected;
            Because = because;
            Actual = actual;
        }

        private string Expected { get; }

        private string? Because { get; set; }

        private string? Actual { get; }

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

            Because = Because!.Trim();
            if (!Because.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase)) Because = prefix + space + Because;
            return space + Because;
        }
    }
}
