﻿using BEP.Domain.DTOs;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.Authors.Commands
{
     public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
     {
          private readonly IRepositoryBase<Author> _authorsRepository;

          public CreateAuthorCommandHandler(IRepositoryBase<Author> authorsRepository)
          {
               _authorsRepository = authorsRepository;
          }

          public Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
          {
               var author = new Author {
                    Name = request.Name
               };
               _authorsRepository.Add(author);
               _authorsRepository.SaveAll();

               return Task.FromResult(author);
          }
     }
}
