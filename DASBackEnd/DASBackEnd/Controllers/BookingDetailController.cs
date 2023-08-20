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


  /*      [HttpGet]
        [Route("GetBookingDetail/{id}")]
        public async Task<ActionResult<IEnumerable<bookingDTO>>> GetBookingDetail(int id)
        {
            if (_DasContext.Daservices == null)
            {
                return BadRequest(new { Message = "Can not get service information " });
            }
            var booking =  _DasContext.Bookings.FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return BadRequest(new { Message = "Can not get service information " });
            }
            else
            {
                var listDetail = await _DasContext.BookingDetails.Where(x => x.BookingId == id).ToListAsync();
                var slot = _DasContext.Slots.Where(x => x.Id==booking.SlotId);

                bookingDTO bookingDTO = new bookingDTO()
                {
                    bookingStatus = booking.BookingStatus,
                    customerName = booking.CustomerName,
                    
                };
            }

        }*/

    }
}
