﻿using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IAccountRepository
    {
        public void createAccount(Account account);

        public void updateAccountById(Account account);

        public Account findAccountById(int id);

        public Account checkAccountExist(loginDTO loginDTO);
    }
}
