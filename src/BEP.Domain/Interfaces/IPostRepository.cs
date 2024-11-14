using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Interfaces
{
     public interface IPostRepository : IRepositoryBase<Post>
     {
          public PagedResponse<PostDto> GetUsersActivePosts(int userId, PaginationFilter filter);
     }
}
