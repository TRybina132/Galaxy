using Domain.Entities;

namespace Grains.Abstractions
{
    public interface IUserGrain
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(string id);
        Task AddUser(User user);
    }
}
