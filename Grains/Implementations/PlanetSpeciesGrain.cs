using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using Microsoft.OData.Edm;
using Orleans;
using Orleans.Streams;

namespace Grains.Implementations
{
    //  💫 Grain with the same Id as stream will be created if not exists
    //          and handle message ✨
    [ImplicitStreamSubscription("CreatePlanetSpecies")]
    public class PlanetSpeciesGrain : Grain, IPlanetSpeciesGrain
    {
        private readonly IPlanetSpeciesRepository planetSpeciesRepository;
        private readonly IPlanetSpeciesQuery planetSpeciesQuery; 
        private StreamSubscriptionHandle<PlanetSpecies>? subscriptionHandle;

        public PlanetSpeciesGrain(
            IPlanetSpeciesRepository planetSpeciesRepository,
            IPlanetSpeciesQuery planetSpeciesQuery)
        {
            this.planetSpeciesRepository = planetSpeciesRepository;
            this.planetSpeciesQuery = planetSpeciesQuery;
        }

        public override async Task OnActivateAsync()
        {
            //  I should use Guid format ids, because when we have string
            //      that can't be parsed to Guid it will throw exception
            try
            {
                var guid = this.GetPrimaryKey();
                var streamProvider = GetStreamProvider("SpeciesProvider");
                var stream = streamProvider.GetStream<PlanetSpecies>(guid, "CreatePlanetSpecies");
                subscriptionHandle = await stream
                        .SubscribeAsync(async (data, token) => await AddPlanetSpecies(data));

                //  ✨ Receiving all events that occured during failture 💫 
                await subscriptionHandle.ResumeAsync(async events =>
                {
                    foreach (var item in events)
                        await AddPlanetSpecies(item.Item);
                });
            }
            catch(Exception ex) { }
        }

        public async Task AddPlanetSpecies(PlanetSpecies planetSpecies) =>
            await planetSpeciesRepository.InsertAsync(planetSpecies);

        public async Task<List<Species>> GetSpeciesForPlanet(string planetName) =>
            await planetSpeciesQuery.GetSpeciesForPlanet(planetName);
    }
}
