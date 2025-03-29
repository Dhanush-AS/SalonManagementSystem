using SMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices
{
    public interface ICustomerService
    {
        Task RegisterCustomerAsync(CustomerRegisterDto customerRegDto);
        Task<string> LoginCustomerAsync(CustomerLoginDto customerLogin);
        Task<CustomerUpdateViewDto> GetCustomerByIdAsync(string id);
        Task<CustomerUpdateViewDto> GetCustomerByEmailAsync(string email);
        Task UpdateCustomerAsync(CustomerUpdateViewDto customerUpdateViewDto);
        Task ResetCustomerPasswordAsync(string id, string newPassword);
        Task DeleteAccountAsync(string id);
    }
}
