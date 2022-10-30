using Azure.Data.Tables;

namespace Infrastructure.Repository.Core.Abstractions
{
    public interface IBaseRepository<T>
        where T : class, ITableEntity, new()
    {
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string entityId);
    }
}
