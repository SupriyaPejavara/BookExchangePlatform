using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Interfaces
{
     public interface IDealRepository : IRepositoryBase<Deal>
     {
          public PagedResponse<DealDto> GetDealsFromUser(int userId, PaginationFilter filter);
          public PagedResponse<DealDto> GetDealsToUser(int userId, PaginationFilter filter);
     }
}
