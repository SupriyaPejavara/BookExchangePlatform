using BEP.Domain.DTOs;
using BEP.Domain.Models;
using BEP.Domain.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Application.Posts.Queries
{
     public class GetPostsQuery : PaginatedQueryBase<PostDto>
     {
          public bool IncludePostedBy { get; set; }
          public bool IncludeBook { get; set; }
          public string Status { get; set; }
          public int? BookId { get; set; }
          public int? PostedById { get; set; }
          public Condition? Condition { get; set; }
          public DateTime TimeAdded { get; set; }

     }
}
