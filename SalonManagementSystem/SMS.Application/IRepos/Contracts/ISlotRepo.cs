using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMS.Domain.Slot;

namespace SMS.Application.Persistance.Contracts
{
    public interface ISlotRepo:IGenricRepo<Slot>
    {
        public Task<IEnumerable<Slot>> GetSlotByTime(DateTime time);
        public Task<IEnumerable<Slot>> GetSlotByStatus(string status, string salonId, string stylistID);
        public Task<IEnumerable<Slot>> GetSlotBySalonId(string id, string stylistId);
        public Task UpdateSlot(Slot slot,string slotId);
    }
}
