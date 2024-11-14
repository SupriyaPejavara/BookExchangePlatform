using BEP.Domain.DTOs;
using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Queries
{
     public class GetBookQuery : IRequest<Book> {
          public int Id { get; set; }
          public bool IncludeDetails { get; set; }

     }
}
