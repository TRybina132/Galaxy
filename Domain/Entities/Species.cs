using Azure;
using Azure.Data.Tables;

namespace Domain.Entities
{
    public class Species : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Name { get; set; }
        public int SpeciesCount { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
    }
}
