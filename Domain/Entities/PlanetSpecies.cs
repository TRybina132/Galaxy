using Azure;
using Azure.Data.Tables;
using ManagedCode.Repository.AzureTable;

namespace Domain.Entities
{
    public class PlanetSpecies : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string SpeciesId { get; set; } 
        public string SpeciesName { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
    }
}
