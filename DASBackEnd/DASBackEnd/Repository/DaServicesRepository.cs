using DASBackEnd.Data;
using DASBackEnd.DTO;
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

        public Daservice UpdateServiceAsync(AddUpdateServicesDTO addUpdateServicesDTO)
        {
            
            Daservice daservice =dbContext.Daservices.FirstOrDefault(x=>x.Id==addUpdateServicesDTO.serviceId);
            daservice.ServiceName = addUpdateServicesDTO.ServiceName;   
            daservice.Intro =   addUpdateServicesDTO.Intro;
            daservice.Contents =  addUpdateServicesDTO.Contents;
            daservice.Outro = addUpdateServicesDTO.Outro;
            daservice.ServiceIsActive = addUpdateServicesDTO.ServiceIsActive;
            dbContext.Entry(daservice).Property(p => p.ServiceName).IsModified =daservice.ServiceName != null && daservice.ServiceName != "string";
            dbContext.Entry(daservice).Property(p => p.Intro).IsModified = daservice.Intro != null && daservice.Intro != "string";
            dbContext.Entry(daservice).Property(p => p.Outro).IsModified = daservice.Outro != null && daservice.Outro != "string";
            dbContext.Entry(daservice).Property(p => p.Contents).IsModified = daservice.Contents != null && daservice.Contents != "string";
            dbContext.Entry(daservice).Property(p => p.AccountId).IsModified = daservice.AccountId != null && daservice.AccountId != 0;
            dbContext.Entry(daservice).Property(p => p.ServiceIsActive).IsModified = daservice.ServiceIsActive !=null;
            dbContext.SaveChanges();
            return daservice;
        }
    }
}
