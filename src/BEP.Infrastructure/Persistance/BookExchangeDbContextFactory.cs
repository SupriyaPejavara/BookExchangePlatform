using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BEP.Infrastructure.Persistance
{
     public class BEPDbContextFactory : IDesignTimeDbContextFactory<BEPDbContext>
     {
          public BEPDbContext CreateDbContext(string[] args)
          {
               var optionsBuilder = new DbContextOptionsBuilder<BEPDbContext>();
               IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                   .AddJsonFile("appsettings.json")
                   .Build();

               optionsBuilder
                    .UseSqlServer(configuration.GetConnectionString("BookExchangaDatabase"));

               return new BEPDbContext(optionsBuilder.Options);
          }
     }
}
