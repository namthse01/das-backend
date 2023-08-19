using DASBackEnd.DTO;
using DASBackEnd.Models;

namespace DASBackEnd.IServices
{
    public interface ISlotServices
    {
        public Task CreateSlotAsync(DoctorToSlotDTO doctorToSlotDTO);
    }
}
