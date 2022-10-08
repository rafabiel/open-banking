using Newtonsoft.Json;

namespace OpenBank.Plaid.Requests
{
    public class UserRequest
    {
        public UserRequest(Guid clientUserId)
            => ClientUserId = clientUserId;
        
        public Guid ClientUserId { get; set; }
    }
}