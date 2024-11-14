using BEP.Domain.Models;
using BEP.Infrastructure.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;     

namespace BEP.Infrastructure.Persistance
{
     public class BEPDbContext : DbContext
     {
          private readonly string _connectionString;
          private DbConnection _connection;

          public DbSet<User> Users { get; set; }
          public DbSet<Post> Posts { get; set; }
          public DbSet<Book> Books { get; set; }
          public DbSet<Wishlist> Wishlist { get; set; }
          public DbSet<Request> Requests { get; set; }
          public DbSet<Bookmark> Bookmarks { get; set; }
          public DbSet<Author> Authors { get; set; }          
          public DbSet<BookReview> BookReviews { get; set; }
          public DbSet<Deal> Deals { get; set; }

          public BEPDbContext(DbContextOptions<BEPDbContext> options)
              : base(options)
          {
          }

          public BEPDbContext(string connectionString)
          {
               _connectionString = connectionString;
          }

          public BEPDbContext(DbConnection connection)
          {
               _connection = connection;
          }

          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          {
               if (!optionsBuilder.IsConfigured)
               {
                    if (_connection != null)
                    {
                         optionsBuilder.UseSqlServer(_connection);
                    } else {
                         optionsBuilder.UseSqlServer(_connectionString);
                    }
               }
          }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.ApplyConfiguration(new UserConfig());
               modelBuilder.ApplyConfiguration(new UserContactConfig());
               modelBuilder.ApplyConfiguration(new PostConfig());
               modelBuilder.ApplyConfiguration(new BookConfig());
               modelBuilder.ApplyConfiguration(new BookDetailsConfig());
               modelBuilder.ApplyConfiguration(new RequestConfig());
               modelBuilder.ApplyConfiguration(new BookAuthorConfig());
               modelBuilder.ApplyConfiguration(new CategoryConfig());
               modelBuilder.ApplyConfiguration(new BookReviewConfig());
               modelBuilder.ApplyConfiguration(new DealConfig());
          }
     }
}
