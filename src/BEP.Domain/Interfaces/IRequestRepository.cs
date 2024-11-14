using AutoMapper;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;

namespace BEP.Domain.Interfaces
{
     public interface IRequestRepository : IRepositoryBase<Request>
     {
          public PagedResponse<RequestDto> GetRequestsToUser(int userId, PaginationFilter filter);

          public PagedResponse<RequestDto> GetRequestFromUser(int userId, PaginationFilter filter);
     }
}
