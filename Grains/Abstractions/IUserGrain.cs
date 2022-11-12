using Domain.Entities;

namespace Grains.Abstractions
{
    public interface IUserGrain
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(string id);
        Task<User> GetByUsername(string username);
        Task AddUser(User user);
    }
}
