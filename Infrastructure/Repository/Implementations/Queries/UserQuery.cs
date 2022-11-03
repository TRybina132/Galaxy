using Domain.Entities;
using Domain.Options;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Core;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repository.Implementations.Queries
{
    internal class UserQuery : BaseQuery<User>, IUserQuery
    {
        public UserQuery(IOptions<AzureTableOptions> options)
            : base(options) { }

        public async Task<User> GetUserByName(string username)
        {
            var user = await tableClient
                .QueryAsync<User>(user => user.Name == username)
                .FirstOrDefaultAsync();
            return user ?? throw new Exception($"User with username: {username} not found");
        }
    }
}
