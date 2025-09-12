using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.DAL.Interfaces
{
    public interface IRepository <T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Insert(T entity);

        void Update (T entity);

        void Delete (int id);

        void SaveChanges ();

    }
}