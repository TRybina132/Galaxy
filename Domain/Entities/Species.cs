﻿using Azure;
using Azure.Data.Tables;
using ManagedCode.Repository.AzureTable;

namespace Domain.Entities
{
    public class Species : AzureTableItem, ITableEntity
    {
        public string Name { get; set; }
        public int SpeciesCount { get; set; }
        DateTimeOffset? ITableEntity.Timestamp { get; set; } = default!;
        ETag ITableEntity.ETag { get; set; }
    }
}
