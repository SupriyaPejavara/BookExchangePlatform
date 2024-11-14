using BEP.Domain.DTOs;
using BEP.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.WishList.Queries
{
     public class GetUserWishlistQuery : PaginatedQueryBase<WishListDto>
     {
     }
}
