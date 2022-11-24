using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
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

        public async Task DeleteSpecies(string speciesId) =>
            await speciesRepository.DeleteAsync(speciesId);

        public async Task<Species> FindSpeciesById(string id) =>
            await speciesQuery.GetById(id) ?? throw new Exception($"Species with Id:{id} not found");

        public async Task IncrementPopulation(string speciesName) =>
            await speciesRepository.IncrementPopulation(speciesName);

        public async Task<Species> FindSpeciesByName(string name)
        {
            var species = await speciesQuery.GetSpeciesByName(name);
            return species;
        }
    }
}
