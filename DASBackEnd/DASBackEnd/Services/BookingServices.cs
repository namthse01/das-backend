using DASBackEnd.DTO;
using DASBackEnd.IRepository;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using DASBackEnd.Repository;

namespace DASBackEnd.Services
{
    public class BookingServices : IBookingServices
    {
        private IBookingRepository _bookingRepository;
        private IBookingDetailRepository _bookingDetailRepository;
        public BookingServices(IBookingRepository bookingRepository, IBookingDetailRepository bookingDetailRepository)
        {
            this._bookingRepository = bookingRepository;
            this._bookingDetailRepository = bookingDetailRepository;
        }
        public async Task<Booking> customerCreateBooking(CustomerCreateBookingDTO customerCreateBookingDTO)
        {
            Booking booking = new Booking()
            {
                CustomerName = customerCreateBookingDTO.CustomerName,
                AccountId = customerCreateBookingDTO.accountId,
                BookingStatus = "OnProcess",
                SlotId = customerCreateBookingDTO.slotId,
                Gender = customerCreateBookingDTO.gender,
                PhoneNo = customerCreateBookingDTO.phoneNum,
            };
            await _bookingRepository.CreateBookingAsync(booking);

            foreach (var item in customerCreateBookingDTO.listservicesBookDTO)
            {
                BookingDetail bookingDetail = new BookingDetail()
                {
                    BookingId = booking.Id,
                    ServiceId = item.serviceId
                };
                _bookingDetailRepository.CreateBookingDetailAsync(bookingDetail);
            }

            _bookingRepository.changeSlotStatus((int)booking.SlotId);

            return booking;
        }

        public List<Booking> customerGetAllBooking(int customerId)
        {
            List<Booking> list = _bookingRepository.GetAllBookingByCustomer(customerId);


            return list;
        }

        public List<Booking> managerGetAllBooking()
        {
            List<Booking> list = _bookingRepository.GetAllBookingByManager();
            return list;
        }

        public Booking updateBookStatusByBookingId(int bookingId, string bookingStatus)
        {
            Booking booking = _bookingRepository.managerUpdateBookingStatus(bookingId, bookingStatus);
            return booking;
        }
    }
}
