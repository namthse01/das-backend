using DASBackEnd.Data;
using DASBackEnd.DTO;
using DASBackEnd.IRepository;
using DASBackEnd.IServices;
using DASBackEnd.Models;

namespace DASBackEnd.Services
{
    public class DaServices : IDaServices
    {
        private IServicesRepository _servicesRepository;

        public DaServices(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }
        public async Task<Daservice> managerAddService(AddUpdateServicesDTO addUpdateServicesDTO)
        {
            Daservice daservice = new Daservice()
            {
                ServiceName = addUpdateServicesDTO.ServiceName,
                Intro = addUpdateServicesDTO.Intro,
                Outro = addUpdateServicesDTO.Outro,
                Contents = addUpdateServicesDTO.Contents,
                AccountId = addUpdateServicesDTO.AccountId,
            };
            await _servicesRepository.CreateServiceAsync(daservice);
            return daservice;
        }

        public void managerUpdateService(AddUpdateServicesDTO addUpdateServicesDTO)
        {
            Daservice daservice = new Daservice()
            {
                ServiceName = addUpdateServicesDTO.ServiceName,
                Intro = addUpdateServicesDTO.Intro,
                Outro = addUpdateServicesDTO.Outro,
                Contents = addUpdateServicesDTO.Contents,
                AccountId = addUpdateServicesDTO.AccountId,
            };
             _servicesRepository.UpdateServiceAsync(daservice);
        }
    }
}
