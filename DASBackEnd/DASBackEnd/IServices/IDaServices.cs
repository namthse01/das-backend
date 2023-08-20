using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IDaServices
    {
        public Task<Daservice> managerAddService(AddUpdateServicesDTO addUpdateServicesDTO);
        public Daservice managerUpdateService(AddUpdateServicesDTO addUpdateServicesDTO);
    }
}
