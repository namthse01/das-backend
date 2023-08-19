using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface IServicesRepository
    {
        public Task<Daservice> CreateServiceAsync(Daservice service);
        public void UpdateServiceAsync(Daservice service);
    }
}
