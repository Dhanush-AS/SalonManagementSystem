using SMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Common
{
    public interface IServicesService
    {
       Task<ServicesDto> GetServiceByIdAsync(string id);
       Task<ServicesDto> GetServiceByNameAsync(string name);
       Task<IEnumerable<ServicesDto>> GetServiceByPriceAsync(int price);
       Task<IEnumerable<ServicesDto>> GetServiceBySalonAsync(string salonId);
       Task<IEnumerable<ServicesDto>> GetAllServices();

    }
}
