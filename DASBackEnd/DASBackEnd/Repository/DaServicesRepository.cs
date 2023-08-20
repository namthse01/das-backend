using DASBackEnd.Data;
using DASBackEnd.IRepository;
using DASBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Repository
{
    public class DaServicesRepository : IServicesRepository
    {

        private DasContext dbContext;
        public DaServicesRepository(DasContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Daservice> CreateServiceAsync(Daservice service)
        {
            await dbContext.Daservices.AddAsync(service);
            await dbContext.SaveChangesAsync();
            return service;
        }

        public void UpdateServiceAsync(Daservice service)
        {
            dbContext.Daservices.Update(service);
            dbContext.SaveChanges();
        }
    }
}
