using AutoMapper;
using Microsoft.AspNetCore.Http;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Common;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Service.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMS.Infrastructure.Services.Admin
{
    public class AdminSlotService : IAdminSlotService
    {
        private readonly ISlotRepo _slotRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAdminService _adminService;
        private readonly ISlotService _slotService;
        public AdminSlotService(ISlotRepo slotRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAdminService adminService, ISlotService slotService)
        {
            _slotRepo = slotRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _adminService = adminService;
            _slotService = slotService;
        }

        public async Task ChangeStatus(string status, string slotid,string stylistId)
        {
            // Fetch the current AdminId from the session
            string Adminid = _httpContextAccessor.HttpContext?.Session.GetString("UserId");

            // Fetch the admin details by their ID
            AdminUpdateViewDto admin = await _adminService.GetAdminByIdAsync(Adminid);
            string Salonid = admin.SalonId;

            // Fetch all slots associated with the salon and stylish
            IEnumerable<SlotDto> slots = await _slotService.GetSlotBySalonId(Salonid, stylistId);

            // Find the specific slot by slotid
            SlotDto slotToUpdate = slots.FirstOrDefault(slot => slot.SlotId == slotid);
            var slotss = _mapper.Map<Slot>(slotToUpdate);
            if (slotToUpdate != null)
            {
                // Update the SlotStatus for the matched slot
                slotToUpdate.SlotStatus = status;

                // Persist the updated slot (assuming an update method exists in the service)
                await _slotRepo.UpdateAsync(slotss,slotid);
            }
            else
            {
                // Handle the case where no slot matches the provided slotid
                throw new Exception($"Slot with ID {slotid} not found.");
            }
        }

    }
}
