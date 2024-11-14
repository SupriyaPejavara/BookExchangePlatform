using BEP.Domain.DTOs;
using BEP.Domain.Models;
using BEP.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Books.Queries
{
     public class SmartSearchBooksQuery : PaginatedQueryBase<BookDto>
     {
          public string SearchTerm { get; set; }
     }
}
