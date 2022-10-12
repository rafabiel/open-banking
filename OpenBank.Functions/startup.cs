using System.IO;
using System.Reflection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OpenBank.Domain;
using OpenBank.Functions;
using OpenBank.Plaid;

[assembly: FunctionsStartup(typeof(Startup))]
namespace OpenBank.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            builder.AddDomain(config);
            builder.AddPlaid(config);
        }
    }
}