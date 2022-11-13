using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface IPlanetSpeciesGrain : IGrainWithStringKey
    {
        Task AddPlanetSpecies(PlanetSpecies planetSpecies);
        Task<List<Species>> GetSpeciesForPlanet(string planetName);
    }
}
