using Domain.Entities;
using Grains.Abstractions;
using Grains.Clients.Abstractions;
using Orleans.Runtime.Services;

namespace Grains.Clients.Implementations;

public class PlanetSpeciesClient : GrainServiceClient<IPlanetSpeciesServiceGrain>, IPlanetSpeciesClient
{
    public PlanetSpeciesClient(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task AddPlanetSpecies(PlanetSpecies planetSpecies) =>
        await GrainService.AddPlanetSpecies(planetSpecies);
}