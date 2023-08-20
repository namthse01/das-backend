using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IBookingDetailServices
    {
        public List<BookingDetail> customerGetBookingDetailInformationByBookingId(int bookingId);
    }
}
