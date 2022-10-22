using Domain.Communication.Planets.Results;
using Orleans;

namespace Grains.Abstractions
{
    public interface IPlanetGrain : IGrainWithStringKey
    {
        Task SayHello();

        Task<GetPlanetsResult> GetAllPlanets();
    }
}
