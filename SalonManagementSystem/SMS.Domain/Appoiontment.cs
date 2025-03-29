using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class Appoiontment : CommonClass
    {
        public enum AppointmentStatusEnum
        {
            Approved,
            Pending,
            Cancelled
        }

        public enum PaymentStatusEnum
        {
            Confirmed,
            Pending,
            Declined
        }
        public Guid AppointmentId { get; set; } // Primary Key
        public AppointmentStatusEnum Status { get; set; } // Status: Approved, Pending, Declined
        public PaymentStatusEnum PaymentStatus { get; set; } // Payment Status: Confirmed, Pending, Declined
        public int Duration { get; set; } // Duration of the appointment in minutes
        public string CancellationReason { get; set; } // Reason for cancellation, if any
        public string SpecialRequests { get; set; } // Special requests from the customer
        public DateTime? CheckInTime { get; set; } // Timestamp for when the customer checks in
        public DateTime? EstimatedEndTime { get; set; } // Estimated end time of the appointment
        public DateTime AppointmentTime { get; set; } // Appointment time
      
        //foreign key
        public Guid CustomerId { get; set; } // Foreign Key to the Users Table
        public Guid SalonId { get; set; } // Foreign Key to the Salon Table
        public Guid LinkId { get; set; } // Foreign Key to the StylistServiceLink Table
        public Guid SlotId { get; set; } //slot id
        public Guid? PaymentId { get; set; } // Foreign Key to Payment Table
        public Guid StyleListId { get; set; }

        //

    }
}
