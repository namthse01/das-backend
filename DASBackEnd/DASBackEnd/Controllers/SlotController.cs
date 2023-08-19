using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private ISlotServices _IslotServices;
        private readonly DasContext _DasContext;
        public SlotController(DasContext DasContext, ISlotServices slotServices)
        {

            this._DasContext = DasContext;
            _IslotServices = slotServices;
        }

        [HttpGet]
        [Route("GetAllSlotByDoctorId/{id}")]
        public async Task<ActionResult<IEnumerable<Slot>>> GetAllSlotByDoctorId(int id)
        {
            if (_DasContext.Slots == null)
            {
                return BadRequest(new { Message = "Can not get slots of doctor " });
            }
            var slots = await _DasContext.Slots.Where(x => x.AccountId == id).ToListAsync();
            if (slots == null)
            {
                return BadRequest(new { Message = "Doctor not exist " });
            }
            return Ok(slots);

        }

        [HttpGet]
        [Route("GetAllSlot")]
        public async Task<ActionResult<IEnumerable<Slot>>> GetAllSlot()
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not get all slot information " });
            }
            else
            {
                return await _DasContext.Slots.ToListAsync();
            }

        }


        [HttpPost]
        [Route("AddDoctorToSlot")]
        public async Task<IActionResult> adddoctorToSlot(DoctorToSlotDTO doctorToSlotDTO)
        {
            try
            {
                await _IslotServices.CreateSlotAsync(doctorToSlotDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not add doctor to slot please try again. ");

            }
        }

    }
}
