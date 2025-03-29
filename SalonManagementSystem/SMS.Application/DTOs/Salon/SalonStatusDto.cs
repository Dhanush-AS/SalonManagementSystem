using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class SalonStatusDto
    {
        public string SalonId { get; set; }
        public bool CurrentStatus { get; set; } // True = Open, False = Closed

    }
}
