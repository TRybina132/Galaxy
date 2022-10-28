using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Repositories;
using Microsoft.OData.Edm;
using Orleans;
using Orleans.Streams;

namespace Grains.Implementations
{
    //  💫 Grain with the same Id as stream will be created and handle message ✨
    [ImplicitStreamSubscription("CreatePlanetSpecies")]
    public class PlanetSpeciesGrain : Grain, IPlanetSpeciesGrain
    {
        private readonly IPlanetSpeciesRepository planetSpeciesRepository;

        public PlanetSpeciesGrain(IPlanetSpeciesRepository planetSpeciesRepository)
        {
            this.planetSpeciesRepository = planetSpeciesRepository;
        }

        public override async Task OnActivateAsync()
        {
            Guid guid = this.GetPrimaryKey();
            var streamProvider = GetStreamProvider("SpeciesProvider");
            var stream = streamProvider.GetStream<PlanetSpecies>(guid,"CreatePlanetSpecies");
            await stream.SubscribeAsync(async (data, token) => await AddPlanetSpecies(data));
        }

        public async Task AddPlanetSpecies(PlanetSpecies planetSpecies)
        {
            planetSpecies.PartitionKey = planetSpecies.PlanetName;
            await planetSpeciesRepository.InsertAsync(planetSpecies);
        } 
    }
}
