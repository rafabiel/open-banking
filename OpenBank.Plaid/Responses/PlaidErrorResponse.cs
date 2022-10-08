using Newtonsoft.Json;

namespace OpenBank.Plaid.Responses
{
    public class PlaidErrorResponse
    {
        [JsonProperty("display_message")]
        public object DisplayMessage { get; set; }

        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("suggested_action")]
        public object SuggestedAction { get; set; }
    }
}