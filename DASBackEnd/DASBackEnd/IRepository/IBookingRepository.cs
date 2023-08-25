using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IBookingRepository
    {
        public Task<Booking> CreateBookingAsync(Booking booking);

        public List<Booking> GetAllBookingByCustomer(int id);
        public List<Booking> GetAllBookingByManager();
        public List<Booking> GetAllBookingByDoctor(int id);
        public Booking managerUpdateBookingStatus(int bookingId, string bookingStatus);
        public void changeSlotStatus(int slotId);

    }
}
