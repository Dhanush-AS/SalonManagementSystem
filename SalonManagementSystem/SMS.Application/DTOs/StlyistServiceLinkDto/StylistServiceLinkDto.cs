using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class StylistServiceLinkDto 
    {
        public string StyleServiceLinkId { get; set; } // Primary Key, unique ID for the record
        public string StylistId { get; set; } // Foreign Key to the Stylists Table
        public string ServiceId { get; set; } // Foreign Key to the Services Table
        public string id {  get; set; }

    }
}
