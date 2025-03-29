using Microsoft.Azure.Cosmos;
using SMS.Application.IRepos.Contracts;
using SMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class StylesListRepo : GenricRepo<StylesList>,IStylesListRepo
    {
        public StylesListRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {
            
        }
    }
}
