using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class GenricRepo<T> : IGenricRepo<T> where T : CommonClass
    {
        protected readonly Container _container;

        public GenricRepo(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<T> AddAsync(T item)
        {
            var response = await _container.CreateItemAsync(item);
            return response.Resource;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<T>();
            List<T> result = new List<T>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                result.AddRange(response.Where(x => !x.IsDeleted)); // Only non-deleted items
            }

            return result;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                var result = response.Resource;

                return result.IsDeleted ? null : result; // Return null if the item is soft-deleted
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // Handle not found case
            }
        }

        public async Task UpdateAsync(T item, string id)
        {

            // Perform the update operation
            var response = await _container.ReplaceItemAsync(item, id, new PartitionKey(id));

            // Validate the response
            if (response.StatusCode != System.Net.HttpStatusCode.OK &&
                response.StatusCode != System.Net.HttpStatusCode.Created)
            {
                throw new Exception("Failed to update ");
            }
        }

        public async Task DeleteAsync(string id)
        {
            // Fetch the item by ID (since ID is the same as the partition key)
            var item = await GetByIdAsync(id.ToString());
            if (item == null)
            {
                throw new Exception($"Item with ID {id} not found.");
            }

            // Mark the item as deleted
            item.IsDeleted = true;

            // Update the item in the database
            await UpdateAsync(item, id);
        }
        public async Task<T> QuerySingleOrDefaultAsync(Func<IQueryable<T>, IQueryable<T>> query)
        {
            var queryable = _container.GetItemLinqQueryable<T>(true);
            var filteredQuery = query(queryable).ToFeedIterator();

            while (filteredQuery.HasMoreResults)
            {
                var response = await filteredQuery.ReadNextAsync();
                return response.FirstOrDefault(); // Return the first matching item or null
            }

            return default; // Return null if no results are found
        }
    }
}
