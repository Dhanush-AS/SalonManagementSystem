using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMS.Domain.Appoiontment;

namespace SMS.Application.DTOs
{
    public class CancelAppointmentCustomerDto
    {
        //for Customer
        public String Status { get; set; } // Status: Approved, Pending, Cancelled
        public string CancellationReason { get; set; } // Reason for cancellation, if any

        //foreign key
        public Guid UserId { get; set; } // Foreign Key to the Users Table
        public Guid SalonId { get; set; } // Foreign Key to the Salon Table
        public Guid StyleServiceLinkId { get; set; } // Foreign Key to the StylistServiceLink Table
        public Guid SlotId { get; set; } //slot id
    }
}
