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

namespace BEP.Application.Deals.Commands
{
     public class UpdateDealCommandHandler : IRequestHandler<UpdateDealCommand, Deal>
     {
          private readonly IDealRepository _dealRepository;

          public Task<Deal> Handle(UpdateDealCommand command, CancellationToken cancellationToken)
          {
               var deal = _dealRepository.GetById(command.Id);

               if (deal == null)
               {
                    throw new NotFoundException(nameof(Domain.Models.Request), command.Id);
               }

               deal.DealStatus = command.DealStatus;
               _dealRepository.SaveAll();

               return Task.FromResult(deal);
          }
     }
}
