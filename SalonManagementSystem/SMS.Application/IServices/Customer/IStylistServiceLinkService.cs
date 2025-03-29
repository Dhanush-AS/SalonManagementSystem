using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Application.DTOs;
namespace SMS.Application.IServices.Customer
{
    public interface IStylistServiceLinkService
    {
        Task AddStylistServiceLink(StylistServiceLinkDto styistServiceLinkDto);
        Task DeleteStylistServiceLink(string stylistServiceLinkId);
        Task UpdateStlisServiceLink(StylistServiceLinkDto styistServiceLinkDto);
        Task<StylistServiceLinkDto> GetStylistServiceLinkByID(string stylistServiceLinkId);
    }
}
