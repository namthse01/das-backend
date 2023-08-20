using DASBackEnd.DTO;
using DASBackEnd.IRepository;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using DASBackEnd.Repository;

namespace DASBackEnd.Services
{
    public class AccountServices : IAccountServices
    {
        private IAccountRepository _AccountRepository;
        private IUserRepository _UserRepository;
        public AccountServices(IAccountRepository accountRepository, IUserRepository userRepository)
        {
            _AccountRepository = accountRepository;
            _UserRepository = userRepository;
        }
        public async Task<Account> createAccount(AddUpdateAccountDTO addUpdateAccountDTO)
        {
            User user = new User()
            {
                UserName = addUpdateAccountDTO.AddUpdateUserDTO.UserName,
                Gender = addUpdateAccountDTO.AddUpdateUserDTO.Gender,
                PhoneNum = addUpdateAccountDTO.AddUpdateUserDTO.PhoneNum,
            };
            await _UserRepository.CreateUser(user);

            Account account = new Account()
            {
                UserId = user.Id,
                Username= addUpdateAccountDTO.Username,
                Password = addUpdateAccountDTO.Password,
                WorkingStatus= addUpdateAccountDTO.WorkingStatus,
                AccountStatus = addUpdateAccountDTO.AccountStatus,
            }; 
            _AccountRepository.createAccount(account);
            return account;
        }

        public AddUpdateAccountDTO updateAccountById(AddUpdateAccountDTO addUpdateAccountDTO)  
        {
            Account account = _AccountRepository.findAccountById(addUpdateAccountDTO.accountId);
            account.Username = addUpdateAccountDTO.Username;
            account.Password = addUpdateAccountDTO.Password;
            account.WorkingStatus = addUpdateAccountDTO.WorkingStatus;
            account.AccountStatus = addUpdateAccountDTO.AccountStatus;
            _AccountRepository.updateAccountById(account);
            return addUpdateAccountDTO;
        }
    }
}
