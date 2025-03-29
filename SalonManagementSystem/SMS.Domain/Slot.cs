using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class Slot : CommonClass
    {
        public string SlotId { get; set; } // Primary Key, Unique identifier for the slot

        public DateTime SlotStartTime { get; set; } // Start time of the available slot

        public DateTime SlotEndTime { get; set; } // End time of the available slot

        public string SlotStatus { get; set; } // Slot status: Available, Booked

        //foerign key
        public string SalonId { get; set; } // Foreign Key to Salon Table
        public string StylistId { get; set; } // Foreign Key to Stylist Table
    }
}
