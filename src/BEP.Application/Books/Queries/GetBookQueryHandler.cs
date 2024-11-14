using BEP.Domain.DTOs;
using BEP.Application.Common.Exceptions;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using BEP.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BEP.Service.Services
{
     public class GetBookQueryHandler : IRequestHandler<GetBookQuery, Book>
     {
          private readonly IBookRepository _bookRepository;

          public GetBookQueryHandler(IBookRepository bookRepository)
          {
               _bookRepository = bookRepository;
          }

          public Task<Book> Handle(GetBookQuery request, CancellationToken cancellationToken)
          {
               Book book;

               if (!request.IncludeDetails) {
                    book = _bookRepository.GetById(request.Id);
               } else {
                    book = _bookRepository.GetByIdWithInclude(request.Id, b => b.Details, b => b.Categories, b=>b.Authors);
               }

               if (book == null)
               {
                    throw new NotFoundException(nameof(Book), request.Id);
               }

               return Task.FromResult(book);
          }
     }
}
