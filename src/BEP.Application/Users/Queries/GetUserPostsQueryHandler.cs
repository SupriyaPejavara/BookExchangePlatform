using AutoMapper;
using BEP.Application.Common;
using BEP.Application.Common.Exceptions;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.Users.Queries
{
     public class GetUserPostsQueryHandler : PaginatedRequestHandler<GetUserPostsQuery, PostDto>
     {
          private readonly IUserRepository _userRepository;
          private readonly IPostRepository _postRepository;
          private readonly IMapper _mapper;

          public GetUserPostsQueryHandler(IMapper mapper, IPostRepository postRepository, IUserRepository userRepository)
          {
               _mapper = mapper;
               _postRepository = postRepository;
               _userRepository = userRepository;
          }

          public override Task<PagedResponse<PostDto>> Handle(GetUserPostsQuery request, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(request.UserId) == null)
               {
                    throw new NotFoundException(nameof(User), request.UserId);
               }

               var filter = _mapper.Map<PaginationFilter>(request);

               var result = _postRepository.GetUsersActivePosts(request.UserId, filter);

               return Task.FromResult(result);
          }
     }
}
