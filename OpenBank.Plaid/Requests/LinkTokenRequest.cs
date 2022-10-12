using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OpenBank.Plaid.Utils;

namespace OpenBank.Plaid.Requests
{
    public class LinkTokenRequest : BasePlaidRequest
    {
        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        [JsonProperty("country_codes")]
        public List<string>? CountryCodes { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("user")]
        public UserRequest User { get; set; }

        [JsonProperty("products")]
        public List<string>? Products { get; set; }

        [JsonProperty("webhook")]
        public new string Webhook { get; set; }
    }
}