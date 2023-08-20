using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IAccountServices
    {
        public Task<Account> createAccount(AddUpdateAccountDTO account);

        public AddUpdateAccountDTO updateAccountById(AddUpdateAccountDTO addUpdateAccountDTO);
        public Account checkAccountExist(loginDTO loginDTO);
    }
}
