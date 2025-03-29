using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.IServices;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Service.AdminService;
using SMS.Infrastructure.Servicess.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services.Admin
{
    public class AdminSalonService : IAdminSalonService
    {
        private readonly ISalonRepo _salonRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAdminService _adminService;

        public AdminSalonService(ISalonRepo salonRepo, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor , IAdminService adminService)
        {
            _salonRepo = salonRepo;
            _mapper = mapper;
            _config = configuration;
            _httpContextAccessor = httpContextAccessor;
            _adminService = adminService;

        }

        public async Task ChangeStatus(bool status)
        {
            string Adminid = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            AdminUpdateViewDto admin = await _adminService.GetAdminByIdAsync(Adminid);
            string id = admin.SalonId;
            var salon = await _salonRepo.GetByIdAsync(id);
            salon.CurrentStatus = status;
            await _salonRepo.UpdateAsync(salon, id);
        }

        public async  Task DeleteSalon()
        {
            string Adminid = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            AdminUpdateViewDto admin = await _adminService.GetAdminByIdAsync(Adminid);
            string salonId = admin.SalonId;
            await _salonRepo.DeleteAsync(salonId);
        }

        public async Task RegisterSalon(RegisterSalonDto registerSalon)
        {
           
            string Adminid = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            AdminUpdateViewDto admin = await _adminService.GetAdminByIdAsync(Adminid);
            // Check if salon already exists based on Pincode and Name
            var salon = await _salonRepo.GetSalonByPincodeAndName(registerSalon.Pincode, registerSalon.SalonName);

            if (salon != null)
            {
                throw new DuplicateNameException("Salon already exists");
            }

            // Map RegisterSalonDto to Salon entity
            var salonEntity = _mapper.Map<Salon>(registerSalon);

            // Add the new salon entity to the repository
            await _salonRepo.AddAsync(salonEntity);
            admin.SalonId = salonEntity.SalonId;
            await _adminService.UpdateAdminAsync(admin);
        }


        public async Task UpdateSalon(UpdateViewSalonDto updateSalon)
        {
            string Adminid = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            AdminUpdateViewDto admin = await _adminService.GetAdminByIdAsync(Adminid);
            string id = admin.SalonId; // Assuming 'SalonId' is available in UpdateViewSalonDto

            // Fetch the salon entity from the repository
            var salonEntity = await _salonRepo.GetByIdAsync(id);

            // Update the fields only if a value is provided (not null or empty)
            if (!string.IsNullOrEmpty(updateSalon.SalonName))
            {
                salonEntity.SalonName = updateSalon.SalonName;
            }

            if (!string.IsNullOrEmpty(updateSalon.Address))
            {
                salonEntity.Address = updateSalon.Address;
            }

            if (!string.IsNullOrEmpty(updateSalon.Pincode))
            {
                salonEntity.Pincode = updateSalon.Pincode;
            }

            if (!string.IsNullOrEmpty(updateSalon.NearbyLandmark))
            {
                salonEntity.NearbyLandmark = updateSalon.NearbyLandmark;
            }

            if (!string.IsNullOrEmpty(updateSalon.City))
            {
                salonEntity.City = updateSalon.City;
            }

            if (!string.IsNullOrEmpty(updateSalon.PhoneNumber))
            {
                salonEntity.PhoneNumber = updateSalon.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(updateSalon.Description))
            {
                salonEntity.Description = updateSalon.Description;
            }

            // Check if the times are valid before updating
            if (updateSalon.OpeningTime != null)
            {
                salonEntity.OpeningTime = updateSalon.OpeningTime;
            }

            if (updateSalon.ClosingTime != null)
            {
                salonEntity.ClosingTime = updateSalon.ClosingTime;
            }

            if (!string.IsNullOrEmpty(updateSalon.Holidays))
            {
                salonEntity.Holidays = updateSalon.Holidays;
            }

            // Save the updated salon entity
            await _salonRepo.UpdateAsync(salonEntity, id);
        }
        public async Task<UpdateViewSalonDto> GetSalonByIDAsync()
        {
            string Adminid = _httpContextAccessor.HttpContext?.Session.GetString("UserId");
            AdminUpdateViewDto admin = await _adminService.GetAdminByIdAsync(Adminid);
            string id = admin.SalonId;
            var salonEntity = await _salonRepo.GetByIdAsync(id);
            if (salonEntity == null)
            {
                throw new NullReferenceException("No salon at this id was found");
            }
            var salonDto = _mapper.Map<UpdateViewSalonDto>(salonEntity);
            return salonDto;
        }

    }
}