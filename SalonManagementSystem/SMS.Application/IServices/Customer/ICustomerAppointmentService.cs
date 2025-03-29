using SMS.Application.DTOs;
using SMS.Application.DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMS.Application.IServices
{
    public interface ICustomerAppointmentService
    {
        Task BookAppointmentAsync(BookAppointmentCustomerDto bookAppointmentDto);
        Task CancelAppointmentAsync(CancelAppointmentCustomerDto cancelAppointmentDto);
        Task<IEnumerable<ViewAppointmentDto>> ViewAppointmentAsync(Guid appointmentId);
        Task<IEnumerable<ViewAppointmentDto>> ViewAllAppointmentsAsync(Guid customerId);

        Task UpdateAppointmentAsync(UpdateAppointmentCustomerDto updateAppointmentDto);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<string> GetAppointmentStatusAsync(Guid appointmentId);
        Task SendAppointmentReminderAsync(Guid appointmentId);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentsBySalonAsync(Guid salonId);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentsByStylistAsync(Guid stylistId);
        Task<IEnumerable<ViewAppointmentDto>> GetAppointmentsByServiceAsync(Guid serviceId);

    }
}
