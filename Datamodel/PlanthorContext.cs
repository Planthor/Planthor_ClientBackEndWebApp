using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Planthor_ClientBackEndWebApp.Datamodel
{
    public class PlanthorContext : DbContext
    {

        
        private readonly string _connectionString;


        
        public PlanthorContext(DbContextOptions<PlanthorContext> options)
        : base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {

        //     IConfigurationRoot configuration = new ConfigurationBuilder()
        //     .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //     .AddJsonFile("appsettings.json")
        //     .Build();

        //     options.UseNpgsql(configuration.GetConnectionString("MainPlanthorPostgresql"));
        // }
    }
}