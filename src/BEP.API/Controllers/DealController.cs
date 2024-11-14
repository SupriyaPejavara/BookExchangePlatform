using AutoMapper;
using BEP.Application.Deals.Commands;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEP.API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class DealController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public DealController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }

          [HttpPatch("{id}")]
          public async Task<IActionResult> UpdateDeal(int id, [FromBody] UpdateDealDto dealDto)
          {
               var command = _mapper.Map<UpdateDealCommand>(dealDto);
               command.Id = id;

               var deal = await _mediator.Send(command);

               var result = _mapper.Map<UpdateDealDto>(deal);
               return Ok(result);
          }
     }
}
