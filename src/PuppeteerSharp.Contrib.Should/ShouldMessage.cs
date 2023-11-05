using System;

namespace PuppeteerSharp.Contrib.Should
{
    internal class ShouldMessage(string expected, string? because, string? actual)
    {
        private string Expected { get; } = expected;

        private string? Because { get; set; } = because;

        private string? Actual { get; } = actual;

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
