using Domain.Entities;
using Grains.Abstractions;
using Grains.Clients.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using ManagedCode.Repository.AzureTable;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains.Implementations
{
    public class PlanetGrain : Grain, IPlanetGrain
    {
        private readonly IPlanetRepository planetRepository;
        private readonly IPlanetQuery planetQuery;
        private readonly IPlanetSpeciesClient planetSpeciesClient;
        
        private Planet? planet;

        public PlanetGrain(
            IPlanetRepository planetRepository,
            IPlanetQuery planetQuery,
            IPlanetSpeciesClient planetSpeciesClient)
        {
            this.planetRepository = planetRepository;
            this.planetQuery = planetQuery;
            this.planetSpeciesClient = planetSpeciesClient;
        }

        public override async Task OnActivateAsync()
        {
            // TODO: handle exception in all grains, those have entity
            try
            {
                planet = await planetQuery.GetPlanetById(this.GetPrimaryKeyString());
            }
            catch (Exception ex)
            {
                return;
            }
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
            Task.FromResult(planet) ?? throw new Exception($"There no planet with id: {this.GetPrimaryKeyString()}");

        public async Task AddSpeciesToPlanet(string planetId, Species species) =>
            await planetSpeciesClient.AddPlanetSpecies(new PlanetSpecies
            {
                RowKey = planetId,
                PlanetName = planet.Name,
                SpeciesName = species.Name
            });

        public Task SayHello()
        {
            Console.WriteLine("Hello, client!");
            return Task.CompletedTask;
        }
    }
}
