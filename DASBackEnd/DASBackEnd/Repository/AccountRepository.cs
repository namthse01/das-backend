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
        public void createAccount(Account account)
        {
            dasContext.Accounts.Add(account);
            dasContext.SaveChanges();
      
        }

        public void updateAccountById(Account account)
        {
            dasContext.Accounts.Update(account);
            dasContext.SaveChanges();
        }

        public Account findAccountById(int id)
        {
            Account account = dasContext.Accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }

        public Account checkAccountExist(loginDTO loginDTO)
        {
            Account account = dasContext.Accounts.FirstOrDefault(x=> x.Username== loginDTO.Username && x.Password==loginDTO.Password);
            return account;
        }

    }
}
