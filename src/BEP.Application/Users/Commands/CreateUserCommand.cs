using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEP.Application.Users.Commands
{
     public class CreateUserCommand : IRequest<User>
     {
     }
}
