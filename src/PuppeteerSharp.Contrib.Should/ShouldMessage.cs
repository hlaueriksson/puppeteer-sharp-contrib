namespace PuppeteerSharp.Contrib.Should
{
    internal class ShouldMessage
    {
        private string Message { get; }
        private string CustomMessage { get; }

        public ShouldMessage(string message, string customMessage)
        {
            Message = message;
            CustomMessage = customMessage;
        }

        public override string ToString()
        {
            if (CustomMessage == null) return Message;

            return Message + "\nAdditional Info: " + CustomMessage;
        }
    }
}