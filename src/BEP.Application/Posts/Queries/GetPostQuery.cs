﻿using BEP.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Application.Posts.Queries
{
     public class GetPostQuery : IRequest<Post>
     {
          public int Id { get; set; }
     }
}
