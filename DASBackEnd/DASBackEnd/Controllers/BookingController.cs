using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace DASBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IBookingServices iBookingServices;
        private readonly DasContext _DasContext;

        public BookingController(IBookingServices iBookingServices, DasContext DasContext)
        {
            this.iBookingServices = iBookingServices;
            this._DasContext = DasContext;
        }


        [HttpPost]
        [Route("createBooking/customer/{id}")]
        public async Task<IActionResult> createOrderUsingCustomerId(CustomerCreateBookingDTO customerCreateBookingDTO)
        {
            try
            {
                await iBookingServices.customerCreateBooking(customerCreateBookingDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not create new booking please try again. ");

            }
        }

        [HttpGet]
        [Route("getListBookingByCustomerId/{id}")]
        public IActionResult getListOrderByCustomerId(int id)
        {
            try
            {
                List<Booking> list = iBookingServices.customerGetAllBooking(id);
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi khi lấy thông tin, vui lòng thử lại. ");
            }
        }


        [HttpGet]
        [Route("getListBookingBymanager")]
        public IActionResult getListOrderByCustomerId()
        {
            try
            {
                List<Booking> list = iBookingServices.managerGetAllBooking();
                return Ok(list);
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi khi lấy thông tin, vui lòng thử lại. ");
            }
        }

        [HttpGet]
        [Route("getListBookingByDoctorByDoctorID")]
        public IActionResult getlistBookingByDoctor(int id)
        {
            try
            {
                List<Booking> list = iBookingServices.doctorGetAllBookingByDoctorId(id);
                return Ok(list);
            }
            catch(Exception)
            {
                return BadRequest("Đã xảy ra lỗi khi lấy thông tin.");
            }
        }

        [HttpPatch]
        [Route("ManagerUpdateBookStatus/bookingId/{id}")]
        public IActionResult managerUpdateOrderWorkingStatus(int id, string bookingStatus)
        {
            try
            {
                Booking book = iBookingServices.updateBookStatusByBookingId(id, bookingStatus);
                return Ok(book);
            }
            catch (Exception)
            {
                return BadRequest("Can not update order working status, try again. ");
            }
        }

        [HttpPatch]
        [Route("ChangeBookingDate")]
        public IActionResult managerChangeBookingDate(int bookingId, int slotId)
        {
            try
            {
                Booking book = _DasContext.Bookings.FirstOrDefault(x => x.Id == bookingId);
                book.SlotId = slotId;
                _DasContext.Bookings.Update(book);
                _DasContext.SaveChanges();
                return Ok(book);
            }
            catch (Exception)
            {
                return BadRequest("Can not change booking date, try again. ");
            }
        }

    }
}
