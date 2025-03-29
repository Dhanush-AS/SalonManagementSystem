using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Common;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistController : ControllerBase
    {
        private readonly IAdminStylistService _adminStylistService;
        private readonly IStylistService _stylistService;
        public StylistController(IAdminStylistService adminStylistService, IStylistService stylistService)
        {
            _adminStylistService = adminStylistService;
            _stylistService = stylistService;
        }
        [HttpPost("RegisterStylist")]
        public async Task<IActionResult> RegisterSalon([FromBody] AddStylistDto addStylistDto, string serviceName)
        {
            await _adminStylistService.AddStylistAsync(addStylistDto,serviceName);
            return Ok();
        }
        [HttpDelete("DeleteStylist/{id}")]
        public async Task<IActionResult> DeleteStylist(string stylistId)
        {
            await _adminStylistService.DeleteStylistAsync(stylistId);
            return Ok();
        }
        [HttpPut("UpdateStylist")]
        public async Task<IActionResult> UpdateStylist([FromBody] UpdateViewStylistDto updateViewStylistDto)
        {
            await _adminStylistService.UpdateStylistAsync(updateViewStylistDto);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStylist()
        {
            var item =await _stylistService.GetAllStylistAsync();
            return Ok(item);
        }
      
        [HttpGet("GetStylistBySalon/{salon}")]
        public async Task<IActionResult> GetStylistBySalon(string salon)
        {
            var item = await _stylistService.GetStylistBySalonAsync(salon);
            return Ok(item);
        }
        [HttpGet("GetStylistByService/{service}")]
        public async Task<IActionResult> GetStylistByService(string service)
        {
            var item = await _stylistService.GetStylistByServiceAsync(service);
            return Ok(item);
        }
        [HttpGet("GetStylistByname/{name}")]
        public async Task<IActionResult> GetStylistByName(string name)
        {
            var item = await _stylistService.GetStylistByNameAsync(name);
            return Ok(item);
        }
    }
}
