using Microsoft.Azure.Cosmos;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class CustomerRepo : GenricRepo<Customer>, ICustomerRepo
    {
       public CustomerRepo(CosmosClient cosmosClient,string databaseName,string containerName)
            : base(cosmosClient, databaseName, containerName)
    {
       
    }
        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await QuerySingleOrDefaultAsync(query =>
                query.Where(x => x.CustomerEmail == email && !x.IsDeleted));
        }

       
    }
}