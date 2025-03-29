using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.IServices.Customer;
using System.Threading.Tasks;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistServiceLinkController : ControllerBase
    {
        private readonly IStylistServiceLinkService _stylistServiceLinkService;
        public StylistServiceLinkController(IStylistServiceLinkService stylistServiceLinkService)
        {
            _stylistServiceLinkService= stylistServiceLinkService;
        }

        [HttpPost("AddLink")]
        public async Task<IActionResult> AddLink(StylistServiceLinkDto stylistServiceLinkDto)
        {
            await _stylistServiceLinkService.AddStylistServiceLink(stylistServiceLinkDto);
            return Ok();
        }
    }
}
