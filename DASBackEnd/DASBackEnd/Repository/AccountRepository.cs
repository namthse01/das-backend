using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IRepository;
using DASBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private DasContext dasContext;

        public AccountRepository(DasContext dasContext)
        {
            this.dasContext = dasContext;
        }
        public async Task<Account> createAccount(Account account)
        {
            await dasContext.Accounts.AddAsync(account);
            await dasContext.SaveChangesAsync();

            return account;
        }

        public void updateAccountById(Account account)
        {
            dasContext.Accounts.Update(account);
            dasContext.SaveChanges();
        }

        public void AdminupdateAccountById(Account account, User user)
        {

            dasContext.Entry(account).Property(p => p.WorkingStatus).IsModified = account.WorkingStatus != null && account.WorkingStatus != "";
            dasContext.Entry(account).Property(p => p.AccountStatus).IsModified = account.AccountStatus != null && account.AccountStatus != "";
            dasContext.Entry(user).Property(p => p.UserName).IsModified = user.UserName != null && user.UserName != "";
            dasContext.Entry(user).Property(p => p.PhoneNum).IsModified = user.PhoneNum != null;
            dasContext.Entry(user).Property(p => p.Gender).IsModified = user.Gender != null && user.Gender != "";
            dasContext.Accounts.Update(account);
            dasContext.Users.Update(user);
            dasContext.SaveChanges();
        }

        public Account findAccountById(int id)
        {
            Account account = dasContext.Accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }

        public User findUserById(int id)
        {
            User user = dasContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public Account checkAccountExist(loginDTO loginDTO)
        {
            Account account = dasContext.Accounts.FirstOrDefault(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password);
            return account;
        }

    }
}
