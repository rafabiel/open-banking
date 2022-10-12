using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OpenBank.Domain.Utils
{
    public static class HttpUtils
    {
        public static async Task<T?> GetContentAsync<T>(this HttpResponseMessage response) where T : class
        {
            var content = await response.Content.ReadAsStringAsync();

            return !string.IsNullOrWhiteSpace(content) ? JsonConvert.DeserializeObject<T>(content) : null;
        }
        
        public static async Task<T> GetBodyAsync<T>(this HttpRequest httpRequest)
        {
            var bodyString = string.Empty;
        
            try
            {
                using var stream = new StreamReader(httpRequest.Body);
                
                bodyString = await stream.ReadToEndAsync();
                
                return JsonConvert.DeserializeObject<T>(bodyString) ?? throw new ArgumentException("Body is null");
            }
            catch (Exception e)
            {
                throw new ReadBodyException(bodyString, e);
            }
        }
    }
}