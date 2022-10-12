using Newtonsoft.Json;
using OpenBank.Plaid.Utils;

namespace OpenBank.Plaid.Requests
{
    public class ExchangeTokenRequest : BasePlaidRequest
    {
        [JsonProperty("public_token")]
        public string PublicToken { get; set; }
    }
}