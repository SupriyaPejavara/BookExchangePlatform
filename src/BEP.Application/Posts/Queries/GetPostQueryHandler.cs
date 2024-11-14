﻿using BEP.Application.Common.Exceptions;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.Posts.Queries
{
     class GetPostQueryHandler : IRequestHandler<GetPostQuery, Post>
     {
          private readonly IPostRepository _postRepository;

          public GetPostQueryHandler(IPostRepository postRepository)
          {
               _postRepository = postRepository;
          }

          public Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
          {
               var post = _postRepository.GetById(request.Id);

               if (post == null)
               {
                    throw new NotFoundException(nameof(Post), request.Id);
               }

               return Task.FromResult(post);
          }
     }
}
