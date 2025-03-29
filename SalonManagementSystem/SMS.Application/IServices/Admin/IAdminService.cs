using System;
using SMS.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Application.DTOs;

namespace SMS.Application.IServices.Admin
{
    public interface IAdminService
    {
        Task RegisterAdminAsync(AdminRegisterDto adminRegDto);
        Task<string> LoginAdminAsync(AdminLoginDto adminLogin);
        Task<AdminUpdateViewDto> GetAdminByIdAsync(string id);
        Task<AdminUpdateViewDto> GetAdminByEmailAsync(string email);
        Task UpdateAdminAsync(AdminUpdateViewDto adminUpdateViewDto);
        Task ResetAdminPasswordAsync(string id, string newPassword);
        Task DeleteAccountAsync(string id);
    }
}
