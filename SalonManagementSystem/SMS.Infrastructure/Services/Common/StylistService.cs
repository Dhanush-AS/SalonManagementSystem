using AutoMapper;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.IServices.Common;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services.Common
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepo _stylistRepo;
        private readonly IMapper _mapper;

        public StylistService(IStylistRepo stylistRepo, IMapper mapper)
        {
            _stylistRepo = stylistRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UpdateViewStylistDto>> GetAllStylistAsync()
        {
            var stylist = await _stylistRepo.GetAllAsync();
            if (!stylist.Any())
            {
                throw new NullReferenceException("No stylist found");
            }
            var entity = _mapper.Map<IEnumerable<UpdateViewStylistDto>>(stylist);
            return entity;
        }

        public async Task<IEnumerable<UpdateViewStylistDto>> GetStylistBySalonAsync(string salonId)
        {
            // Fetch stylists by salon ID from the repository
            var stylists = await _stylistRepo.GetStylistBySalon(salonId);

            // Check if the result is null or empty
            if (stylists == null || !stylists.Any())
            {
                throw new NullReferenceException("No stylists found for the given salon ID.");
            }

            // Map the entities to the desired DTOs
            var stylistDtos = _mapper.Map<IEnumerable<UpdateViewStylistDto>>(stylists);

            return stylistDtos;
        }


        public async Task<IEnumerable<StylistServiceLinkDto>> GetStylistByServiceAsync(string styleServiceLinkId)
        {
            // Fetch stylists by salon ID from the repository
            var stylists = await _stylistRepo.GetStylistByService(styleServiceLinkId);

            // Check if the result is null or empty
            if (stylists == null || !stylists.Any())
            {
                throw new NullReferenceException("No stylists found for the given salon ID.");
            }

            // Map the entities to the desired DTOs
            var stylistDtos = _mapper.Map<IEnumerable<StylistServiceLinkDto>>(stylists);

            return stylistDtos;
        }

        public async Task<UpdateViewStylistDto> GetStylistByNameAsync(string name)
        {
            // Fetch a single stylist by name
            var stylist = await _stylistRepo.GetStylistByName(name);

            // Check if no stylist is found
            if (stylist == null)
            {
                throw new KeyNotFoundException("No stylist found with the given name.");
            }

            // Map the entity to the desired DTO
            var stylistDto = _mapper.Map<UpdateViewStylistDto>(stylist);

            return stylistDto;
        }


    }
}
