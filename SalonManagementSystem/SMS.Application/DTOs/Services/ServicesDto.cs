using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class ServicesDto 
    {
        public string ServiceId { get; set; } // Primary Key
        public string ServiceName { get; set; } // Name of the service
        public string Description { get; set; } // Description of the service
        public int Duration { get; set; } // Duration in minutes
        public decimal Price { get; set; } // Price of the service

        //foerign key 
        public string SalonId { get; set; } // Foreign Key to Salon Table
        public string id;
        public ServicesDto()
        {
            ServiceId = Guid.NewGuid().ToString();
            id = ServiceId;
        }

    }
}
