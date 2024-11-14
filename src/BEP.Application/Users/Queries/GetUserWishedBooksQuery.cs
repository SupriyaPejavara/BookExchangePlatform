﻿using BEP.Domain.DTOs;
using BEP.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Application.Users.Queries
{
     public class GetUserWishedBooksQuery : PaginatedQueryBase<BookDto>
     {
          public int UserId { get; set; }
     }
}
