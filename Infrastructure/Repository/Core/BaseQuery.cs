using Azure.Data.Tables;
using Domain.Options;
using Infrastructure.Repository.Core.Abstractions;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Core
{
    internal class BaseQuery<T> : IBaseQuery<T>
        where T : class, ITableEntity, new()
    {
        private readonly string partitionKey;
        private readonly TableServiceClient tableServiceClient;
        private readonly TableClient tableClient;

        public BaseQuery(IOptions<AzureTableOptions> options)
        {
            tableServiceClient = new TableServiceClient(options.Value.ConnectionString);
            tableClient = tableServiceClient.GetTableClient(tableName: "Planets");
            partitionKey = typeof(T).Name;
        }

        public async Task<List<T>> Filter(Func<T, bool> query) =>
            throw new NotImplementedException();

        public async Task<List<T>> GetAll() =>
            await tableClient
                .QueryAsync<T>(entity => entity.PartitionKey == partitionKey)
                .ToListAsync();
    }
}
