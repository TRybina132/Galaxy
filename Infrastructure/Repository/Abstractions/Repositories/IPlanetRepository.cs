using Domain.Entities;
using ManagedCode.Repository.AzureTable;

namespace Infrastructure.Repository.Abstractions.Repositories
{
    public interface IPlanetRepository : IAzureTableRepository<Planet>
    {

    }
}
