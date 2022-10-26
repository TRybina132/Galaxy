using Azure;
using Azure.Data.Tables;
using ManagedCode.Repository.AzureTable;

namespace Domain.Entities
{
    public class PlanetSpecies : AzureTableItem, ITableEntity
    {
        public string PlanetName { get; set; } 
        public string SpeciesName { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
    }
}
