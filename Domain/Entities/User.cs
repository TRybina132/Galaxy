using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : ITableEntity
    {
        public string PartitionKey { get; set; } = "User";
        public string RowKey { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SpeciesType { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
    }
}
