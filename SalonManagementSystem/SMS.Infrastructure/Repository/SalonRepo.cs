using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Servicess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class SalonRepo : GenricRepo<Salon>,ISalonRepo
    {
        public SalonRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {

        }
        public async Task<IEnumerable<Salon>> GetSalonByName(String name)
        {
            var query = _container.GetItemLinqQueryable<Salon>(true).Where(s=>s.SalonName == name && !s.IsDeleted).ToFeedIterator();
            var salonEntity = new List<Salon>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                salonEntity.AddRange(response);
            }
            return salonEntity;
        }

        public async Task<IEnumerable<Salon>> GetSalonByNearbyLandmark(String nearbyLandmark)
        {
            var query = _container.GetItemLinqQueryable<Salon>(true).Where(s => s.NearbyLandmark == nearbyLandmark && !s.IsDeleted).ToFeedIterator();
            var salonEntity = new List<Salon>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                salonEntity.AddRange(response);
            }
            return salonEntity;
        }

        public async Task<IEnumerable<Salon>> GetSalonByPincode(String pincode)
        {
            var query = _container.GetItemLinqQueryable<Salon>(true).Where(s => s.Pincode == pincode && !s.IsDeleted).ToFeedIterator();
            var salonEntity = new List<Salon>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                salonEntity.AddRange(response);
            }
            return salonEntity;
        }

        public async Task<Salon> GetSalonByPincodeAndName(String pincode, string name)
        {
            var query = _container.GetItemLinqQueryable<Salon>(true).Where(s => s.Pincode == pincode && s.SalonName == name && !s.IsDeleted).ToFeedIterator();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                var salon = response.FirstOrDefault();
                if (salon != null)
                {
                    return salon; 
                }
            }
            return null;
        }

    }
}
