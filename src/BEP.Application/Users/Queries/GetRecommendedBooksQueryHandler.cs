using BEP.Application.Common;
using BEP.Application.Common.Exceptions;
using BEP.Application.Common.Interfaces;
using BEP.Domain.DTOs;
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
     public class GetRecommendedBooksQueryHandler : IRequestHandler<GetRecommendedBooksQuery, List<Book>>
     {
          private readonly IUserRepository _userRepository;
          private readonly IRecommendationService _recomendationService;

          public GetRecommendedBooksQueryHandler(IUserRepository userRepository, IRecommendationService recomendationService)
          {
               _userRepository = userRepository;
               _recomendationService = recomendationService;
          }

          public Task<List<Book>> Handle(GetRecommendedBooksQuery request, CancellationToken cancellationToken)
          {
               if (_userRepository.GetById(request.Id) == null)
               {
                    throw new NotFoundException(nameof(User), request.Id);
               }

               var books = _recomendationService.RecommendBooks(request.Id, request.TopN);

               return Task.FromResult(books);
          }
     }
}
