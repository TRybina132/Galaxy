using Domain.Entities;
using ManagedCode.Repository.AzureTable;

namespace Infrastructure.Repository.Abstractions.Repositories
{
    public interface ISpeciesRepository : IAzureTableRepository<Species>
    {
    }
}
