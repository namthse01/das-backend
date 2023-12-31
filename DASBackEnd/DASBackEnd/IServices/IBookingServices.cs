﻿using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IBookingServices
    {
        public Task<Booking> customerCreateBooking(CustomerCreateBookingDTO customerCreateBookingDTO);

        public List<Booking> customerGetAllBooking(int id);
        public List<Booking> doctorGetAllBookingByDoctorId(int id);
        public List<Booking> managerGetAllBooking();
        public Booking updateBookStatusByBookingId(int bookingId, string bookingSttatus);
    }
}
