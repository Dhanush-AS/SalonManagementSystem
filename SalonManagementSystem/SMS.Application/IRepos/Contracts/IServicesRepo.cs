using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Persistance.Contracts
{
    public interface IServicesRepo:IGenricRepo<SalonServices>
    {
        Task<SalonServices> GetServicesByNameAsync(string name);
        Task<IEnumerable<SalonServices>> GetServicesBySalonAsync(string id);
        Task<IEnumerable<SalonServices>> GetServicesByPriceAsync(int price);


    }
}
