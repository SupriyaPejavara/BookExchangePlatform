using AutoMapper;
using BEP.Domain.DTOs;
using BEP.Domain.Filter;
using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using BEP.Domain.Wrappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BEP.Infrastructure.Persistance.Repositories
{
     public class BookRepository : RepositoryBase<Book>, IBookRepository
     {
          public BookRepository(BEPDbContext context) : base(context)
          {

          }

          public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> predicate)
          {
               return GetAllByConditionWithInclude(predicate, b => b.Details, b => b.Categories, b => b.Authors);
          }

          public List<Book> GetBooksWithIds(List<int> idList)
          {
               return _entitites.Include(b => b.Details).Include(b => b.Authors).Include(b => b.Categories)
                              .Where(b => idList.Contains(b.Id)).AsEnumerable().OrderBy(x => idList.IndexOf(x.Id)).ToList();
          }


     }
}
