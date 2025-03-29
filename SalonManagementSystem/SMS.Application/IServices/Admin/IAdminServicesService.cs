using SMS.Application.DTOs;
using SMS.Application.IServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Admin
{
    public interface IAdminServicesService 
    {
        Task RegisterServiceAsync(ServicesDto servicesDto);
        Task UpdateServiceAsync(ServicesDto servicesDto);
        Task DeleteServiceAsync(string id);

    }
}
