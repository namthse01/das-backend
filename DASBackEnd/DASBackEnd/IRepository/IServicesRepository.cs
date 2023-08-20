using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IServicesRepository
    {
        public Task<Daservice> CreateServiceAsync(Daservice service);
        public Daservice UpdateServiceAsync(AddUpdateServicesDTO addUpdateServicesDTO);
    }
}
