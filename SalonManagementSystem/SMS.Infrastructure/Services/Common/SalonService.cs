using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Servicess.Common
{
    public class SalonService : ISalonService
    {
        private readonly ISalonRepo _salonRepo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public SalonService(ISalonRepo salonRepo,IMapper mapper,IConfiguration configuration)
        {
            _salonRepo = salonRepo;
            _mapper = mapper;
            _config = configuration;
        }
        public async Task<IEnumerable<UpdateViewSalonDto>> GetAllSalonAsync()
        {
                var salon = await _salonRepo.GetAllAsync();
            if (salon == null) {
                throw new NullReferenceException("No salon found");
            }
                var salonDto = _mapper.Map<IEnumerable<UpdateViewSalonDto>>(salon);
                return salonDto;
        }

        public async Task<IEnumerable<UpdateViewSalonDto>> GetSalonByNearByLandMarkAsync(string location)
        {
            var salonEntity = await _salonRepo.GetSalonByNearbyLandmark(location);
            if (salonEntity == null || !salonEntity.Any())
            {
                throw new NullReferenceException("No salon found at this location");
            }
            var salonDto = _mapper.Map<IEnumerable<UpdateViewSalonDto>>(salonEntity);
            return salonDto ;
        }

        public async Task<IEnumerable<UpdateViewSalonDto>> GetSalonByNameAsync(string salonName)
        {
            var salonEntity = await _salonRepo.GetSalonByName(salonName);
            if (salonEntity == null || !salonEntity.Any())
            {
                throw new NullReferenceException("No salon found at this Name");
            }
            var salonDto = _mapper.Map<IEnumerable<UpdateViewSalonDto>>(salonEntity);
            return salonDto ;
        }

        public async Task<IEnumerable<UpdateViewSalonDto>> GetSalonByPincodeAsync(string pincode)
        {
            var salonEntity = await _salonRepo.GetSalonByPincode(pincode);
            if (salonEntity == null || !salonEntity.Any())
            {
                throw new NullReferenceException("No salon found at this laocation");
            }
            var salonDto = _mapper.Map<IEnumerable<UpdateViewSalonDto>>(salonEntity);
            return  salonDto ;
        }
    }
}
