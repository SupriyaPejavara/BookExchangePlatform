using BEP.Domain.DTOs;
using BEP.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Request.Queries
{
     public class GetRequestsToUserQuery : PaginatedQueryBase<RequestDto>
     {
          public int UserId { get; set; }
     }
}
