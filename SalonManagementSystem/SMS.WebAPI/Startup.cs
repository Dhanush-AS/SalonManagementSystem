using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SMS.Application.IRepos.Contracts;
using SMS.Application.Persistance.Contracts;
using SMS.Domain;
using SMS.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMS.Application;
using SMS.Application.IServices.Admin;
using SMS.Infrastructure.Service.AdminService;
using static SMS.WebAPI.Configurations.ExceptionHandlingMiddleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SMS.Application.IServices;
using SMS.Infrastructure.Services.Admin;
using SMS.Application.IServices.Customer;
using SMS.Infrastructure.Servicess.Common;
using SMS.Infrastructure.Services.Common;
using SMS.Application.IServices.Common;


namespace SMS.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CosmosClient>((provider) =>
            {
                var endpointUri = Configuration["CosmosDbSettings:EndpointUri"];
                var primaryKey = Configuration["CosmosDbSettings:PrimaryKey"];
                var databaseName = Configuration["CosmosDbSettings:DatabaseName"];

                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = databaseName,
                    ConnectionMode = ConnectionMode.Gateway, // Or another mode depending on your needs
                };

                var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
                return cosmosClient;
            });
            services.AddScoped(typeof(IGenricRepo<>), typeof(GenricRepo<>));

            //Admin
            services.AddScoped<IAdminRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Admin"; 
                return new AdminRepo(cosmosClient, databaseName, containerName);
            });
            //Appointment 
            services.AddScoped<IAppointmentRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Appointment"; 
                return new AppointmentRepo(cosmosClient, databaseName, containerName);
            });
            //Customer
            services.AddScoped<ICustomerRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Customer";
                return new CustomerRepo(cosmosClient, databaseName, containerName);
            });
            //Salon
            services.AddScoped<ISalonRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Salon";
                return new SalonRepo(cosmosClient, databaseName, containerName);
            });
            //Services
            services.AddScoped<IServicesRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Service";
                return new ServicesRepo(cosmosClient, databaseName, containerName);
            });
            //Slot
            services.AddScoped<ISlotRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Slot";
                return new SlotRepo(cosmosClient, databaseName, containerName);
            });
            //StylesList
            services.AddScoped<IStylesListRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "StylesList";
                return new StylesListRepo(cosmosClient, databaseName, containerName);
            });
            //Stylist
            services.AddScoped<IStylistRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "Stylist";
                return new StylistRepo(cosmosClient, databaseName, containerName);
            });
            //StylistServiceLink
            services.AddScoped<IStlyistServiceLinkRepo>(sp =>
            {
                var cosmosClient = sp.GetRequiredService<CosmosClient>();
                string databaseName = Configuration["CosmosDbSettings:DatabaseName"];
                string containerName = "StylistServiceLink";
                return new StylistServiceLinkRepo(cosmosClient, databaseName, containerName);
            });

            // JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
                    };
                });


            //swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Salon API",
                    Description = "API for managing events in the Salon Management System.",
                    TermsOfService = new Uri("https://az.com/Privacy.html"),
                    Contact = new OpenApiContact
                    {
                        Name = "Dhanush",
                        Url = new Uri("https://linkedin.com/in/dhanush-as"),
                    },
                    License = new OpenApiLicense
                    {
                        Name ="AZ",
                        Url = new Uri("https://az.com"),
                    }
                });
            });
            services.AddDistributedMemoryCache();  // This configures the in-memory cache for session storage

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
            });
            services.AddHttpContextAccessor();
            services.ConfigureApplicationServices();
            services.ConfigureInfraServices();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAdminSalonService, AdminSalonService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<IAdminServicesService, AdminServicesService>();
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<IStylistServiceLinkService, StylistServiceLinkService>();
            services.AddScoped<IAdminStylistService, AdminStylistService>();
            services.AddScoped<IStylistService, StylistService>();
            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IAdminSlotService, AdminSlotService>();
            services.AddControllers();

        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseSession(); // Add session middleware
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
