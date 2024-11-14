using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BEP.Application.Posts.Commands
{
     public class DeletePostCommand : IRequest<Unit>
     {
          [Required]
          public int Id { get; set; }
     }
}
