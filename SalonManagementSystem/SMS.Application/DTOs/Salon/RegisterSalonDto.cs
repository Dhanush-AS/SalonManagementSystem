using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class RegisterSalonDto : SalonCommonDto
    {
        public string SalonId {  get; set; }
        public string id { get; set; }
        public RegisterSalonDto()
        {
            SalonId = Guid.NewGuid().ToString();
            id = SalonId.ToString();
        }
    }
}
