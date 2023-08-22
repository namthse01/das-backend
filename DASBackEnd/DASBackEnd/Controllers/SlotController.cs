using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IRepository;
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
        private ISlotRepository _SlotRepository;
        public SlotController(DasContext DasContext, ISlotServices slotServices, ISlotRepository SlotRepository)
        {

            this._DasContext = DasContext;
            _IslotServices = slotServices;
            _SlotRepository = SlotRepository;
        }

        [HttpGet]
        [Route("GetAllSlotByDoctorId")]
        public IActionResult GetAllSlotByDoctorId(int id)
        {
            if (_DasContext.Slots == null)
            {
                return BadRequest(new { Message = "Can not get slots of doctor " });
            }
            List<Slot> slots =  _DasContext.Slots.Where(x => x.AccountId == id).ToList();
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


        public static IEnumerable<DateTime> AllDatesInMonth(int year, int month)
        {
            int days = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                yield return new DateTime(year, month, day);
            }
        }

        [HttpPost]
        [Route("AddDoctorToSlot")]
        public async Task<IActionResult> adddoctorToSlot(DoctorToSlotDTO doctorToSlotDTO)
        {
            try
            {
         /*       List<Slot> slot = _SlotRepository.GetAllSlot();
                var dates = AllDatesInMonth(2023, doctorToSlotDTO.month).Where(i => i.DayOfWeek == DayOfWeek.Monday);*/
                if (doctorToSlotDTO.roleId == 4) {
                    await _IslotServices.CreateSlotAsync(doctorToSlotDTO);
               /*     foreach (Slot slotItem in slot)
                    {
                        foreach (DateTime date in dates)
                        {
                            if (slotItem.Date == date)
                            {
                                break;
                            }
                            else
                            {

                            }
                        }
                    }*/
                }
                else
                {
                    return BadRequest("Must be doctor to slot please try again. ");
                } 
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not add doctor to slot please try again. ");

            }
        }

    }
}
