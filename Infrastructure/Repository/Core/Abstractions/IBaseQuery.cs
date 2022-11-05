using Azure.Data.Tables;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Core.Abstractions
{
    public interface IBaseQuery<T>
        where T : class, ITableEntity, new()
    {
        Task<List<T>> GetAll();
        Task<List<T>> Filter(Expression<Func<T, bool>> query);
        Task<T?> GetById(string id);
    }
}
