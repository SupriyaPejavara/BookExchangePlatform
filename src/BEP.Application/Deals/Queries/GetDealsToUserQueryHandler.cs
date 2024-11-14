using AutoMapper;
using BEP.Application.Common;
using BEP.Application.Common.Exceptions;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.Deals.Queries
{
     public class GetDealsToUserQueryHandler : PaginatedRequestHandler<GetDealsToUserQuery, DealDto>
     {
          private readonly IUserRepository _userRepository;
          private readonly IDealRepository _dealsRepository;
          private readonly IMapper _mapper;

          public GetDealsToUserQueryHandler(IDealRepository dealsRepository, IMapper mapper, IUserRepository userRepository)
          {
               _dealsRepository = dealsRepository;
               _mapper = mapper;
               _userRepository = userRepository;
          }
          public override Task<PagedResponse<DealDto>> Handle(GetDealsToUserQuery request, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(request.UserId) == null)
               {
                    throw new NotFoundException(nameof(User), request.UserId);
               }

               var filter = _mapper.Map<PaginationFilter>(request);

               var result = _dealsRepository.GetDealsToUser(request.UserId, filter);

               return Task.FromResult(result);
          }
     }
}
