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
    public class AppointmentRepo : GenricRepo<Appoiontment>,IAppointmentRepo 
    {
        public AppointmentRepo(CosmosClient cosmosClient, string databaseName, string containerName)
            : base(cosmosClient, databaseName, containerName)
        {
        }
    }
}
