using Domain.Entities;
using Orleans;
using Orleans.Services;

namespace Grains.Abstractions
{
    public interface IPlanetSpeciesServiceGrain : IGrainService
    {
        Task AddPlanetSpecies(PlanetSpecies planetSpecies);
    }
}
