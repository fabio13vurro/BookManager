using BookManager.DAL.Entities;
using BookManager.DAL.Interfaces;

namespace BookManager.DAL.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookDbContext context) : base(context)
        {
        }
    }
}
