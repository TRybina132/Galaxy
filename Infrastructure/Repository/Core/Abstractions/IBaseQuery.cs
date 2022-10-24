using Azure.Data.Tables;

namespace Infrastructure.Repository.Core.Abstractions
{
    public interface IBaseQuery<T>
        where T : class, ITableEntity, new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> Filter(Func<T, bool> query);
    }
}
