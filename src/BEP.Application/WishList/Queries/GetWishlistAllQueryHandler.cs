using AutoMapper;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Interfaces;
using BEP.Domain.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BEP.Application.WishList.Queries
{
     using Wishlist = BEP.Domain.Models.Wishlist;


     // TODO: make paginated requesthandlerbase
     public class GetWishListAllQueryHandler : IRequestHandler<GetWishListAllQuery, PagedResponse<WishListDto>>
     {

          private readonly IRepositoryBase<Wishlist> wishlistRepository;
          private readonly IMapper _mapper;
          Task<PagedResponse<WishListDto>> IRequestHandler<GetWishListAllQuery, PagedResponse<WishListDto>>.Handle(GetWishListAllQuery request, CancellationToken cancellationToken)
          {
               var predicates = new List<Expression<Func<Wishlist, bool>>>();

               if (request.UserId != null) 
               {
                    predicates.Add(w => w.UserId == request.UserId);
               }

               if (request.BookId != null)
               {
                    predicates.Add(w => w.BookId == request.BookId);
               }

               var paginationRequestFilter = _mapper.Map<PaginationFilter>(request);

               var result = wishlistRepository.GetPagedData<WishListDto>(predicates, null, paginationRequestFilter, _mapper);

               return Task.FromResult(result);
          }
     }
}
