using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace OpenBank.Domain
{
    public static class Setup
    {       
        public static void AddDomain(this IFunctionsHostBuilder builder, IConfigurationRoot configuration)
        {
            var services = builder.Services;
            
            var assembly = typeof(Setup).Assembly;
            
            services.AddMediatR(assembly);
        }
    }
}