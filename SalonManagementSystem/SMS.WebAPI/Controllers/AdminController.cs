using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo _taskRepository;
        private readonly IAdminService _adminService;

        public AdminController(IAdminRepo taskRepository, IAdminService adminService)
        {
            _taskRepository = taskRepository;
            _adminService = adminService;
        }

        //[HttpPost("RegisterAdminAsync")]
        //public async Task<IActionResult> RegisterAdminAsync([FromBody] AdminRegisterDto adminRegisterDto)
        //{
        //    await _adminService.RegisterAdminAsync(adminRegisterDto);
        //    return Ok();

        //}

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdminAsync([FromBody] AdminRegisterDto adminRegisterDto)
        {
            await _adminService.RegisterAdminAsync(adminRegisterDto);
            return Ok();

        }

        [HttpPost("AdminLogin")]
        public async Task<IActionResult> AdminLogin([FromBody] AdminLoginDto adminLoginDto)
        {
            string token = await _adminService.LoginAdminAsync(adminLoginDto);
            HttpContext.Session.SetString("Email", adminLoginDto.Email);
            HttpContext.Session.SetString("UserId", adminLoginDto.AdminId.ToString());
            return Ok(token);
        }

        [HttpGet("GetAdminByEmail")]
        public async Task<IActionResult> GetByEmail()
        {
            string email = HttpContext.Session.GetString("Email");
            if (email == null)
            {
                throw new NullReferenceException("Null value");
            }
            var item = await _adminService.GetAdminByEmailAsync(email);
            return Ok(item);
        }

        [HttpGet("GetAdminById")]
        public async Task<IActionResult> GetAdminById() {
            string adminId = HttpContext.Session.GetString("UserId");
            if (adminId == null)
            {
                throw new NullReferenceException("Null value");
            }
            var adminDetails = await _adminService.GetAdminByIdAsync(adminId);

            return Ok(adminDetails);
        }

        [HttpPut("UpdateAdmin")]
        public async Task<IActionResult> UpdateAdmin([FromBody] AdminUpdateViewDto adminUpdateViewDto)
        {
            string adminId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(adminId))
            {
                return Unauthorized(new { message = "User is not authenticated or session has expired." });
            }

            adminUpdateViewDto.AdminId = adminId;

            try
            {
                await _adminService.UpdateAdminAsync(adminUpdateViewDto);
                return Ok(new { message = "Admin updated successfully.", data = adminUpdateViewDto });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the admin.", details = ex.Message });
            }
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount()
        {
            string adminId = HttpContext.Session.GetString("UserId");
            if (adminId == null)
            {
                throw new NullReferenceException("Null value");
            }
            await _adminService.DeleteAccountAsync(adminId);
            return Ok();
        }
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetAdminPassword(string newPassword)
        {
            string adminId= HttpContext.Session.GetString("UserId");
            if (adminId == null)
            {
                throw new NullReferenceException("Null value");
            }
            await _adminService.ResetAdminPasswordAsync(adminId,newPassword);
            return Ok("Password reseted sucessfully");
        }




    }
}