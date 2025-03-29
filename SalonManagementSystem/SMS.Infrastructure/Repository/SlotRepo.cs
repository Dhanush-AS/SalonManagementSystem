using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SMS.Domain.Slot;

namespace SMS.Infrastructure.Repository
{
    public class SlotRepo : GenricRepo<Slot>,ISlotRepo
    {
        public SlotRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {
            
        }

        public async Task<IEnumerable<Slot>> GetSlotBySalonId(string id, string stylistId)
        {
            var query = _container.GetItemLinqQueryable<Slot>(true).Where(s => s.SalonId == id && s.StylistId == stylistId && !s.IsDeleted).ToFeedIterator();
            var slotEntity = new List<Slot>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                slotEntity.AddRange((IEnumerable<Slot>)response);
            }
            return slotEntity;
        }

        public async Task<IEnumerable<Slot>> GetSlotByStatus(string status,string salonId, string stylistID)
        {
            var query = _container.GetItemLinqQueryable<Slot>(true).Where(s => s.SlotStatus == status && s.SalonId == salonId && s.StylistId == stylistID && !s.IsDeleted ).ToFeedIterator();
            var slotEntity = new List<Slot>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                slotEntity.AddRange(response);
            }
            return slotEntity;
        }

        public async Task<IEnumerable<Slot>> GetSlotByTime(DateTime time)
        {
            var query = _container.GetItemLinqQueryable<Slot>(true).Where(s => s.SlotStartTime == time && !s.IsDeleted).ToFeedIterator();
            var slotEntity = new List<Slot>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                slotEntity.AddRange(response);
            }
            return slotEntity;
        }

        public async Task UpdateSlot(Slot slot, string slotId)
        {
            try
            {
                // Query the existing slot from the Cosmos DB container
                var query = _container.GetItemLinqQueryable<Slot>(allowSynchronousQueryExecution: true)
                                      .Where(s => s.SlotId == slotId && s.SalonId == slot.SalonId)
                                      .AsEnumerable()
                                      .FirstOrDefault();

                if (query != null)
                {
                    // Update the SlotStatus for the existing slot
                    query.SlotStatus = slot.SlotStatus;

                    // Replace the existing document in Cosmos DB
                    await _container.ReplaceItemAsync(query, query.id, new PartitionKey(query.SalonId));
                }
                else
                {
                    throw new Exception($"Slot with ID {slotId} not found for Salon ID {slot.SalonId}.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors
                throw new Exception("Error updating slot in Cosmos DB", ex);
            }
        }

    }
}
