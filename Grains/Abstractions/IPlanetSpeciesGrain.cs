using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{

    // TODO: make IServiceGrain
    public interface IPlanetSpeciesGrain : IGrainWithStringKey
    {
        Task AddPlanetSpecies(PlanetSpecies planetSpecies);
    }
}
