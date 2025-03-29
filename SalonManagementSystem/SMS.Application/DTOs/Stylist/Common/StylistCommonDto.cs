using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class StylistCommonDto
    {
        public string StylistName { get; set; }
        public int Experience { get; set; } // In years
        public string Specializations { get; set; } // Comma-separated or a collection if needed
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkingHours { get; set; } // e.g., JSON: {"Monday": "9:00-18:00", ...}
        public decimal CommissionRate { get; set; } // Rate in percentage
        public string StylistId { get; set; } // Primary Key

        //foreign key
        public string SalonId { get; set; } // Foreign Key to Salon Table
    }
}
