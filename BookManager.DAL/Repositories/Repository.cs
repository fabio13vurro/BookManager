using BookManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookManager.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        private readonly BookDbContext _context;
        public Repository(BookDbContext context) {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public T GetById(int id) {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll() {
            return _dbSet.ToList();
        }

        public void Add(T entity) {
            _dbSet.Add(entity);
        }

        public void Update(T entity) {
            _dbSet.Update(entity);
        }

        public void Delete(int id) { 
            var entity = _dbSet.Find(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}