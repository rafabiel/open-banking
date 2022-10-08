using Newtonsoft.Json;
using OpenBank.Domain.Interfaces.Models;

namespace OpenBank.Plaid.Responses
{
    public class LinkTokenResponse
    {
        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("link_token")]
        public string LinkToken { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}