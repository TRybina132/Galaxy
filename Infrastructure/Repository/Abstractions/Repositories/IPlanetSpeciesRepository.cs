using Domain.Entities;
using ManagedCode.Repository.AzureTable;

namespace Infrastructure.Repository.Abstractions.Repositories
{
    public interface IPlanetSpeciesRepository : IAzureTableRepository<PlanetSpecies>
    {
    }
}
