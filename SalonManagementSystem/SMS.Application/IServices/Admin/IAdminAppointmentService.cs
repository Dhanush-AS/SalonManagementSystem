using SMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices
{
    public interface IAdminAppointmentService
    {
        Task <IEnumerable<ViewAppointmentDto>> GetAllAppointmentsAsync();
        Task <IEnumerable<ViewAppointmentDto>> GetAppointmentByUserEmailAsync(string email);//
        Task ChangeStatusAsync(Guid appointmentId, string newStatus);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentsByStatusAsync(string status);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentByServiceAsync(Guid serviceId);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
