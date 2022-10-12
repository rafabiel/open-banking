using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using OpenBank.Plaid.Requests;

namespace OpenBank.Plaid.Utils
{
    public class BasePlaidRequest
    {
        [Required] 
        [JsonProperty("client_id")] 
        public string ClientId { get; set; }

        [Required] 
        [JsonProperty("secret")] 
        public string ClientSecret { get; set; }
    }
}