using DASBackEnd.Data;
using DASBackEnd.IRepository;
using DASBackEnd.Models;

namespace DASBackEnd.Repository
{
    public class UserRepository : IUserRepository
    {
        private DasContext dasContext;
        public UserRepository(DasContext dasContext)
        {
            this.dasContext = dasContext;
        }
        public async Task<User> CreateUser(User user)
        {
            await dasContext.Users.AddAsync(user);
            await dasContext.SaveChangesAsync();
            return user;
        }
    }
}
