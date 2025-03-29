using Newtonsoft.Json;
using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class Customer : CommonClass
    {
       
        public string CustomerEmail { get; set; } 

        [JsonProperty("CustomerId")]
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
        public string Role { get; } = "Customer";
        public Customer() { 
         CustomerId = Guid.NewGuid().ToString();
         id = CustomerId.ToString();
        }

    }
}
