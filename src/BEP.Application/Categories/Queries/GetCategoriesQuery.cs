using BEP.Domain.DTOs;
using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Categories.Queries
{
     public class GetCategoriesQuery : IRequest<List<Category>>
     {
     }
}
