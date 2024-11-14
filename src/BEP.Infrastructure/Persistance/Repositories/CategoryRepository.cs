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
     public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
     {
          public CategoryRepository(BEPDbContext context) : base(context)
          {
          }
     }
}
