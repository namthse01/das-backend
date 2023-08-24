namespace DASBackEnd.DTO
{
    public class AdminUpdateAccountDTO
    {
        public int accountId { get; set; }
        public string FullName { get; set; }

        public string AccountStatus { get; set; }

        public string WorkingStatus { get; set; }

        public string PhoneNum { get; set; }

        public string Gender { get; set; }
    }
}
