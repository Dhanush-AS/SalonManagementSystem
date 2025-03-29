using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.DTOs;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SMS.Application.IServices;
using SMS.Domain;

namespace SMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _taskRepository;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService, ICustomerRepo taskRepository)
        {
            _customerService = customerService;
            _taskRepository = taskRepository;
        }

        [HttpPost("RegisterCustomerAsync")]
        public async Task<IActionResult> RegisterCustomerAsync([FromBody] CustomerRegisterDto customerRegisterDto)
        {
            await _customerService.RegisterCustomerAsync(customerRegisterDto);
            return Ok();

        }

        [HttpPost("CustomerLogin")]
        public async Task<IActionResult> CustomerLogin([FromBody] CustomerLoginDto customerLoginDto)
        {
            string token = await _customerService.LoginCustomerAsync(customerLoginDto);
            HttpContext.Session.SetString("Email", customerLoginDto.CustomerEmail);
            HttpContext.Session.SetString("UserId", customerLoginDto.CustomerId.ToString());
            return Ok(token);
        }

        [HttpGet("GetCustomerByEmailAsync")]
        public async Task<IActionResult> GetByEmail()
        {
            string email = HttpContext.Session.GetString("Email");
            if (email == null)
            {
                throw new NullReferenceException("Null value");
            }
            var item = await _customerService.GetCustomerByEmailAsync(email);
            return Ok(item);
        }

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById()
        {
            string CustomerId = HttpContext.Session.GetString("UserId");
            if (CustomerId == null)
            {
                throw new NullReferenceException("Null value");
            }
            var CustomerDetails = await _customerService.GetCustomerByIdAsync(CustomerId);

            return Ok(CustomerDetails);
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerUpdateViewDto CustomerUpdateViewDto)
        {
            string CustomerId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(CustomerId))
            {
                return Unauthorized(new { message = "User is not authenticated or session has expired." });
            }

            CustomerUpdateViewDto.CustomerId = CustomerId;

            try
            {
                await _customerService.UpdateCustomerAsync(CustomerUpdateViewDto);
                return Ok(new { message = "Customer updated successfully.", data = CustomerUpdateViewDto });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the Customer.", details = ex.Message });
            }
        }

        [HttpDelete("DeleteAccount")]
        public async Task<IActionResult> DeleteAccount()
        {
            string CustomerId = HttpContext.Session.GetString("UserId");
            if (CustomerId == null)
            {
                throw new NullReferenceException("Null value");
            }
            await _customerService.DeleteAccountAsync(CustomerId);
            return Ok();
        }
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetCustomerPassword(string newPassword)
        {
            string CustomerId = HttpContext.Session.GetString("UserId");
            if (CustomerId == null)
            {
                throw new NullReferenceException("Null value");
            }
            await _customerService.ResetCustomerPasswordAsync(CustomerId, newPassword);
            return Ok("Password reseted sucessfully");
        }

    }
}
