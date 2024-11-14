using BEP.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEP.IdentityServer
{
     public static class IdentityDataSeeder
     {
          public static void SeedAll(UserManager<ApplicationIdentityUser> userManager) {
               SeedUsers(userManager);
          }

          public static void SeedUsers(UserManager<ApplicationIdentityUser> userManager)
          {
               if (userManager.FindByEmailAsync("supriyapejavar@gmail.com").Result == null)
               {
                    ApplicationIdentityUser user = new ApplicationIdentityUser
                    {
                         UserName = "supriyapejavar",
                         Email = "supriyapejavar@gmail.com",
                         IsAdmin = true,
                         Id="1"
                    };

                    IdentityResult result = userManager.CreateAsync(user, "mysecreT1!").Result;

                    if (result.Succeeded)
                    {
                         userManager.AddToRoleAsync(user, "admin").Wait();
                    }
               }

               if (userManager.FindByEmailAsync("spejavara@gmail.com").Result == null)
               {
                    ApplicationIdentityUser user = new ApplicationIdentityUser
                    {
                         UserName = "spejavara",
                         Email = "spejavara@gmail.com",
                    };

                    IdentityResult result = userManager.CreateAsync(user, "mysecreT1!").Result;
               }

               if (userManager.FindByEmailAsync("akshaya9579@gmail.com").Result == null)
               {
                    ApplicationIdentityUser user = new ApplicationIdentityUser
                    {
                         UserName = "akshaya9579",
                         Email = "akshaya9579@gmail.com",
                    };

                    IdentityResult result = userManager.CreateAsync(user, "mysecreT1!").Result;
               }
          }
     }
}
