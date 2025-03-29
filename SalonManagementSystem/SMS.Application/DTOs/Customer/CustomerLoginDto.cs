using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class CustomerLoginDto
    {
        public string CustomerEmail { get; set; } //primary key
        public string Password { get; set; }
        public string CustomerId {  get; set; }
        public string Role { get; } = "Customer";
    }
}
