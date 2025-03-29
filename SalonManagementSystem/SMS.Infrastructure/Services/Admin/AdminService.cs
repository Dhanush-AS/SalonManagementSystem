using AutoMapper;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
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

namespace SMS.Infrastructure.Service.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo _adminRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AdminService(IAdminRepo adminRepo, IMapper mapper, IConfiguration config)
        {
            _adminRepo = adminRepo;
            _mapper = mapper;
            _config = config;
        }
        public async Task DeleteAccountAsync(string id)
        {
            
            await _adminRepo.DeleteAsync(id);
        }

        public async Task<AdminUpdateViewDto> GetAdminByEmailAsync(string email)
        {
            var result = await _adminRepo.GetByEmailAsync(email);
            var adminEntity = _mapper.Map<AdminUpdateViewDto>(result);
            return adminEntity;
        }

        public async Task<AdminUpdateViewDto> GetAdminByIdAsync(string id)
        {
            var result = await _adminRepo.GetByIdAsync(id.ToString());
            var adminEntity = _mapper.Map<AdminUpdateViewDto>(result);
            return adminEntity;
        }

        public async Task<string> LoginAdminAsync(AdminLoginDto adminLogin)
        {
            string token;
            var adminEntity = await _adminRepo.GetByEmailAsync(adminLogin.Email);
            if (adminEntity == null)
            {
                throw new Exception("Admin not found");
            }
            if (BCrypt.Net.BCrypt.Verify(adminLogin.Password, adminEntity.Password))
            {
                adminLogin.AdminId = adminEntity.AdminId;
                token = GenerateToken(adminLogin);
                return token;

            }
            else
            {
                throw new Exception("Invalid attempt");
            }
        }

        public async Task RegisterAdminAsync(AdminRegisterDto adminRegDto)
        {
            var result = await _adminRepo.GetByEmailAsync(adminRegDto.Email);
            if (result != null)
            {
                throw new DuplicateEmailException(adminRegDto.Email);
            }
            else
            {
                adminRegDto.Password = BCrypt.Net.BCrypt.HashPassword(adminRegDto.Password);
                var adminEntity = _mapper.Map<Admin>(adminRegDto);
                await _adminRepo.AddAsync(adminEntity);
            }
        }


        public async Task  ResetAdminPasswordAsync(string id, string newPassword)
        {
            var adminEntity = await _adminRepo.GetByIdAsync(id.ToString());
            if (BCrypt.Net.BCrypt.Verify(newPassword, adminEntity.Password))
            {
                throw new ArgumentException("New password cannot be the same as the current password.");
            }

            // Hash the new password before saving it to the database
            adminEntity.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Update the admin entity with the new password
            await _adminRepo.UpdateAsync(adminEntity, id.ToString());
        }

        public async Task UpdateAdminAsync(AdminUpdateViewDto adminUpdateViewDto)
        {
            string id = adminUpdateViewDto.AdminId.ToString();

            // Fetch the admin entity from the repository
            var adminEntity = await _adminRepo.GetByIdAsync(id);

            // Update the fields only if a value is provided (not null or empty)
            if (!string.IsNullOrEmpty(adminUpdateViewDto.AdminName))
            {
                adminEntity.AdminName = adminUpdateViewDto.AdminName;
            }

            if (!string.IsNullOrEmpty(adminUpdateViewDto.PhoneNumber))
            {
                adminEntity.PhoneNumber = adminUpdateViewDto.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(adminUpdateViewDto.FirstName))
            {
                adminEntity.FirstName = adminUpdateViewDto.FirstName;
            }

            if (!string.IsNullOrEmpty(adminUpdateViewDto.LastName))
            {
                adminEntity.LastName = adminUpdateViewDto.LastName;
            }
            if (!string.IsNullOrEmpty(adminUpdateViewDto.SalonId))
            {
                adminEntity.SalonId = adminUpdateViewDto.SalonId;
            }

            // Save the updated admin entity
            await _adminRepo.UpdateAsync(adminEntity, id);
        }


        //generate token
        public string GenerateToken(AdminLoginDto adminLogin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, adminLogin.Email),
                new Claim(ClaimTypes.Role, adminLogin.Role)
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

