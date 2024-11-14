using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using BEP.Domain.Wrappers;

namespace BEP.Domain.Queries
{
     public class PaginatedQueryBase<TDto> : IRequest<PagedResponse<TDto>>
     {
          public int PageNumber { get; set; }
          public int PageSize { get; set; }
          public string SortDirection { get; set; }
          public string SortBy { get; set; }
          public string FilterLogicalOperator { get; set; }
     }
}
