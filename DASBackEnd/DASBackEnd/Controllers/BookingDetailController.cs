using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using DASBackEnd.Services;
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
        private IBookingDetailServices _bookingDetailServices;
        public BookingDetailController(DasContext DasContext, IBookingDetailServices bookingDetailServices)
        {

            this._DasContext = DasContext;
            this._bookingDetailServices = bookingDetailServices;
        }



        [HttpGet]
        [Route("GetBookingDetail")]
        public IActionResult getBookingDetail(int bookingId)
        {
            try 
            {
                if (_DasContext == null)
                {
                    return BadRequest(new { Message = "Can not get booking detail information " });
                }
                else
                {
                    BookingDetailDTO bookingDetailDTO = _bookingDetailServices.customerGetBookingDetailById(bookingId);
                    return Ok(bookingDetailDTO);
                }
            } 
            catch(Exception e) 
            {
                return BadRequest(e.StackTrace);
            }


        }

    }
}
