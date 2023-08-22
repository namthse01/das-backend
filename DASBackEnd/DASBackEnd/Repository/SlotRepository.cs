using DASBackEnd.Data;
using DASBackEnd.IRepository;
using DASBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DASBackEnd.Repository
{
    public class SlotRepository : ISlotRepository
    {
        private DasContext dbContext;
        public SlotRepository(DasContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Slot> CreateSlotAsync(Slot slot)
        {

            await dbContext.Slots.AddAsync(slot);
            await dbContext.SaveChangesAsync();

            return slot;
        }

        public Account getDoctorbyId(int id)
        {
            Account account= dbContext.Accounts.Where(x=> x.Id==id).FirstOrDefault();

            return account;
        }

        public List<Slot> GetAllSlot()
        {
            List<Slot> slots = dbContext.Slots.ToList();
            return slots;
        }
    }
}
