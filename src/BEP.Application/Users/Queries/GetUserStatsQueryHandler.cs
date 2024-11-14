using BEP.Application.Common.Exceptions;
using BEP.Domain.DTOs;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.Users.Queries
{
     public class GetUserStatsQueryHandler : IRequestHandler<GetUserStatsQuery, UserStatsDto>
     {
          private readonly IUserRepository _userRepository;

          public GetUserStatsQueryHandler(IUserRepository userRepository)
          {
               _userRepository = userRepository;
          }

          Task<UserStatsDto> IRequestHandler<GetUserStatsQuery, UserStatsDto>.Handle(GetUserStatsQuery request, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(request.UserId) == null)
               {
                    throw new NotFoundException(nameof(User), request.UserId);
               }

               var stats = _userRepository.GetUserStats(request.UserId);

               return Task.FromResult(stats);
          }
     }
}
