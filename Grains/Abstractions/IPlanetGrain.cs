using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface IPlanetGrain : IGrainWithStringKey
    {
        Task SayHello();
        Task AddSpeciesToPlanet(string planetId, Species species);
        Task<List<Planet>> GetAllPlanets();
        Task InsertPlanet(Planet planet);
        Task DeletePlanet(string planetId);
        Task UpdatePlanet(Planet planet);
        Task<Planet> GetPlanet();
    }
}
