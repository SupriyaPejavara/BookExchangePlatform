using BEP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BEP.Domain.Interfaces
{
     public interface IBookRepository : IRepositoryBase<Book>
     {
          public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> predicate);
          public List<Book> GetBooksWithIds(List<int> idList);
     }
}