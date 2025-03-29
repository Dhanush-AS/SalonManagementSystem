using SMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMS.Domain.Slot;

namespace SMS.Application.IServices.Common
{
    public interface ISlotService
    {
       
        Task<IEnumerable<SlotDto>> GetSlotsByStatusAsync(string status, string salonId, string stylistID);
        Task<IEnumerable<SlotDto>> GetSlotByTimeRangeAsync(DateTime timeRange);
        Task<IEnumerable<SlotDto>> GetSlotBySalonId(string id, string stylistId);
    }
}
