using DASBackEnd.DTO;
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

        public BookingDetailDTO customerGetBookingDetailById(int bookingId)
        {
            Booking book = repository.customerGetBookingDetailByBookingId(bookingId);
            Slot slot = repository.customerGetSlotDetailBySlotId((int)book.SlotId);
            List<BookingDetail> bookDetail = repository.listOfBookingDetail(bookingId);
            List<BookingServicesDTO> servciesDTO = new List<BookingServicesDTO>();


            foreach (var item in bookDetail)
            {
                servciesDTO.Add(new BookingServicesDTO
                {
                    bookingId = (int)item.BookingId,
                    serviceId = (int)item.ServiceId,
                    serviceName = item.Service.ServiceName
                });
            }
            BookingDetailDTO bookingDetailDTO = new BookingDetailDTO()
            {
                Id = book.Id,
                customerName = book.CustomerName,
                phoneNo = book.PhoneNo,
                bookingStatus = book.BookingStatus,
                Gender = book.Gender,
                doctorId = slot.AccountId,
                doctorName = slot.Account.Username,
                listServices = servciesDTO
            };
            return bookingDetailDTO;
        }
    }
}
