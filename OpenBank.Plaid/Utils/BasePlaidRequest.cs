using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using OpenBank.Plaid.Requests;

namespace OpenBank.Plaid.Utils
{
    public class BasePlaidRequest
    {
        [Required] 
        [JsonProperty("client_id")] public string ClientId { get; set; }

        [Required] 
        [JsonProperty("secret")] 
        public string ClientSecret { get; set; }

        [JsonIgnore] 
        public string Webhook { get; set; }

        public string MakePlaidRequest(UserRequest? user = null, object? obj = null)
        {
            if (obj == null)
                return JsonConvert.SerializeObject(this);

            var dictionary =
                JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(obj));

            if (dictionary == null)
                throw new ArgumentException("Can't create plaid config");

            dictionary["client_id"] = ClientId;
            dictionary["secret"] = ClientSecret;
            
            if(user != null)
                dictionary["user"] = new { client_user_id = user.ClientUserId };

            return JsonConvert.SerializeObject(dictionary);
        }
    }
}