using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Orleans;
using Orleans.Concurrency;
using Orleans.Core;
using Orleans.Runtime;
using Orleans.Services;
using Orleans.Streams;

namespace Grains.Implementations
{
    //  💫 Grain with the same Id as stream will be created if not exists
    //          and handle message ✨
    // TODO: create stream for messaging when chat is ready 
    // [ImplicitStreamSubscription("CreatePlanetSpecies")]
    
    [Reentrant]
    public class PlanetSpeciesServiceGrain : GrainService, IPlanetSpeciesServiceGrain
    {
        private readonly IPlanetSpeciesRepository planetSpeciesRepository;
        //private StreamSubscriptionHandle<PlanetSpecies>? subscriptionHandle;

        public PlanetSpeciesServiceGrain(
            IPlanetSpeciesRepository planetSpeciesRepository,
            IGrainIdentity grainIdentity,
            Silo silo,
            ILoggerFactory loggerFactory) : base(grainIdentity, silo, loggerFactory)
        {
            this.planetSpeciesRepository = planetSpeciesRepository;
        }

        // Since it is a grain service we don't have to create instances of it
        // public override async Task OnActivateAsync()
        // {
        //     Guid guid = this.GetPrimaryKey();
        //     var streamProvider = GetStreamProvider("SpeciesProvider");
        //     var stream = streamProvider.GetStream<PlanetSpecies>(guid, "CreatePlanetSpecies");
        //     subscriptionHandle = await stream
        //             .SubscribeAsync(async (data, token) => await AddPlanetSpecies(data));
        //
        //     //  ✨ Receiving all events that occured during failture 💫 
        //     await subscriptionHandle.ResumeAsync(async events =>
        //     {
        //         foreach (var item in events)
        //             await AddPlanetSpecies(item.Item);
        //     });
        // }

        public async Task AddPlanetSpecies(PlanetSpecies planetSpecies)
        {
            planetSpecies.PartitionKey = planetSpecies.PlanetName;
            await planetSpeciesRepository.InsertAsync(planetSpecies);
        } 
    }
}
