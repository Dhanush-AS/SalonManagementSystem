using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Common;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : ControllerBase
    {
        private readonly IAdminSlotService _adminSlotService;
        private readonly ISlotService _slotService;
        public SlotController(IAdminSlotService adminSlotService, ISlotService slotService)
        {
            _adminSlotService = adminSlotService;
            _slotService = slotService;
        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus(string status, string slotid, string stylistId)
        {
            await _adminSlotService.ChangeStatus(status, slotid,stylistId);
            return Ok(status);
        }
        [HttpGet("GetSlotsBySalon/{salonId}/{stylistId}")]
        public async Task<IActionResult> GetSlotsBySalon(string salonId,string stylistId)
        {
            var item = await _slotService.GetSlotBySalonId(salonId, stylistId);
            return Ok(item);
        }
        [HttpGet("GetSlotsByTime/{time}")]
        public async Task<IActionResult> GetSlotsByTime(DateTime time)
        {
            var item = await _slotService.GetSlotByTimeRangeAsync(time);
            return Ok(item);
        }
        [HttpGet("GetSlotsBySatus/{status}/{salonid}/{stylistId}")]
        public async Task<IActionResult> GetSlotsByStatus(string status, string salonid,string stylistId)
        {
            var item = await _slotService.GetSlotsByStatusAsync(status, salonid,stylistId);
            return Ok(item);
        }
    }
}
