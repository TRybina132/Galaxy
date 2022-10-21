using Azure;
using Azure.Data.Tables;
using ManagedCode.Repository.AzureTable;

namespace Domain.Entities
{
    public class Planet : AzureTableItem, ITableEntity
    {
        public string Name { get; set; }
        public long Population { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
        public override string ToString() =>
            $"ID: {Id}, name: {Name}, population: {Population}";
    }
}
