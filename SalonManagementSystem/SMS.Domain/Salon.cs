using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class Salon : CommonClass
    {
        // Primary Key
        public string SalonId { get; set; }

        // Name of the Salon
        public string SalonName { get; set; }

        public string Address { get; set; }

        public string Pincode { get; set; }

        public string NearbyLandmark { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

        public bool CurrentStatus { get; set; } // True = Open, False = Closed

        public string Holidays { get; set; } // Comma-separated values like "Saturday, Sunday"


        public bool IsAvailable { get; set; }
       
    }
}
