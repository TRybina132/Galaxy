using Azure.Data.Tables;
using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions;
using ManagedCode.Repository.AzureTable;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Repository.Implementations
{
    internal class PlanetRepository : AzureTableRepository<Planet>, IPlanetRepository
    {
        private const string partitionKey = "Planet";
        private readonly TableServiceClient tableServiceClient;
        private readonly TableClient tableClient;

        public PlanetRepository(
            IOptions<AzureTableOptions> options) : base(new AzureTableRepositoryOptions
            {
                ConnectionString = options.Value.ConnectionString,
                TableStorageUri = new StorageUri(new Uri(options.Value.TableUri))
            }) 
        {
            tableServiceClient = new TableServiceClient(options.Value.ConnectionString);
            tableClient = tableServiceClient.GetTableClient(tableName: "Planets");
        }

        public async Task<List<Planet>> GetAllPlanets()
        {
            var products = tableClient.QueryAsync<Planet>(planet => planet.Id.PartitionKey == partitionKey);
            return await products.ToListAsync();
        }

        public async Task<Planet> GetByName(string planetName)
        {
            var result = await tableClient.QueryAsync<Planet>
                (planet => planet.Id.PartitionKey == partitionKey && planet.Name == planetName)
                .ToListAsync();

            return result.FirstOrDefault() ?? throw new Exception($"Planet with name not found: {planetName}");
        }
    }
}
