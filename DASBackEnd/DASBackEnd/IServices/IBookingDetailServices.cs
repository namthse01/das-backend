using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IBookingDetailServices
    {
        public BookingDetailDTO customerGetBookingDetailById(int bookingId);
    }
}
