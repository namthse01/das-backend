using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailController : ControllerBase
    {

        private readonly DasContext _DasContext;
        public BookingDetailController(DasContext DasContext)
        {

            this._DasContext = DasContext;

        }

/*
        [HttpGet]
        [Route("GetBookingDetail/{id}")]
        public async Task<ActionResult<IEnumerable<bookingDTO>>> GetBookingDetail(int id)
        {
            if (_DasContext.Daservices == null)
            {
                return BadRequest(new { Message = "Can not get service information " });
            }
            var booking = _DasContext.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return BadRequest(new { Message = "Can not get service information " });
            }
            else
            {
                List<BookingDetail> listDetail = await _DasContext.BookingDetails.Where(x => x.BookingId == id).ToListAsync();
                Slot slot = (Slot)_DasContext.Slots.Where(x => x.Id == booking.SlotId);
                Account account = (Account)_DasContext.Accounts.Where(x => x.Id == slot.AccountId);
                User doctor = (User)_DasContext.Users.Where(x => x.Id == account.UserId);
                List<Daservice> services = new List<Daservice>();
                foreach (var item in listDetail)
                {
                    services = (List<Daservice>)_DasContext.Daservices.Where(x => x.Id == item.ServiceId);
                }
                List<servicesDTO> servicesDTO = new List<servicesDTO>();
                foreach(var item in services)
                {
                    servicesDTO = item;
                }
                bookingDTO bookingDTO = new bookingDTO()
                {
                    bookingStatus = booking.BookingStatus,
                    customerName = booking.CustomerName,
                    slotID = slot.Id,
                    doctorName = doctor.UserName,
                    doctorID = (int)slot.AccountId,   
                };

            }

        }
*/
    }
}
