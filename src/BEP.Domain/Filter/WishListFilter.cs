using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Filter
{
     public class WishlistFilter : PaginationFilter
     {
          public int? UserId { get; set; }
          public int? BookId { get; set; }
     }
}
