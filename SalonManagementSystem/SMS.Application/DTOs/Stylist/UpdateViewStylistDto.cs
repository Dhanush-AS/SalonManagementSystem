using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class UpdateViewStylistDto : StylistCommonDto
    {
        public bool IsAvailable { get; set; } // Availability status
        public string Status { get; set; } // e.g., "Active", "On Leave", "Unavailable"
        public string CurrentStatus { get; set; } // Any additional runtime status

      
    }
}
