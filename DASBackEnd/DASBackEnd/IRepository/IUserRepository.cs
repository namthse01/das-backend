using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IUserRepository
    {
        public Task<User> CreateUser(User user);
    }
}
