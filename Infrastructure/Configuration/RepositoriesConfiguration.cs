using Infrastructure.Repository.Abstractions;
using Infrastructure.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlanetRepository, PlanetRepository>();
        }
    }
}
