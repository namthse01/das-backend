using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IAccountServices
    {

        public AddUpdateAccountDTO updateAccountById(AddUpdateAccountDTO addUpdateAccountDTO);
        public Account checkAccountExist(loginDTO loginDTO);
    }
}
