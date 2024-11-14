using BEP.Domain.Interfaces;
using BEP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEP.Infrastructure.Persistance.Repositories
{
     public class WishlistRepository : RepositoryBase<Wishlist>, IWishlistRepository
     {
          public WishlistRepository(BEPDbContext context) : base(context)
          {
          }
     }
}
