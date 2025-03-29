using AutoMapper;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
using SMS.Application.IServices.Common;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Repository;
using SMS.Infrastructure.Service.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services.Admin
{
    public class AdminStylistService : IAdminStylistService
    {
        private readonly IStylistRepo _stylistRepo;
        private readonly IMapper _mapper;
        private readonly IServicesService _servicesService;
        private readonly IStylistServiceLinkService _stylistLinkService;
        private readonly IStylistService _stylistService;
        public AdminStylistService(IStylistRepo stylistRepo, IMapper mapper, IServicesService servicesService, IStylistServiceLinkService stylistLinkService, IStylistService stylistService)
        {
            _stylistRepo = stylistRepo;
            _mapper = mapper;
            _servicesService = servicesService;
            _stylistLinkService = stylistLinkService;
            _stylistService = stylistService;
        }

        public async Task AddStylistAsync(AddStylistDto addStylistDto,string serviceName)
        {
            var stylistEntitiy = _mapper.Map<Stylist>(addStylistDto);
            await _stylistRepo.AddAsync(stylistEntitiy);
            string name = addStylistDto.StylistName;
            Func( serviceName , name);
  
        }
        public async void Func(string serviceName , string stylistname)
        {
            try
            {
                var serviceEntity = await _servicesService.GetServiceByNameAsync(serviceName);
                var entity = _mapper.Map<ServicesDto>(serviceEntity);
                string serviceId = entity.ServiceId;
                var stylistFetchedEntity = await _stylistService.GetStylistByNameAsync(stylistname);
                string stylistId = stylistFetchedEntity.StylistId;
                StylistServiceLinkDto serviceLinkDto = new StylistServiceLinkDto();
                serviceLinkDto.StylistId = stylistId;
                serviceLinkDto.ServiceId = serviceId;
                await _stylistLinkService.AddStylistServiceLink(serviceLinkDto);
            }
            catch (Exception ex)
            {
                throw new Exception("Inside func");
            }
        }

        public async Task DeleteStylistAsync(string stylistId)
        {
            await _stylistRepo.DeleteAsync(stylistId);
        }

        public async Task UpdateStylistAsync(UpdateViewStylistDto updateStylistDto)
        {
            // Fetch the stylist entity by ID
            var stylistEntity = await _stylistRepo.GetByIdAsync(updateStylistDto.StylistId);

            if (stylistEntity == null)
            {
                throw new NullReferenceException($"No stylist found with ID {updateStylistDto.StylistId}");
            }

            // Update the fields only if a value is provided (not null or empty)
            if (!string.IsNullOrEmpty(updateStylistDto.StylistName))
            {
                stylistEntity.StylistName = updateStylistDto.StylistName;
            }

            if (!string.IsNullOrEmpty(updateStylistDto.Specializations))
            {
                stylistEntity.Specializations = updateStylistDto.Specializations;
            }

            stylistEntity.StylistName = string.IsNullOrEmpty(updateStylistDto.StylistName) ? stylistEntity.StylistName : updateStylistDto.StylistName;
            stylistEntity.Specializations = string.IsNullOrEmpty(updateStylistDto.Specializations) ? stylistEntity.Specializations : updateStylistDto.Specializations;
            if (updateStylistDto.Experience > 0) // Or any relevant condition
            {
                stylistEntity.Experience = updateStylistDto.Experience;
            }
            stylistEntity.PhoneNumber = string.IsNullOrEmpty(updateStylistDto.PhoneNumber) ? stylistEntity.PhoneNumber : updateStylistDto.PhoneNumber;
            stylistEntity.Email = string.IsNullOrEmpty(updateStylistDto.Email) ? stylistEntity.Email : updateStylistDto.Email;
            stylistEntity.CurrentStatus = string.IsNullOrEmpty(updateStylistDto.CurrentStatus) ? stylistEntity.CurrentStatus : updateStylistDto.CurrentStatus;
            if (updateStylistDto.IsAvailable)
            {
                stylistEntity.IsAvailable = updateStylistDto.IsAvailable;
            }
            stylistEntity.Status = string.IsNullOrEmpty(updateStylistDto.Status) ? stylistEntity.Status : updateStylistDto.Status;
            stylistEntity.WorkingHours = string.IsNullOrEmpty(updateStylistDto.WorkingHours) ? stylistEntity.WorkingHours : updateStylistDto.WorkingHours;

            // Save the updated stylist entity
            await _stylistRepo.UpdateAsync(stylistEntity, stylistEntity.StylistId);
        }
    }
}