using Newtonsoft.Json;

namespace OpenBank.Plaid.Responses
{
    public class ExchangeTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}