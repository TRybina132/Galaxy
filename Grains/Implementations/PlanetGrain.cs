using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions;
using Orleans;

namespace Grains.Implementations
{
    public class PlanetGrain : Grain, IPlanetGrain
    {
        private readonly IPlanetRepository planetRepository;

        public PlanetGrain(IPlanetRepository planetRepository)
        {
            this.planetRepository = planetRepository;
        }

        public async Task<List<Planet>> GetAllPlanets() =>
            await planetRepository.GetAllAsync().ToListAsync();

        public async Task InsertPlanet(Planet planet)
        {
            planet.PartitionKey = "Planet";
            await planetRepository.InsertAsync(planet);
        }

        public Task SayHello()
        {
            Console.WriteLine("Hello, client!");
            return Task.CompletedTask;
        }
    }
}
