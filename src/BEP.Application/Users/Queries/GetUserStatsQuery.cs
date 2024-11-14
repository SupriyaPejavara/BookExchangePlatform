using BEP.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Users.Queries
{
     public class GetUserStatsQuery : IRequest<UserStatsDto>
     {
          public int UserId { get; set; }
     }
}
