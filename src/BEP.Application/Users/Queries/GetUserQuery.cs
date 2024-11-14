using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Application.Users.Queries
{
     public class GetUserQuery : IRequest<User>
     {
          public int Id { get; set; }
     }
}
