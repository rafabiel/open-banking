using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenBank.Domain.Interfaces.Services;
using OpenBank.Plaid.Interfaces;
using OpenBank.Plaid.Services;
using OpenBank.Plaid.Utils;
using Refit;

namespace OpenBank.Plaid
{
    public static class Setup
    {
        public static void AddPlaid(this IFunctionsHostBuilder builder, IConfigurationRoot configuration)
        {
            var services = builder.Services;
            
            services.Configure<PlaidConfig>(configuration.GetSection("Providers:Plaid:Config"));
            services.Configure<BasePlaidRequest>(configuration.GetSection("Providers:Plaid:Credentials"));

            services.AddRefitClient<IPlaidApi>(new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        }
                    )
                })
                .ConfigureHttpClient(c =>
                    {
                        c.BaseAddress = new Uri($"https://{configuration["Providers:Plaid:Credentials:Environment"]}.plaid.com");
                        c.DefaultRequestHeaders.Add("Plaid-Version", "2020-09-14");
                    }
                );
            
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<ITransactionService, TransactionService>();
        }
    }
}