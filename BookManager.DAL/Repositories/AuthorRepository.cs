using BookManager.DAL.Entities;
using BookManager.DAL.Interfaces;

namespace BookManager.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookDbContext context) : base(context)
        {
        }
    }
}
