using SMS.Application.DTOs;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Persistance.Contracts
{
    public interface IAdminRepo : IGenricRepo<Admin> 
    {
        Task<Admin>GetByEmailAsync(string email);

    }
}
