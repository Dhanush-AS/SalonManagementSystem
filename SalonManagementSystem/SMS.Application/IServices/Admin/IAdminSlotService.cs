using SMS.Application.IServices.Common;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.IServices.Admin
{
    public interface IAdminSlotService 
    {
        Task ChangeStatus(string status,string slotId,string stylistId);

    }
}
