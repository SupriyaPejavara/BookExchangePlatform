using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using BEP.Services;
using BEP.Domain.DTOs;
using BEP.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using BEP.Application.Common;
using BEP.Infrastructure.Persistance;

namespace BEP.API
{
     public class Program
     {
          public static void Main(string[] args) {
               var host = CreateHostBuilder(args).Build();
               
               using (var scope = host.Services.CreateScope())
               {
                    var serviceProvider = scope.ServiceProvider;

                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    var context = scope.ServiceProvider.GetService<BEPDbContext>();
                    DataInitializer.SeedDatabase(context, mediator);
               }

               host.Run();
          }


          public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder => {
                         webBuilder.UseStartup<Startup>();
                    })
                    .ConfigureLogging((hostingContext, logging) => {
                         logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                         logging.AddConsole();
                         logging.AddDebug();
                         logging.AddEventSourceLogger();
                    });
     }
}
