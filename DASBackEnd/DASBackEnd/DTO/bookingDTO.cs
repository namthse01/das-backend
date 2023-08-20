namespace DASBackEnd.DTO
{
    public class bookingDTO
    {
       
        public string customerName { get; set; }
        public string bookingStatus { get; set; }
        public int slotID { get; set; }
        public int slotNo { get; set; }
        public string doctorName { get; set; }
        public int doctorID { get; set; }
        public List<listServicesDTO> servicesDTOs { get; set; }
    }
}
