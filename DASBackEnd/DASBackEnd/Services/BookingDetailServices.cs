﻿using DASBackEnd.DTO;
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
                BookingServicesDTO data = new BookingServicesDTO()
                {
                    bookingId = item.Booking.Id,
                    serviceId = item.Service.Id,
                    serviceType = item.ServiceType,
                    serviceName = item.Service.ServiceName,
                    lowPrice = (int)item.Service.LowPrice,
                    advancedPrice = (int)item.Service.AdvancedPrice,
                    topPrice = (int)item.Service.TopPrice,
                };
                servciesDTO.Add(data);

            }
            BookingDetailDTO bookingDetailDTO = new BookingDetailDTO()
            {
                Id = book.Id,
                customerName = book.CustomerName,
                phoneNo = book.PhoneNo,
                bookingStatus = book.BookingStatus,
                Gender = book.Gender,
                doctorId = slot.AccountId,
                slotId = slot.Id,
                doctorName = slot.DoctorName,
                listServicesBooking = servciesDTO,
                totalPrice = (int)book.TotalPrice
            };
         
            return bookingDetailDTO;
        }
    }
}
