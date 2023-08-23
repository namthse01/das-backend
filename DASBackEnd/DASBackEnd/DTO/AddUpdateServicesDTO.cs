namespace DASBackEnd.DTO
{
    public class AddUpdateServicesDTO
    {
        public int serviceId { get;set; }
        public string ServiceName { get; set; }
        public string? Intro { get; set; }

        public int? ServiceIsActive { get; set; }
        public int? Rating { get; set; }
        public string? Contents { get; set; }
        public int? lowPrice { get; set; }
        public int? advancedPrice { get; set; }
        public int? topPrice { get; set; }

        public string? Outro { get; set; }
        public int AccountId { get; set; }
    }
}
