using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class BookAppointmentCustomerDto
    {
        //foreign key
        public Guid UserId { get; set; } // Foreign Key to the Users Table
        public Guid SalonId { get; set; } // Foreign Key to the Salon Table
        public Guid StyleServiceLinkId { get; set; } // Foreign Key to the StylistServiceLink Table
        public Guid SlotId { get; set; } //slot id

        //
        public string SpecialRequests { get; set; } // Special requests from the customer

    }
}
