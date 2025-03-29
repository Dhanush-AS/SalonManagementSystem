using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SMS.Application.DTOs;
using SMS.Application.IRepos.Contracts;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class StylistRepo : GenricRepo<Stylist>,IStylistRepo
    {
        public StylistRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {
            
        }
        public async Task<IEnumerable<StyistServiceLink>> GetStylistByService(string styleServiceLinkId)
        {
            var query = _container.GetItemLinqQueryable<StyistServiceLink>(true).Where(s => s.StyleServiceLinkId == styleServiceLinkId && !s.IsDeleted).ToFeedIterator();
            var salonEntity = new List<StyistServiceLink>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                salonEntity.AddRange(response);
            }
            return salonEntity;
        }
        public async Task<IEnumerable<Stylist>> GetStylistBySalon(string salonId)
        {
            var query = _container.GetItemLinqQueryable<Stylist>(true).Where(s => s.SalonId == salonId && !s.IsDeleted).ToFeedIterator();
            var salonEntity = new List<Stylist>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                salonEntity.AddRange(response);
            }
            return salonEntity;
        }

        public async Task<Stylist> GetStylistByName(string name)
        {
            var query = _container.GetItemLinqQueryable<Stylist>(true)
                                  .Where(s => s.StylistName == name && !s.IsDeleted)
                                  .ToFeedIterator();

            // Fetch the first batch of results
            if (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                return response.FirstOrDefault(); // Return the first matching stylist
            }

            return null; // Return null if no stylist is found
        }
    }
}
