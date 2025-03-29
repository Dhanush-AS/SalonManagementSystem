using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class CustomerUpdateViewDto
    {
        public string CustomerEmail { get; set; } //primary key
        public string CustomerId { get; set; }
        public string Password { get; set; }
        public string CustomerName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pincode { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }

    }
}
