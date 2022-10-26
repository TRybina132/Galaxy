using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Repositories;
using ManagedCode.Repository.AzureTable;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Repository.Implementations.Repositories
{
    internal class SpeciesRepository : AzureTableRepository<Species>, ISpeciesRepository
    {
        public SpeciesRepository(
            IOptions<AzureTableOptions> options) : base(new AzureTableRepositoryOptions
            {
                ConnectionString = options.Value.ConnectionString,
                TableStorageUri = new StorageUri(new Uri(options.Value.TableUri))
            })
        { }
    }
}
