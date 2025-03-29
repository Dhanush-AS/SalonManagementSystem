using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Common;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System.Threading.Tasks;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly IAdminServicesService _adminServicesService;

        public ServicesController(IServicesService servicesService, IAdminServicesService adminServicesService)
        {

            _servicesService = servicesService;
            _adminServicesService = adminServicesService;
        }
        [HttpPost("RegisterService")]
        public async Task<IActionResult> RegisterServiceAsync([FromBody] ServicesDto servicesDto)
        {
            await _adminServicesService.RegisterServiceAsync(servicesDto);
            return Ok();
        }
        [HttpDelete("DeleteService/{id}")]
        public async Task<IActionResult> DeleteServiceAsync(string id)
        {
            await _adminServicesService.DeleteServiceAsync(id);
            return Ok();
        }
        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateServiceAsync([FromBody] ServicesDto servicesDto)
        {
            await _adminServicesService.UpdateServiceAsync(servicesDto);
            return Ok();
        }
        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _servicesService.GetAllServices();
            return Ok(services);
        }
        [HttpGet("GetServicesByName/{name}")]
        public async Task<IActionResult> GetSericesByName(string name)
        {
            var services = await _servicesService.GetServiceByNameAsync(name);
            return Ok(services);
        }
        [HttpGet("GetServicesByPrice/{price}")]
        public async Task<IActionResult> GetSericesByPrice(int price)
        {
            var services = await _servicesService.GetServiceByPriceAsync(price);
            return Ok(services);
        }
        [HttpGet("GetServicesById/{id}")]
        public async Task<IActionResult> GetSericesById(string id)
        {
            var services = await _servicesService.GetServiceByIdAsync(id);
            return Ok(services);
        }
        [HttpGet("GetServicesBySalon/{salon}")]
        public async Task<IActionResult> GetSericesBySalon(string salon)
        {
            var services = await _servicesService.GetServiceBySalonAsync(salon);
            return Ok(services);
        }
    }
}
