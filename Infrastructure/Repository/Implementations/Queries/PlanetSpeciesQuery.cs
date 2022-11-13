using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Queries
{
    internal class PlanetSpeciesQuery : BaseQuery<PlanetSpecies>, IPlanetSpeciesQuery
    {
        public PlanetSpeciesQuery(IOptions<AzureTableOptions> options) 
            : base(options) { }

        public async Task<List<Species>> GetSpeciesForPlanet(string planetName)
        {
            var species = tableClient
                .QueryAsync<PlanetSpecies>(ps => ps.PartitionKey == planetName)
                .Select(ps =>
                {
                    return new Species
                    {
                        RowKey= ps.RowKey,
                        Name = ps.SpeciesName
                    };
                });
            return await species.ToListAsync();
        }
    }
}
