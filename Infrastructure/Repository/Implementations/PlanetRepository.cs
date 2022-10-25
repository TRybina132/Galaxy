using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions;
using ManagedCode.Repository.AzureTable;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations
{
    internal class PlanetRepository : AzureTableRepository<Planet>, IPlanetRepository
    {

        public PlanetRepository(
            IOptions<AzureTableOptions> options) : base(new AzureTableRepositoryOptions
            {
                ConnectionString = options.Value.ConnectionString,
                TableStorageUri = new StorageUri(new Uri(options.Value.TableUri))
            }){ }
    }
}
