using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;
using Orleans;

namespace Grains.Implementations
{
    public class UserGrain : Grain, IUserGrain
    {
        private readonly IUserQuery userQuery;
        private readonly IUserRepository userRepository;

        private User? user;
        
        public UserGrain(IUserQuery userQuery, IUserRepository userRepository)
        {
            this.userQuery = userQuery;
            this.userRepository = userRepository;
        }

        public override async Task OnActivateAsync()
        {
            user = await userQuery.GetById(this.GetPrimaryKeyString());
        }

        public async Task<List<User>> GetAllUsers() =>
            await userQuery.GetAll();

        public Task<User?> GetUser() =>
            Task.FromResult(user) ?? throw new Exception($"User with Id:{this.GetPrimaryKeyString()} not found");

        public async Task AddUser(User user) =>
            await userRepository.InsertAsync(user);

        public async Task<User> GetByUsername(string username) =>
            await userQuery.GetUserByName(username);
    }
}
