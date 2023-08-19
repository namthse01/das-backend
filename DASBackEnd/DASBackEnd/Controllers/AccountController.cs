using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly DasContext _DasContext;
        public AccountController(DasContext DasContext)
        {

            this._DasContext = DasContext;

        }

        [HttpGet]
        [Route("GetAllUser")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllUser()
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not get all user information " });
            }
            else
            {
                return await _DasContext.Accounts.ToListAsync();
            }

        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<IEnumerable<Account>>> Login(loginDTO loginDTO)
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not login" });
            }
            else
            {
                return await _DasContext.Accounts.Where(x => x.Username == loginDTO.Username && x.Password == loginDTO.Password).ToListAsync();
            }

        }

        [HttpGet]
        [Route("GetAllCustomer")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllCustomer()
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not get all customer information " });
            }
            else
            {
                return await _DasContext.Accounts.Where(x => x.RoleId == 3).ToListAsync();
            }

        }

        [HttpGet]
        [Route("GetAllDoctor")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllDoctor()
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not get all doctors information " });
            }
            else
            {
                return await _DasContext.Accounts.Where(x => x.RoleId == 4).ToListAsync();
            }

        }

        [HttpGet]
        [Route("GetAllManager")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllMânger()
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not get all manager information " });
            }
            else
            {
                return await _DasContext.Accounts.Where(x => x.RoleId == 2).ToListAsync();
            }

        }

        [HttpGet]
        [Route("GetCustomerDetail/{id}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetCustomerDetail(int id)
        {
            if (_DasContext.Accounts == null)
            {
                return BadRequest(new { Message = "Can not get customer information " });
            }
            var account = await _DasContext.Accounts.FindAsync(id);
            if (account == null)
            {
                return BadRequest(new { Message = "Can not get customer information " });
            }
            return Ok(account);

        }

        [HttpPatch]
        [Route("UpdateProfile/{id}")]
        public async Task<Account> UpdateProfile(Account objAccount)
        {
            _DasContext.Entry(objAccount).State = EntityState.Modified;
            await _DasContext.SaveChangesAsync();
            return objAccount;
        }
    }
}
