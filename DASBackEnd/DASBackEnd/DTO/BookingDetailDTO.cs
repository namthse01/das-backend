﻿namespace DASBackEnd.DTO
{
    public class BookingDetailDTO
    {
       public int Id { get; set; }
        public string? customerName { get; set; }
        public string? phoneNo { get; set; }
        public string Gender { get; set; }
        public string? bookingStatus { get; set; }
        public  int? doctorId { get; set; }
        public string doctorName { get; set; }
        public List<BookingServicesDTO> listServices { get; set;}
    }
}