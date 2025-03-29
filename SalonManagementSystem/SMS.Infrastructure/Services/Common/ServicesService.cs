using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.IServices.Common;
using SMS.Application.Persistance.Contracts;
using SMS.Infrastructure.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services.Common
{
    public class ServicesService :IServicesService
    {
        private readonly IServicesRepo _servicesRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ServicesService(IServicesRepo servicesRepo, IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _servicesRepo = servicesRepo;
            _mapper = mapper;
            _config = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ServicesDto>> GetAllServices()
        {
            var services = await _servicesRepo.GetAllAsync();
            if (services == null || !services.Any())
            {
                throw new NullReferenceException("No services found");
            }
            var servicesEntity = _mapper.Map <IEnumerable<ServicesDto>>(services);
            return servicesEntity;
        }

        public async Task<ServicesDto> GetServiceByIdAsync(string id)
        {
            var services = await _servicesRepo.GetByIdAsync(id);
            if (services == null)
            {
                throw new NullReferenceException("No services found");
            }
            var servicesEntity = _mapper.Map<ServicesDto>(services);
            return servicesEntity;
        }

        public async Task <ServicesDto> GetServiceByNameAsync(string name)
        {
            var services = await _servicesRepo.GetServicesByNameAsync(name);
            if (services == null )
            {
                throw new NullReferenceException("No services found");
            }
            var servicesEntity = _mapper.Map<ServicesDto>(services);
            return servicesEntity;
        }

        public async Task<IEnumerable<ServicesDto>> GetServiceByPriceAsync(int price)
        {
            var services = await _servicesRepo.GetServicesByPriceAsync(price);
            if (services == null || !services.Any())
            {
                throw new NullReferenceException("No services found");
            }
            var servicesEntity = _mapper.Map<IEnumerable<ServicesDto>>(services);
            return servicesEntity;
        }

        public async Task<IEnumerable<ServicesDto>> GetServiceBySalonAsync(string id)
        {
            var services = await _servicesRepo.GetServicesBySalonAsync(id);
            if (services == null || !services.Any())
            {
                throw new NullReferenceException("No services found");
            }
            var servicesEntity = _mapper.Map<IEnumerable<ServicesDto>>(services);
            return servicesEntity;
        }
    }
}
