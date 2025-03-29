using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class ServicesRepo : GenricRepo<SMS.Domain.SalonServices>, IServicesRepo
    {
        public ServicesRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {

        }
        public async Task<SalonServices> GetServicesByNameAsync(string name)
        {
            var query = _container.GetItemLinqQueryable<SalonServices>(true)
                                  .Where(s => s.ServiceName == name && !s.IsDeleted)
                                  .ToFeedIterator();

            // Fetch the first batch of results
            if (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                return response.FirstOrDefault(); // Return the first matching stylist
            }

            return null; // Return null if no stylist is found
        }
        public async Task<IEnumerable<SalonServices>> GetServicesByPriceAsync(int price)
        {
            var query = _container.GetItemLinqQueryable<SalonServices>(true).Where(s => s.Price == price && !s.IsDeleted).ToFeedIterator();
            var servicesEntity = new List<SalonServices>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                servicesEntity.AddRange(response);
            }
            return servicesEntity;
        }
        public async Task<IEnumerable<SalonServices>> GetServicesBySalonAsync(string id)
        {
            var query = _container.GetItemLinqQueryable<SalonServices>(true).Where(s => s.SalonId == id && !s.IsDeleted).ToFeedIterator();
            var servicesEntity = new List<SalonServices>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                servicesEntity.AddRange(response);
            }
            return servicesEntity;
        }
    }
}
