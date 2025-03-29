using SMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Customer
{
    public interface ISalonService
    {
        Task<IEnumerable<UpdateViewSalonDto>> GetSalonByNameAsync(string salonName);
        Task<IEnumerable<UpdateViewSalonDto>> GetSalonByNearByLandMarkAsync(string location);
        Task<IEnumerable<UpdateViewSalonDto>> GetSalonByPincodeAsync(string picode);
        Task<IEnumerable<UpdateViewSalonDto>> GetAllSalonAsync();
    }
}
