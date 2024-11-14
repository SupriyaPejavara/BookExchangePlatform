using AutoMapper;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using BEP.Infrastructure.Persistance.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Infrastructure.Persistance.Repositories
{
     public class DealRepository : RepositoryBase<Deal>, IDealRepository
     {
          private readonly IMapper _mapper;
          public DealRepository(BEPDbContext context, IMapper mapper) : base(context)
          {
               _mapper = mapper;
          }

          public PagedResponse<DealDto> GetDealsFromUser(int userId, PaginationFilter filter)
          {
               var query = _entitites.Include(x => x.Post).ThenInclude(x => x.Book)
                                        .Include(x => x.Post).ThenInclude(x => x.PostedBy)
                                        .Include(x => x.BookTaker)
                                        .Where(x => x.Post.PostedById == userId)
                                        .Where(x => x.DealStatus != DealStatus.Canceled);

               var result = query.CreatePaginatedResponse<Deal, DealDto>(null, null, filter, _mapper);

               return result;
          }

          public PagedResponse<DealDto> GetDealsToUser(int userId, PaginationFilter filter)
          {
               var query = _entitites.Include(x => x.Post).ThenInclude(x => x.Book)
                                        .Include(x => x.Post).ThenInclude(x => x.PostedBy)
                                        .Include(x => x.BookTaker)
                                        .Where(x => x.BookTakerId == userId)
                                        .Where(x => x.DealStatus == DealStatus.InDelivery);

               var result = query.CreatePaginatedResponse<Deal, DealDto>(null, null, filter, _mapper);

               return result;
          }
     }
}
