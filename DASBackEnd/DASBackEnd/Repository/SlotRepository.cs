using DASBackEnd.Data;
using DASBackEnd.IRepository;
using DASBackEnd.Models;

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
    }
}
