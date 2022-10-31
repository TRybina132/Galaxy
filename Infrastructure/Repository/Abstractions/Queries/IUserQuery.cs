using Domain.Entities;
using Infrastructure.Repository.Core.Abstractions;

namespace Infrastructure.Repository.Abstractions.Queries
{
    public interface IUserQuery : IBaseQuery<User>
    {
        public Task<User> GetUserByName(string name);
    }
}
