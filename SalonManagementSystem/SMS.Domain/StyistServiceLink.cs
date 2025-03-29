using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class StyistServiceLink : CommonClass
    {
        public string StyleServiceLinkId { get; set; } // Primary Key, unique ID for the record
        public string StylistId { get; set; } // Foreign Key to the Stylists Table
        public string ServiceId { get; set; } // Foreign Key to the Services Table

    }
}
