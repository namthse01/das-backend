using DASBackEnd.Models;

namespace DASBackEnd.IRepository
{
    public interface ISlotRepository
    {
        public Task<Slot> CreateSlotAsync(Slot slot);

        public Account getDoctorbyId(int id);
        public List<Slot> GetAllSlot();
    }
}
