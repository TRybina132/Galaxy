using Domain.Entities;
using ManagedCode.Repository.AzureTable;

namespace Infrastructure.Repository.Abstractions
{
    public interface IPlanetRepository : IAzureTableRepository<Planet>
    {

    }
}
