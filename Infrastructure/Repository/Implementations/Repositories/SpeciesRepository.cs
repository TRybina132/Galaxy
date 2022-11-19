using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Repositories;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Repositories
{
    internal class SpeciesRepository : BaseRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(IOptions<AzureTableOptions> options) 
            : base(options) { }

        public async Task IncrementPopulation(string speciesName)
        {
            Species? species = 
                await tableClient.QueryAsync<Species>(species => species.Name == speciesName).FirstOrDefaultAsync();

            if (species == null)
                return;
            species.SpeciesCount++;
            
            await UpdateAsync(species);
        }
    }
}
