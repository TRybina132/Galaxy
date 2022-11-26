using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface ISpeciesGrain : IGrainWithStringKey
    {
        Task<List<Species>> GetAllSpecies();
        Task<Species> FindSpeciesByName(string name);
        Task<Species> FindSpeciesById(string id);
        Task AddSpecies(Species species);
        Task IncrementPopulation(string speciesName);
    }
}
