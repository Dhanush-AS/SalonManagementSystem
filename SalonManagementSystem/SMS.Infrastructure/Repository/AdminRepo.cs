using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using SMS.Application.DTOs;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class AdminRepo : GenricRepo<Admin>, IAdminRepo
    {
        public AdminRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {
        }

        public async Task<Admin> GetByEmailAsync(string email)
        {
            return await QuerySingleOrDefaultAsync(query =>
                query.Where(x => x.Email == email && !x.IsDeleted)); // Return a single entity or null if none is found

        }

       


    }
}
    