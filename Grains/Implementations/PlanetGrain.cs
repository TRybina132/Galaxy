using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using ManagedCode.Repository.AzureTable;
using Orleans;

namespace Grains.Implementations
{
    public class PlanetGrain : Grain, IPlanetGrain
    {
        private readonly IPlanetRepository planetRepository;
        private readonly IPlanetQuery planetQuery;

        private Planet? planet;

        public PlanetGrain(
            IPlanetRepository planetRepository,
            IPlanetQuery planetQuery)
        {
            this.planetRepository = planetRepository;
            this.planetQuery = planetQuery;
        }

        public override async Task OnActivateAsync()
        {
            planet = await planetQuery.GetPlanetById(this.GetPrimaryKeyString());
        }

        public async Task<List<Planet>> GetAllPlanets() =>
            await planetQuery.GetAll();

        public async Task InsertPlanet(Planet planet)
        {
            planet.PartitionKey = "Planet";
            planet.RowKey = Guid.NewGuid().ToString();
            await planetRepository.InsertAsync(planet);
        }

        public async Task DeletePlanet(string planetId) =>
            await planetRepository.DeleteAsync(new TableId("Planet", planetId));   

        public async Task UpdatePlanet(Planet planet)
        {
            planet.PartitionKey = "Planet";
            await planetRepository.UpdateAsync(planet);
        }

        public Task<Planet> GetPlanet() =>
            Task.FromResult(planet);

        public async Task AddSpeciesToPlanet(string planetId, Species species)
        {
            var streamProvider = GetStreamProvider("SpeciesProvider");
            var planet = await planetQuery.GetPlanetById(planetId);
            var stream = streamProvider.GetStream<PlanetSpecies>(Guid.NewGuid(), "CreatePlanetSpecies");
            await stream.OnNextAsync(new PlanetSpecies
            {
                RowKey = planetId,
                PlanetName = planet.Name,
                SpeciesName = species.Name
            });
        }

        public Task SayHello()
        {
            Console.WriteLine("Hello, client!");
            return Task.CompletedTask;
        }
    }
}
