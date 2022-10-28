using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Queries
{
    internal class PlanetQuery : BaseQuery<Planet>, IPlanetQuery
    {
        public PlanetQuery(IOptions<AzureTableOptions> options) : base(options) { }

        public async Task<Planet> GetPlanetById(string planetId)
        {
            var planet = await tableClient.QueryAsync<Planet>
                (planet => planet.Id.RowKey == planetId && planet.Id.PartitionKey == partitionKey).FirstOrDefaultAsync();
            return planet ?? throw new Exception($"Planet with name: {planetId} not found!");
        }
    }
}
