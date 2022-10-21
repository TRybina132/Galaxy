using Orleans;

namespace Grains.Abstractions
{
    public interface IPlanetGrain : IGrainWithStringKey
    {
        Task SayHello();
    }
}
