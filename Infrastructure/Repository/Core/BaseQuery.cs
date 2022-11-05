using Azure.Data.Tables;
using Domain.Options;
using Infrastructure.Repository.Core.Abstractions;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Core
{
    internal abstract class BaseQuery<T> : IBaseQuery<T>
        where T : class, ITableEntity, new()
    {
        protected readonly string partitionKey;
        private readonly TableServiceClient tableServiceClient;
        protected readonly TableClient tableClient;

        public BaseQuery(IOptions<AzureTableOptions> options)
        {
            tableServiceClient = new TableServiceClient(options.Value.ConnectionString);
            tableClient = tableServiceClient.GetTableClient(tableName: "Planets");
            partitionKey = typeof(T).Name;
        }

        public async Task<List<T>> Filter(Expression<Func<T, bool>> query) =>
            await tableClient.QueryAsync(query).ToListAsync();

        public async Task<List<T>> GetAll() =>
            await tableClient
                .QueryAsync<T>(entity => entity.PartitionKey == partitionKey)
                .ToListAsync();

        public async Task<T?> GetById(string id) =>
            await tableClient
            .QueryAsync<T>(entity => entity.RowKey == id)
            .FirstOrDefaultAsync();
    }
}
