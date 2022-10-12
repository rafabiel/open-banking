using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OpenBank.Domain.Utils
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        
        public static string ToJson<T>(this T value) where T : class => ToJson(value, Settings);

        private static string ToJson<T>(this T value, JsonSerializerSettings settings) where T : class => JsonConvert.SerializeObject(value, settings);
    }
}