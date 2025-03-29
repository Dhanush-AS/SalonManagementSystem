using SMS.Application.DTOs;
using SMS.Application.IServices.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Admin
{
    public interface IAdminStylistService
    {
        Task AddStylistAsync(AddStylistDto addStylistDto, string serviceName);
        Task DeleteStylistAsync(string stylistId);
        Task UpdateStylistAsync(UpdateViewStylistDto updateStylistDto);
    }
}
