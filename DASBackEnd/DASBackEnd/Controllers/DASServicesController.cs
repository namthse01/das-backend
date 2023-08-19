using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IServices;
using DASBackEnd.Models;
using DASBackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DASServicesController : ControllerBase
    {
        private IDaServices _daServices;
        private readonly DasContext _DasContext;
        public DASServicesController(DasContext DasContext, IDaServices daServices)
        {

            this._DasContext = DasContext;
            this._daServices = daServices;
        }


        [HttpGet]
        [Route("GetAllServices")]
        public async Task<ActionResult<IEnumerable<Daservice>>> GetAllServices()
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not get all services information " });
            }
            return await _DasContext.Daservices.ToListAsync();
        }

        [HttpGet]
        [Route("GetServiceDetail/{id}")]
        public async Task<ActionResult<IEnumerable<Daservice>>> GetServiceDetail(int id)
        {
            if (_DasContext.Daservices == null)
            {
                return BadRequest(new { Message = "Can not get service information " });
            }
            var service = await _DasContext.Daservices.FindAsync(id);
            if (service == null)
            {
                return BadRequest(new { Message = "Can not get service information " });
            }
            return Ok(service);

        }

        [HttpPost]
        [Route("AddServices")]
        public async Task<IActionResult> AddService(AddUpdateServicesDTO addUpdateServicesDTO)
        {
            try
            {
                await _daServices.managerAddService(addUpdateServicesDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not add services please try again. ");

            }
        }


        [HttpPatch]
        [Route("UpdateServices/{id}")]
        public async Task<IActionResult> UpdateServices(AddUpdateServicesDTO addUpdateServicesDTO)
        {
            try
            {
                _daServices.managerUpdateService(addUpdateServicesDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Can not update services please try again. ");

            }
        }

        [HttpDelete]
        [Route("DeleteServices/{id}")]
        public bool DeleteStudent(int id)
        {
            bool a = false;
            var service = _DasContext.Daservices.Find(id);
            if (service != null)
            {
                a = true;
                _DasContext.Entry(service).State = EntityState.Deleted;
                _DasContext.SaveChanges();
            }
            else
            {
                a = false;
            }

            return a;
        }
    }
}
