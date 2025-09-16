using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Interfaces
{
    public interface IService<Model> where Model : class
    {
        
        void Add(Model entity);
        void Update(Model entity);
        void Delete(int id);
        IEnumerable<Model> GetAll();
        Model GetById(int id);
        void SaveChanges();
    }
}