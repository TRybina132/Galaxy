using Domain.Communication.Planets.Results;
using Domain.Entities;
using Domain.Options;
using Grains.Abstractions;
using Microsoft.Extensions.Options;
using Orleans;

namespace Grains.Implementations
{
    public class PlanetGrain : Grain, IPlanetGrain
    {
        private readonly AzureTableOptions tableOptions;

        public PlanetGrain(IOptions<AzureTableOptions> options)
        {
            tableOptions = options.Value;
        }

        public Task<GetPlanetsResult> GetAllPlanets()
        {
            return Task.FromResult(
                new GetPlanetsResult
                {
                    IsSuccessed = true,
                    Planets = Enumerable.Empty<Planet>()
                });
        }

        public Task SayHello()
        {
            Console.WriteLine("Hello, client!");
            return Task.CompletedTask;
        }
    }
}
