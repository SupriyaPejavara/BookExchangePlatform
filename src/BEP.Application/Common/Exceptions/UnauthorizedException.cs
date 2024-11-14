using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Common.Exceptions
{
     public class UnauthorizedException : ApiException
     {
          public UnauthorizedException(string message) : base(HttpStatusCode.Unauthorized, message)
          {
          }
     }
}
