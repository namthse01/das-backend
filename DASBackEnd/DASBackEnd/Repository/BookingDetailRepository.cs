using DASBackEnd.Data;
using DASBackEnd.IRepository;
using DASBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Repository
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        private DasContext dasContext;
        public BookingDetailRepository(DasContext dasContext)
        {
            this.dasContext = dasContext;
        }

        public BookingDetail CreateBookingDetailAsync(BookingDetail bookingDetail)
        {
            dasContext.BookingDetails.Add(bookingDetail);
            dasContext.SaveChanges();
            return bookingDetail;
        }

        public Slot customerGetSlotDetailBySlotId(int slotId)
        {
            Slot slot = dasContext.Slots.Include(x=>x.Account).Where(x => x.Id == slotId  && x.Account.Id == x.AccountId).FirstOrDefault();
                
            return slot;
        }

        public Booking customerGetBookingDetailByBookingId(int bookingId)
        {
            Booking book = dasContext.Bookings.Where(x => x.Id == bookingId).FirstOrDefault();

            return book;

        }

        public List<BookingDetail> listOfBookingDetail(int bookingId)
        {
            List<BookingDetail> bookDetail = dasContext.BookingDetails.Include(x=>x.Service).Where(x => x.BookingId == bookingId).ToList();

            return bookDetail;

        }
    }
}
