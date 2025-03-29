using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.DTOs
{
    public class AddStylistDto: StylistCommonDto
    {
        public string id;
        public AddStylistDto()
        {
            StylistId = Guid.NewGuid().ToString();
            id = StylistId;
        }
    }
}
