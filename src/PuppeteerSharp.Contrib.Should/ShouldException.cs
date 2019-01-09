using System;

namespace PuppeteerSharp.Contrib.Should
{
    /// <summary>
    /// Exception thrown when a should assertion fails.
    /// </summary>
    public class ShouldException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShouldException"/> class.
        /// </summary>
        /// <param name="message">A failure message</param>
        public ShouldException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShouldException"/> class.
        /// </summary>
        /// <param name="message">A failure message</param>
        /// <param name="innerException">The exception that is the cause of the current exception</param>
        public ShouldException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}