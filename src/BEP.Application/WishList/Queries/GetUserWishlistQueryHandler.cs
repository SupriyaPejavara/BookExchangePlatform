using AutoMapper;
using BEP.Application.Common.Exceptions;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.WishList.Queries
{
     using Wishlist = BEP.Domain.Models.Wishlist;

     public class GetUserWishlistQueryHandler : IRequestHandler<GetUserWishlistQuery, PagedResponse<WishListDto>>
     {
          private readonly IMapper _mapper;
          private readonly IHttpContextAccessor _contextAccessor;
          private readonly IRepositoryBase<Wishlist> _wishlistRepository;
          private readonly IUserRepository _userRepository;

          public GetUserWishlistQueryHandler(IRepositoryBase<Wishlist> wishlistRepository, IUserRepository userRepository, IMapper mapper, IHttpContextAccessor contextAccessor)
          {
               _wishlistRepository = wishlistRepository;
               _userRepository = userRepository;
               _mapper = mapper;
               _contextAccessor = contextAccessor;
          }


          public Task<PagedResponse<WishListDto>> Handle(GetUserWishlistQuery request, CancellationToken cancellationToken)
          {
               string identityId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

               /*if (identityId == null)
               {
                    throw new UnauthorizedException("");
               }*/

               User user = _userRepository.GetUserByIdentityId(identityId);

               var predicates = new List<Expression<Func<Wishlist, bool>>>() {
                    w => w.UserId == user.Id
               };

               var paginationRequestFilter = _mapper.Map<PaginationFilter>(request);

               var result = _wishlistRepository.GetPagedData<WishListDto>(predicates, null, paginationRequestFilter, _mapper);

               return Task.FromResult(result);
          }
     }
}
