using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IAccountRepository
    {
        public Task<Account> createAccount(Account account);

        public Account findAccountById(int id);

        public User findUserById(int id);

        public void updateAccountById(Account account);

        public void AdminupdateAccountById(Account account, User user);

        public Account checkAccountExist(loginDTO loginDTO);
    }
}
