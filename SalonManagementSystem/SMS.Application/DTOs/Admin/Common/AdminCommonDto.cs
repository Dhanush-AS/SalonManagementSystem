using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs.Admin
{
    public class AdminCommonDto
    {
        public string AdminName { get; set; }
        public string Email { get; set; } //primarykey
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; } = "Admin";

        //foreign keys
        public string SalonId { get; set; }

    }
}
