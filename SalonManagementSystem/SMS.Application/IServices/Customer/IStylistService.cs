using SMS.Application.DTOs;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Common
{
    public interface IStylistService
    {
        Task<IEnumerable<UpdateViewStylistDto>> GetAllStylistAsync();
        Task<IEnumerable<UpdateViewStylistDto>> GetStylistBySalonAsync(string salonId);
        Task<IEnumerable<StylistServiceLinkDto>> GetStylistByServiceAsync(string serviceId);
        Task<UpdateViewStylistDto> GetStylistByNameAsync(string name);

    }
}
