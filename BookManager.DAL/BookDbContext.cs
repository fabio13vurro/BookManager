using BookManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.DAL
{
    public class BookDbContext : DbContext
    {
        
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
        }
        */
    }
}
