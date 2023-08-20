using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IBookingDetailRepository
    {
        public BookingDetail CreateBookingDetailAsync(BookingDetail bookingDetail);
        public Slot customerGetSlotDetailBySlotId(int slotId);
        public Booking customerGetBookingDetailByBookingId(int bookingId);
        public List<BookingDetail> listOfBookingDetail(int bookingId);
    }
}
