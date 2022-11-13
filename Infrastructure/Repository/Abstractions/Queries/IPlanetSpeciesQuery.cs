using Domain.Entities;
using Infrastructure.Repository.Core.Abstractions;

namespace Infrastructure.Repository.Abstractions.Queries
{
    public interface IPlanetSpeciesQuery : IBaseQuery<PlanetSpecies>
    {
        Task<List<Species>> GetSpeciesForPlanet(string planetName);
    }
}
