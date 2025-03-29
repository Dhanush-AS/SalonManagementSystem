using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Persistance.Contracts
{
    public interface ISalonRepo:IGenricRepo<Salon>
    {
        Task<IEnumerable<Salon>> GetSalonByName(string name);
        Task<IEnumerable<Salon>> GetSalonByNearbyLandmark(string nearbyLandmark);
        Task<IEnumerable<Salon>> GetSalonByPincode(string pincode);
        Task<Salon> GetSalonByPincodeAndName(String pincode, string name);
    }
}
