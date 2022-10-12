using Newtonsoft.Json;

namespace OpenBank.Plaid.Requests
{
    public class UserRequest
    {
        public UserRequest(Guid clientUserId)
            => ClientUserId = clientUserId;
        
        [JsonProperty("client_user_id")]
        public Guid ClientUserId { get; set; }
    }
}