namespace DASBackEnd.DTO
{
    public class RegisterCustomerDTO
    {
        public string Username { get; set; }
        public string FullName { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
        public string AccountStatus { get; set; }
        public string PhoneNum { get; set; }

        public string Gender { get; set; }
    }
}
