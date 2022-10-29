using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using ManagedCode.Repository.AzureTable;
using Orleans;

namespace Grains.Implementations
{
    public class SpeciesGrain : Grain, ISpeciesGrain
    {
        private readonly ISpeciesRepository speciesRepository;
        private readonly ISpeciesQuery speciesQuery;

        public SpeciesGrain(ISpeciesRepository speciesRepository, ISpeciesQuery speciesQuery)
        {
            this.speciesRepository = speciesRepository;
            this.speciesQuery = speciesQuery;
        }

        public async Task<List<Species>> GetAllSpecies() =>
            await speciesQuery.GetAll();

        public async Task AddSpecies(Species species)
        {
            species.PartitionKey = "Species";
            species.RowKey = species.Name;
            await speciesRepository.InsertAsync(species);
        }

        public async Task DeleteSpecies(string speciesId)
        {
            await speciesRepository.DeleteAsync(speciesId);
        }
    }
}
