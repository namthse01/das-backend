using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IBookingDetailRepository
    {
        public BookingDetail CreateBookingDetailAsync(BookingDetail bookingDetail);
        public List<BookingDetail> customerGetBookingDetailInformationByBookingId(int bookingId);
    }
}
