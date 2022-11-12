using Domain.Entities;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GalaxyApi.Security
{
    public class UserStore : IUserStore<User>
    {
        private readonly IUserRepository userRepository;
        private readonly IUserQuery userQuery;
        private readonly PasswordHasher<User> passwordHasher;

        public UserStore(
            IUserRepository userRepository,
            IUserQuery userQuery,
            PasswordHasher<User> passwordHasher)
        {
            this.userRepository = userRepository;
            this.userQuery = userQuery;
            this.passwordHasher = passwordHasher;
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await userQuery.GetById(userId) ?? throw new Exception($"User with id: {userId} not found!");
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken) =>
            await userQuery.GetUserByName(normalizedUserName) ?? throw new Exception($"User with username: {normalizedUserName} not found!");

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            user.Password = passwordHasher.HashPassword(user, user.Password);
            await userRepository.InsertAsync(user);
            return new IdentityResult();
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            await userRepository.DeleteAsync(user.RowKey);
            return new IdentityResult();
        }

        public void Dispose() { return; }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Name.ToUpper());

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.RowKey);

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken) =>
            Task.FromResult(user.Name);

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Name = normalizedName;
            await userRepository.UpdateAsync(user);
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;
            await userRepository.UpdateAsync(user);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            await userRepository.UpdateAsync(user);
            return new IdentityResult();
        }
    }
}
