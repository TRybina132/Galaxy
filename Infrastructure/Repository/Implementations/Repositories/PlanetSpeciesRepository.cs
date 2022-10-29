using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Repositories;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Repositories
{
    internal class PlanetSpeciesRepository : BaseRepository<PlanetSpecies>, IPlanetSpeciesRepository
    {
        public PlanetSpeciesRepository(IOptions<AzureTableOptions> options) 
            : base(options) { }
    }
}
