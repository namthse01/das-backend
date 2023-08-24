using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IAccountServices
    {

        public AddUpdateAccountDTO updateDoctorWorkingStatusById(AddUpdateAccountDTO addUpdateAccountDTO);
        public Account checkAccountExist(loginDTO loginDTO);
        public AdminUpdateAccountDTO AdminUpdateAccount(AdminUpdateAccountDTO addUpdateAccountDTO);
    }
}
