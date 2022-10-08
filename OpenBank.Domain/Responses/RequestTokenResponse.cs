using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Domain.Responses
{
    public class RequestTokenResponse : IRequestToken
    {
        public RequestTokenResponse(DateTime expiration, string linkToken, string requestId)
        {
            Expiration = expiration;
            LinkToken = linkToken;
            RequestId = requestId;
        }

        public DateTime Expiration { get; }
        
        public string LinkToken { get; }
        
        public string RequestId { get; }
    }
}