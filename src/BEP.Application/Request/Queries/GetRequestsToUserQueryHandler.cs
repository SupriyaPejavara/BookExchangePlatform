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

namespace BEP.Application.Request.Queries
{
     public class GetRequestsToUserQueryHandler : PaginatedRequestHandler<GetRequestsToUserQuery, RequestDto>
     {
          private readonly IUserRepository _userRepository;
          private readonly IRequestRepository _requestRepository;
          private readonly IMapper _mapper;

          public GetRequestsToUserQueryHandler(IUserRepository userRepository, IMapper mapper, IRequestRepository requestRepository)
          {
               _userRepository = userRepository;
               _mapper = mapper;
               _requestRepository = requestRepository;
          }

          public override Task<PagedResponse<RequestDto>> Handle(GetRequestsToUserQuery query, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(query.UserId) == null)
               {
                    throw new NotFoundException(nameof(User), query.UserId);
               }

               var filter = _mapper.Map<PaginationFilter>(query);
               var result = _requestRepository.GetRequestsToUser(query.UserId, filter);
               return Task.FromResult(result);
          }
     }
}
