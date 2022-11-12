using GalaxyApp.ApiClients.Realizations;
using GalaxyApp.ApiClients.Realizations.Abstractions;

namespace GalaxyApp.ApiClients.Configuration
{
    public static class ClientConfiguration
    {
        public static void AddApiClients(this IServiceCollection services)
        {
            services.AddScoped<ISpeciesHttpClient, SpeciesHttpClient>();
            services.AddScoped<IPlanetHttpClient, PlanetHttpClient>();
            services.AddScoped<IAuthHttpClient, AuthHttpClient>();
        }
    }
}
