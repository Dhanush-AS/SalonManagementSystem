using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMS.Domain.Appoiontment;

namespace SMS.Application.DTOs.Appointment
{
    public class UpdateAppointmentCustomerDto
    {
        public Guid AppointmentId { get; set; } // Primary Key
        public string SpecialRequests { get; set; } // Special requests from the customer
        public DateTime? CheckInTime { get; set; } // Timestamp for when the customer checks in
    }
}
