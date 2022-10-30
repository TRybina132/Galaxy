using Azure.Data.Tables;
using Domain.Options;
using Infrastructure.Repository.Core.Abstractions;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Core
{
    internal abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, ITableEntity, new()
    {
        protected readonly string partitionKey;
        private readonly TableServiceClient tableServiceClient;
        protected readonly TableClient tableClient;

        public BaseRepository(IOptions<AzureTableOptions> options)
        {
            tableServiceClient = new TableServiceClient(options.Value.ConnectionString);
            tableClient = tableServiceClient.GetTableClient(tableName: "Planets");
            partitionKey = typeof(T).Name;
        }

        public async Task InsertAsync(T entity)
        {
            //entity.PartitionKey = partitionKey;
            //entity.RowKey = new Guid().ToString();
            await tableClient.AddEntityAsync(entity);
        }

        public async Task DeleteAsync(string entityId) =>
            await tableClient.DeleteEntityAsync(partitionKey, entityId);

        public async Task UpdateAsync(T entity) =>
            await tableClient.UpdateEntityAsync(entity, entity.ETag);
    }
}
