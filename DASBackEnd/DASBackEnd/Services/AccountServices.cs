﻿using DASBackEnd.DTO;
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

        public AddUpdateAccountDTO updateDoctorWorkingStatusById(AddUpdateAccountDTO addUpdateAccountDTO)
        {
            Account account = _AccountRepository.findAccountById(addUpdateAccountDTO.accountId);
/*            account.Username = addUpdateAccountDTO.Username;
            account.Password = addUpdateAccountDTO.Password;*/
            account.WorkingStatus = addUpdateAccountDTO.WorkingStatus;
     /*       account.AccountStatus = addUpdateAccountDTO.AccountStatus;*/
            _AccountRepository.updateAccountById(account);
            return addUpdateAccountDTO;
        }

        public Account checkAccountExist(loginDTO loginDTO)
        {
            Account account = _AccountRepository.checkAccountExist(loginDTO);
            return account;
        }
    }
}
