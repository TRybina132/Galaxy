﻿using Domain.Entities;
using Grains.Abstractions;
using Infrastructure.Repository.Abstractions.Queries;
using Infrastructure.Repository.Abstractions.Repositories;

namespace Grains.Implementations
{
    public class UserGrain : IUserGrain
    {
        private readonly IUserQuery userQuery;
        private readonly IUserRepository userRepository;

        public UserGrain(IUserQuery userQuery, IUserRepository userRepository)
        {
            this.userQuery = userQuery;
            this.userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers() =>
            await userQuery.GetAll();

        public async Task AddUser(User user) =>
            await userRepository.InsertAsync(user);

        public async Task<User> GetById(string id) =>
            await userQuery.GetById(id) ?? throw new Exception($"User with Id:{id} not found");
    }
}
