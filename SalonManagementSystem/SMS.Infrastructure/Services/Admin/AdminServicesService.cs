using AutoMapper;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.IServices.Admin;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services.Admin
{
    public class AdminServicesService : IAdminServicesService
    {
        private readonly IServicesRepo _servicesRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AdminServicesService(IServicesRepo servicesRepo, IMapper mapper, IConfiguration configuration)
        {
            _servicesRepo = servicesRepo;
            _mapper = mapper;
            _config = configuration;
        }
        public async Task DeleteServiceAsync(string id)
        {
            await _servicesRepo.DeleteAsync(id);
        }

        public async Task RegisterServiceAsync(ServicesDto servicesDto)
        {
            var name = await _servicesRepo.GetServicesByNameAsync(servicesDto.ServiceName);
            if (name != null) // Fixing the logic to check existence
            {
                throw new InvalidOperationException("A service with the given name already exists.");
            }
            var service = _mapper.Map<SalonServices>(servicesDto);
            await _servicesRepo.AddAsync(service);

        }

        public async Task UpdateServiceAsync(ServicesDto servicesDto)
        {
            string id = servicesDto.ServiceId.ToString();
          
            // Fetch the Customer entity from the repository
            var servicesEntity = await _servicesRepo.GetByIdAsync(id);

            // Update the fields only if a value is provided (not null or empty)
            if (!string.IsNullOrEmpty(servicesDto.ServiceName))
            {
                servicesEntity.ServiceName = servicesDto.ServiceName;
            }

            if (!string.IsNullOrEmpty(servicesDto.Price.ToString()))
            {
                servicesEntity.Price = servicesDto.Price;
            }

            if (!string.IsNullOrEmpty(servicesDto.Description))
            {
                servicesEntity.Description = servicesDto.Description;
            }

            if (!string.IsNullOrEmpty(servicesDto.Duration.ToString()))
            {
                servicesEntity.Duration = servicesDto.Duration;
            }

            // Save the updated Customer entity
            await _servicesRepo.UpdateAsync(servicesEntity, id);
        }

    }
}
