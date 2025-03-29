using SMS.Application.DTOs;
using SMS.Application.IServices.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices
{
    public interface IAdminSalonService 
    {
        Task RegisterSalon(RegisterSalonDto registerSalon);
        Task DeleteSalon();
        Task UpdateSalon(UpdateViewSalonDto updateSalon);
        Task ChangeStatus(bool status);
        Task<UpdateViewSalonDto> GetSalonByIDAsync();

    }
}
