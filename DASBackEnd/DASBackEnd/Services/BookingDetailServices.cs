using DASBackEnd.IRepository;
using DASBackEnd.IServices;
using DASBackEnd.Models;

namespace DASBackEnd.Services
{
    public class BookingDetailServices : IBookingDetailServices
    {
        private IBookingDetailRepository repository;
        public BookingDetailServices(IBookingDetailRepository bookingDetailRepository)
        {
            repository = bookingDetailRepository;
        }
        public List<BookingDetail> customerGetBookingDetailInformationByBookingId(int bookingId)
        {
            List<BookingDetail> list = repository.customerGetBookingDetailInformationByBookingId(bookingId);
            return list;
        }
    }
}
