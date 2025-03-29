using AutoMapper;
using SMS.Application.DTOs;
using SMS.Application.IServices.Customer;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Services.Common
{
    public class StylistServiceLinkService : IStylistServiceLinkService
    {
        private readonly IStlyistServiceLinkRepo _stylistServiceLinkRepo;
        private readonly IMapper _mapper;
        public StylistServiceLinkService(IStlyistServiceLinkRepo stylistServiceLinkRepo, IMapper mapper)
        {
            _stylistServiceLinkRepo = stylistServiceLinkRepo;
            _mapper = mapper;
        }
        public async  Task AddStylistServiceLink(StylistServiceLinkDto styistServiceLinkDto)
        {
            styistServiceLinkDto.StyleServiceLinkId = Guid.NewGuid().ToString();
            styistServiceLinkDto.id = styistServiceLinkDto.StyleServiceLinkId;
            var item = _mapper.Map<StyistServiceLink>(styistServiceLinkDto);
            await _stylistServiceLinkRepo.AddAsync(item);
        }

        public async Task DeleteStylistServiceLink(string stylistServiceLinkId)
        {
            await _stylistServiceLinkRepo.DeleteAsync(stylistServiceLinkId);
        }

        public async Task<StylistServiceLinkDto> GetStylistServiceLinkByID(string stylistServiceLinkId)
        {
            var item = await _stylistServiceLinkRepo.GetByIdAsync(stylistServiceLinkId);
            if (item == null)
            {
                throw new Exception("Not found ");
            }
            var stylist = _mapper.Map<StylistServiceLinkDto>(item);
            return stylist;
        }

        public Task UpdateStlisServiceLink(StylistServiceLinkDto styistServiceLinkDto)
        {
            throw new NotImplementedException();
        }
    }
}
