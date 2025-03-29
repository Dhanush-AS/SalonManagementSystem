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
    public class StylistServiceLinkRepo : GenricRepo<StyistServiceLink>, IStlyistServiceLinkRepo
    {
        public StylistServiceLinkRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {

        }
    }
}