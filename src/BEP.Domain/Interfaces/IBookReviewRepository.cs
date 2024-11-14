using BEP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEP.Domain.Interfaces
{
     public interface IBookReviewRepository : IRepositoryBase<BookReview>
     {
          public List<BookReview> GetUserBookReviews(int userId);
     }
}
