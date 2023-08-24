﻿namespace DASBackEnd.DTO
{
    public class AddUpdateAccountDTO
    {
        public int accountId { get; set; }
        public int UserId { get; set; }

        public string FullName { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public string AccountStatus { get; set; }

        public string WorkingStatus { get; set; }

        public string PhoneNum { get; set; }

        public string Gender { get; set; }

    }
}
