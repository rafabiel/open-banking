using Newtonsoft.Json;

namespace OpenBank.Plaid.Utils
{
    public class PlaidConfig
    {
        [JsonProperty("client_name")]
        public string ClientName { get; set; }
        
        [JsonProperty("language")]
        public string Language { get; set;  }
        
        [JsonProperty("country_codes")]
        public List<string>? Countries { get;  set; }
        
        [JsonProperty("products")]
        public List<string>? Products { get; set;  }
        
        // [JsonProperty("account_filters")]
        // public List<string>? Filters { get; set;  }
    }
}