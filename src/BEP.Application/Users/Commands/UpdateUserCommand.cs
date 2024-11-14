using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Users.Commands
{
     public class UpdateUserCommand : IRequest<User>
     {
     }
}
