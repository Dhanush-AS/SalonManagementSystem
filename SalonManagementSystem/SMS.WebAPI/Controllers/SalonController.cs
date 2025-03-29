using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.IServices;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using System.Threading.Tasks;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        private readonly ISalonRepo _salonRepo;
        private readonly ISalonService _salonService;
        private readonly IAdminSalonService _adminSalonService;
        private readonly IAdminService _adminService;

        public SalonController(ISalonRepo salonRepo, ISalonService salonService, IAdminSalonService adminSalonService, IAdminService adminService)
        {
            _salonRepo = salonRepo;
            _salonService = salonService;
            _adminSalonService = adminSalonService;
            _adminService = adminService;
        }

        //admin

        [HttpPost("RegisterSalon")]
        public async Task<IActionResult> RegisterSalon([FromBody] RegisterSalonDto registerSalonDto)
        {
            await _adminSalonService.RegisterSalon(registerSalonDto);
            return Ok();
        }
        [HttpDelete("DeleteSalon")]
        public async Task<IActionResult> DeleteSalon()
        {
            await _adminSalonService.DeleteSalon();
            return Ok();
        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> Changestatus( bool status)
        {
            await _adminSalonService.ChangeStatus(status);
            return Ok();
        }
        [HttpPut("UpdateSalon")]
        public async Task<IActionResult> UpdateSalon([FromBody] UpdateViewSalonDto updateSalonDto)
        {
            await _adminSalonService.UpdateSalon(updateSalonDto);
            return Ok();
        }
       
        [HttpGet("GetSalonByID")]
        public async Task<IActionResult> GetSalonByID()
        {
            var result = await _adminSalonService.GetSalonByIDAsync();
            return Ok(result);
        }


        //customer
        [HttpGet("GetAllSalon")]
        public async Task<IActionResult> GetAllSalon()
        {
            var result = await _salonService.GetAllSalonAsync();
            return Ok(result);
        }

        [HttpGet("SalonByPincode/{pincode}")]
        public async Task<IActionResult> SalonByPincode(string pincode)
        {
            var result = await _salonService.GetSalonByPincodeAsync(pincode);
            return Ok(result);
        }
        
        [HttpGet("GetSalonByNearByLandMark/{landmark}")]
        public async Task<IActionResult> GetSalonByNearByLandMark(string landmark)
        {
            var result = await _salonService.GetSalonByNearByLandMarkAsync(landmark);
            return Ok(result);
        }
        [HttpGet("GetSalonByName/{name}")]
        public async Task<IActionResult> GetSalonByName(string name)
        {
            var result = await _salonService.GetSalonByNameAsync(name);
            return Ok(result);
        }

    }
}