using Newtonsoft.Json;
using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain
{
    public class Admin : CommonClass
    {
        [JsonProperty("AdminId")]
        public string AdminId{get; set;}
        public string AdminName{get; set;}  
        public string Email { get; set; } 
        public string FirstName{get; set;}
        public string LastName { get; set; }
        public string Password{get; set;}
        public string PhoneNumber{get; set;}
        

        //foreign keys
        public string SalonId{get; set;}
        public Admin()
        {
            AdminId = Guid.NewGuid().ToString();
            id = AdminId.ToString();
            
        }
        public string Role { get; } = "Admin";
    }
}
