using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Infrastructure.Persistance.Repositories
{
     public class BookReviewRepository : RepositoryBase<BookReview>, IBookReviewRepository
     {
          public BookReviewRepository(BEPDbContext context) : base(context)
          {
          }

          public List<BookReview> GetUserBookReviews(int userId)
          {
               var bookReviews = _context.Set<BookReview>().Where(x => x.UserId == userId).Include(x => x.Book).ThenInclude(x => x.Categories);

               return bookReviews.ToList();
          }
     }
}
