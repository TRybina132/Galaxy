using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using Infrastructure.Repository.Implementations.Queries;
using Infrastructure.Repository.Implementations.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration
{
    public static class RepositoriesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPlanetRepository, PlanetRepository>();
            services.AddScoped<IPlanetQuery, PlanetQuery>();
            services.AddScoped<ISpeciesQuery, SpeciesQuery>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            services.AddScoped<IPlanetSpeciesRepository, PlanetSpeciesRepository>();
        }
    }
}
