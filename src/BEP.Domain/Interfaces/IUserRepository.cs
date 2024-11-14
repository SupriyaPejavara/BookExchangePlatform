using AutoMapper;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Interfaces
{
     public interface IUserRepository : IRepositoryBase<User>
     {
          public User GetUserByIdentityId(string id);
          public PagedResponse<BookDto> GetWishedBooks(int id, PaginationFilter filter, IMapper mapper);
          public UserStatsDto GetUserStats(int id);
          public List<User> GetTopUsers(int topN);
     }
}
