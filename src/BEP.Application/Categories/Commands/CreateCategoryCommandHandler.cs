﻿using BEP.Application.Common;
using BEP.Application.Common.Exceptions;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Application.Categories.Commands
{
     public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
     {
          private readonly ICategoryRepository _categoriesRepository;

          public CreateCategoryCommandHandler(ICategoryRepository categoriesRepository)
          {
               _categoriesRepository = categoriesRepository;
          }

          public Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
          {
               if (ServiceUtils.CheckBookCategoryExists(_categoriesRepository, request.Label)) {
                    throw new BadRequestException($"Category with label = {request.Label} already exists");
               }

               Category bookCategory = new Category
               {
                    Label = request.Label
               };

               _categoriesRepository.Add(bookCategory);
               _categoriesRepository.SaveAll();

               return Task.FromResult(bookCategory);
          }
     }
}
