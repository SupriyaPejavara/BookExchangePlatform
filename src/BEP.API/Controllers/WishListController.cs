using AutoMapper;
using BEP.Application.WishList.Queries;
using BEP.Domain.Filter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
     public class WishlistController : ControllerBase
     {
          private readonly IMediator _mediator;
          private readonly IMapper _mapper;

          public WishlistController(IMediator mediator, IMapper mapper)
          {
               _mediator = mediator;
               _mapper = mapper;
          }


          [Authorize]
          [HttpGet]
          public async Task<IActionResult> GetUserWishlist([FromQuery] WishlistFilter filter)
          {
               var query = _mapper.Map<GetUserWishlistQuery>(filter);
               var result = await _mediator.Send(query);

               return Ok(result);
          }
     }
}
