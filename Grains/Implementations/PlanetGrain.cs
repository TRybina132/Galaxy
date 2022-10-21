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

        public Task SayHello()
        {
            Console.WriteLine("Hello, client!");
            return Task.CompletedTask;
        }
    }
}
