﻿using Domain.Entities;
using Orleans;

namespace Grains.Abstractions
{
    public interface IUserGrain : IGrainWithStringKey
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(string id);
        Task<User> GetByUsername(string username);
        Task AddUser(User user);
    }
}
