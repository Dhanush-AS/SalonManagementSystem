using AutoMapper;
using SMS.Application.DTOs;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Domain;
using SMS.Application;
using SMS.Infrastructure.CustomExceptions;
using Microsoft.Azure.Cosmos;
using System.Net.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using SMS.Application.IServices;

namespace SMS.Infrastructure.Service.AdminService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public CustomerService(ICustomerRepo customerRepo, IMapper mapper, IConfiguration config)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
            _config = config;
        }
        public async Task DeleteAccountAsync(string id)
        {

            await _customerRepo.DeleteAsync(id);
        }

        public async Task<CustomerUpdateViewDto> GetCustomerByEmailAsync(string email)
        {
            var result = await _customerRepo.GetByEmailAsync(email);
            var customerEntity = _mapper.Map<CustomerUpdateViewDto>(result);
            return customerEntity;
        }

        public async Task<CustomerUpdateViewDto> GetCustomerByIdAsync(string id)
        {
            var result = await _customerRepo.GetByIdAsync(id.ToString());
            var customerEntity = _mapper.Map<CustomerUpdateViewDto>(result);
            return customerEntity;
        }

        public async Task<string> LoginCustomerAsync(CustomerLoginDto customerLogin)
        {
            string token;
            var customerEntity = await _customerRepo.GetByEmailAsync(customerLogin.CustomerEmail);
            if (customerEntity == null || customerEntity.IsDeleted)
            {
                throw new Exception("Customer not found");
            }
            if (BCrypt.Net.BCrypt.Verify(customerLogin.Password, customerEntity.Password))
            {
                customerLogin.CustomerId = customerEntity.CustomerId;
                token = GenerateToken(customerLogin);
                return token;

            }
            else
            {
                throw new Exception("Invalid attempt");
            }
        }

        public async Task RegisterCustomerAsync(CustomerRegisterDto customerRegDto)
        {
            var result = await _customerRepo.GetByEmailAsync(customerRegDto.CustomerEmail);
            if (result != null)
            {
                throw new DuplicateEmailException(customerRegDto.CustomerEmail);
            }
            else
            {
                customerRegDto.Password = BCrypt.Net.BCrypt.HashPassword(customerRegDto.Password);
                var customerEntity = _mapper.Map<Customer>(customerRegDto);
                await _customerRepo.AddAsync(customerEntity);
            }
        }


        public async Task ResetCustomerPasswordAsync(string id, string newPassword)
        {
            var customerEntity = await _customerRepo.GetByIdAsync(id.ToString());
            if (BCrypt.Net.BCrypt.Verify(newPassword, customerEntity.Password))
            {
                throw new ArgumentException("New password cannot be the same as the current password.");
            }

            // Hash the new password before saving it to the database
            customerEntity.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Update the Customer entity with the new password
            await _customerRepo.UpdateAsync(customerEntity, id.ToString());
        }

        public async Task UpdateCustomerAsync(CustomerUpdateViewDto customerUpdateViewDto)
        {
            string id = customerUpdateViewDto.CustomerId.ToString();

            // Fetch the Customer entity from the repository
            var customerEntity = await _customerRepo.GetByIdAsync(id);

            // Update the fields only if a value is provided (not null or empty)
            if (!string.IsNullOrEmpty(customerUpdateViewDto.CustomerName))
            {
                customerEntity.CustomerName = customerUpdateViewDto.CustomerName;
            }

            if (!string.IsNullOrEmpty(customerUpdateViewDto.PhoneNumber))
            {
                customerEntity.PhoneNumber = customerUpdateViewDto.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(customerUpdateViewDto.FirstName))
            {
                customerEntity.FirstName = customerUpdateViewDto.FirstName;
            }

            if (!string.IsNullOrEmpty(customerUpdateViewDto.LastName))
            {
                customerEntity.LastName = customerUpdateViewDto.LastName;
            }

            // Save the updated Customer entity
            await _customerRepo.UpdateAsync(customerEntity, id);
        }


        //generate token
        public string GenerateToken(CustomerLoginDto customerLogin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, customerLogin.CustomerEmail),
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

