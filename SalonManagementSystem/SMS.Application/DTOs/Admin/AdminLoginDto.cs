using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class AdminLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AdminId { get; set; }
        public string Role { get; } = "Admin";
    }
}
