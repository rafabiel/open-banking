using Newtonsoft.Json;

namespace OpenBank.Plaid.Utils
{
    public class PlaidConfig
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Webhook { get; set; }
        
        public string ClientName { get; set; }
        
        public string Language { get; set;  }
        
        public List<string>? Countries { get;  set; }
        
        public List<string>? Products { get; set;  }
        
        public List<string>? Filters { get; set;  }
        
        public string Environment { get; set; }
    }
}