using ApiClients.Realizations;
using ApiClients.Realizations.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ApiClients.Configuration
{
    public static class ClientConfiguration
    {
        public static void AddApiClients(this IServiceCollection services)
        {
            services.AddScoped<IPlanetHttpClient, PlanetHttpClient>();
            services.AddScoped<IAuthHttpClient, AuthHttpClient>();
        }
    }
}
