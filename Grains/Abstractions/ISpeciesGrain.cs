using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface ISpeciesGrain : IGrainWithStringKey
    {
        Task<List<Species>> GetAllSpecies();
        Task<List<Species>> GetSpeciesForPlanet(string planetName);
        Task<Species> FindSpeciesById(string id);
        Task AddSpecies(Species species);
    }
}
