using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface IDaServices
    {
        public Task<Daservice> managerAddService(AddUpdateServicesDTO addUpdateServicesDTO);

        public void managerUpdateService(AddUpdateServicesDTO addUpdateServicesDTO);
    }
}
