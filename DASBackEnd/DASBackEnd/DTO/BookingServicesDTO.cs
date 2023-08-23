namespace DASBackEnd.DTO
{
    public class BookingServicesDTO
    {
        public int bookingId { get; set; }
        public string serviceName { get; set; }
        public int serviceId { get; set; }
        public int lowPrice { get; set; }
        public int topPrice { get; set; }
        public int advancedPrice { get; set; }
        public string serviceType { get; set; }
    }
}
