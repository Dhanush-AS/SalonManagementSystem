using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class Stylist : CommonClass
    {
        public string StylistId { get; set; } // Primary Key
        public string StylistName { get; set; }
        public int Experience { get; set; } // In years
        public string Specializations { get; set; } // Comma-separated or a collection if needed
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int NoOfBookings { get; set; } // Total bookings count
        public int MonthlyBookings { get; set; } // Current month's bookings count
        public double AverageRating { get; set; } // Rating (e.g., out of 5)
        public string WorkingHours { get; set; } // e.g., JSON: {"Monday": "9:00-18:00", ...}
        public decimal CommissionRate { get; set; } // Rate in percentage
        public decimal TotalCommission { get; set; } // Total earned commission
        public DateTime? LastBookingDate { get; set; } // Nullable, stores the date of the last booking

        //
        public bool IsAvailable { get; set; } // Availability status
        public string Status { get; set; } // e.g., "Active", "On Leave", "Unavailable"
        public string CurrentStatus { get; set; } // Any additional runtime status

        //foreign key
        public string SalonId { get; set; } // Foreign Key to Salon Table

    }
}
