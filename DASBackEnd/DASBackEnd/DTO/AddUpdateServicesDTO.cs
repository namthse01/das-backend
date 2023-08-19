namespace DASBackEnd.DTO
{
    public class AddUpdateServicesDTO
    {
        public string ServiceName { get; set; }
        public string? Intro { get; set; }

        public string? Contents { get; set; }

        public string? Outro { get; set; }
        public int AccountId { get; set; }
    }
}
