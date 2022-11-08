using Domain.Entities;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApi.Security
{
    public class UserStorage : IUserStore<User>
    {
        private readonly IUserRepository userRepository;
        private readonly IUserQuery userQuery;

        public UserStorage(IUserRepository userRepository, IUserQuery userQuery)
        {
            this.userRepository = userRepository;
            this.userQuery = userQuery;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await userQuery.GetById(userId) ?? throw new Exception($"User with id: {userId} not found!");
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) =>
            await userQuery.GetUserByName(normalizedUserName) ?? throw new Exception($"User with username: {normalizedUserName} not found!");

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose() { return; }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
