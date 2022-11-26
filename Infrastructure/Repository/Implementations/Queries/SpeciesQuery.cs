using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Queries
{
    internal class SpeciesQuery : BaseQuery<Species>, ISpeciesQuery
    {
        public SpeciesQuery(IOptions<AzureTableOptions> options) : base(options) { }

        public async Task<Species> GetSpeciesByName(string name)
        {
            var result = await tableClient
                .QueryAsync<Species>(species => species.Name == name)
                .FirstOrDefaultAsync();
            return result ?? throw new Exception($"Species with name: {name} not found!");
        }
    }
}
