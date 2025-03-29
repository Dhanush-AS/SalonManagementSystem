using AutoMapper;
using SMS.Application.DTOs;
using SMS.Application.IServices.Common;
using SMS.Application.Persistance.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static SMS.Domain.Slot;

namespace SMS.Infrastructure.Services.Common
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepo _slotRepo;
        private readonly IMapper _mapper;
        public SlotService(ISlotRepo slotRepo,IMapper mapper)
        {
            _slotRepo = slotRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SlotDto>> GetSlotBySalonId(string id,string stylistId)
        {
            var slot = await _slotRepo.GetSlotBySalonId(id, stylistId);
            if (slot == null && !slot.Any())
            {
                throw new Exception("No slots found");

            }
            var slotDto = _mapper.Map<IEnumerable<SlotDto>>(slot);
            return slotDto;
        }

        public async Task<IEnumerable<SlotDto>> GetSlotByTimeRangeAsync(DateTime timeRange)
        {
            var slot = await _slotRepo.GetSlotByTime(timeRange);
            if (slot == null && !slot.Any()) {
                throw new Exception("No slots found");

            }
            var slotDto = _mapper.Map <IEnumerable<SlotDto>>(slot);
            return slotDto;
        }

    
        public async Task<IEnumerable<SlotDto>> GetSlotsByStatusAsync(string status,string salonId,string stylistID)
        {
            var slot = await _slotRepo.GetSlotByStatus(status,salonId,stylistID);
            
            if (slot == null || !slot.Any())
            {
                throw new Exception("No slots found");
            }
            var slotDto = _mapper.Map<IEnumerable<SlotDto>>(slot);
            return slotDto;
        }

    }
}
