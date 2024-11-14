using BEP.Domain.DTOs;
using BEP.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.WishList.Queries
{
     public class GetWishListAllQuery : PaginatedQueryBase<WishListDto>
     {
          public int? BookId { get; set; }
          public int? UserId { get; set; }
     }
}
