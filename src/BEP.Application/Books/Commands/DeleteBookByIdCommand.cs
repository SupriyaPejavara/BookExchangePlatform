using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Commands
{
     public class DeleteBookByIdCommand : IRequest<Unit>
     {
          public int Id { get; set; }
     }
}
