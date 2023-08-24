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
    public class AccountController : ControllerBase
    {
        private IAccountServices _accountServices;
        private readonly DasContext _DasContext;
        public AccountController(DasContext DasContext, IAccountServices accountServices)
        {

            this._DasContext = DasContext;
            this._accountServices = accountServices;
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
        [Route("RegisterCustomer")]
        public  IActionResult RegisterCustomer(RegisterCustomerDTO registerCustomerDTO)
        {
            try
            {
                if (registerCustomerDTO.RoleId == 3) 
                {
                    User user = new User()
                    {
                        Gender = registerCustomerDTO.Gender,
                        PhoneNum = registerCustomerDTO.PhoneNum,
                        UserName = registerCustomerDTO.FullName,
                    };
                    _DasContext.Users.Add(user);
                    _DasContext.SaveChanges();
                    Account account = new Account()
                    {
                        UserId = user.Id,
                        Username = registerCustomerDTO.Username,
                        Password = registerCustomerDTO.Password,
                        RoleId = registerCustomerDTO.RoleId,
                        AccountStatus = "isActive",
                    };
                    _DasContext.Accounts.Add(account);
                    _DasContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Role không hợp lệ");
                }
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi trong quá trình tạo tài khoản, vui lòng thử lại. ");
            }
        }

        [HttpPost]
        [Route("RegisterDoctorManager")]
        public IActionResult RegisterDoctormanager(AddUpdateAccountDTO addUpdateAccountDTO)
        {
            try
            {
                User user = new User()
                {
                    UserName = addUpdateAccountDTO.FullName,
                    Gender = addUpdateAccountDTO.Gender,
                    PhoneNum = addUpdateAccountDTO.PhoneNum
                };
                _DasContext.Users.Add(user);
                _DasContext.SaveChanges();
                Account account = new Account()
                {
                    UserId = user.Id,
                    Username = addUpdateAccountDTO.Username,
                    Password = addUpdateAccountDTO.Password,
                    RoleId = addUpdateAccountDTO.RoleId,
                    AccountStatus = "isActive",
                    WorkingStatus = "working",
                };
                _DasContext.Accounts.Add(account);
                _DasContext.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi trong quá trình tạo tài khoản, vui lòng thử lại. ");
            }
        }


        [HttpPost]
        [Route("Login")]
        public ActionResult<IEnumerable<Account>> Login(loginDTO loginDTO)
        {
            if (_DasContext == null)
            {
                return BadRequest(new { Message = "Can not login" });
            }
            else
            {
                Account account = _accountServices.checkAccountExist(loginDTO);
                if (account != null)
                {
                    return Ok(account);
                }
                else
                {
                    return BadRequest(new { Message = "Account not exist" });
                }
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
                return await _DasContext.Accounts.Include(x=> x.User).Where(x => x.RoleId == 4).ToListAsync();
            }

        }

        [HttpGet]
        [Route("GetAllManager")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAllManager()
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
        public IActionResult GetCustomerDetail(int id)
        {
            if (_DasContext.Accounts == null)
            {
                return BadRequest(new { Message = "Can not get customer information " });
            }
            var account = _DasContext.Accounts.Include(x=>x.User).Where(x=> x.Id == id && x.User.Id ==x.UserId ).FirstOrDefault();
            if (account == null)
            {
                return BadRequest(new { Message = "Can not get customer information " });
            }
            return Ok(account);

        }

        [HttpPatch]
        [Route("UpdateDoctorWorkingStatusById/{id}")]
        public IActionResult UpdateProfile(AddUpdateAccountDTO objAccount)
        {
            try
            {
                AddUpdateAccountDTO addUpdateAccountDTO = _accountServices.updateDoctorWorkingStatusById(objAccount);

                return Ok(addUpdateAccountDTO);
            }
            catch (Exception)
            {

                return BadRequest("Đã xảy ra lỗi trong quá trình update tài khoản, vui lòng thử lại. ");
            }
        }
    }
}
