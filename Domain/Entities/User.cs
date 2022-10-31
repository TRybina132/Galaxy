using Azure;
using Azure.Data.Tables;

namespace Domain.Entities
{
    public class User : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
    }
}
