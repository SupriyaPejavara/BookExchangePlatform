using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEP.API.Configuration
{
     public static class MiddlewareExtensions
     {
          public static IApplicationBuilder UseRequestTime(this IApplicationBuilder builder)
          {
               return builder.UseMiddleware<RequestTimeMiddleware>();
          }
     }
}
