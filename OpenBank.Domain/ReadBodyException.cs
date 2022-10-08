namespace OpenBank.Domain
{
    public class ReadBodyException : Exception
    {
        public string Content { get; }

        public ReadBodyException(string content, Exception innerException) : base("Read Body Error", innerException)
        {
            Content = content;
        }
    }
}