using Domain.Entities;
using Grains.Abstractions;
using Orleans.Services;

namespace Grains.Clients.Abstractions;

public interface IPlanetSpeciesClient : IGrainServiceClient<IPlanetSpeciesServiceGrain>
{
    Task AddPlanetSpecies(PlanetSpecies planetSpecies);
}