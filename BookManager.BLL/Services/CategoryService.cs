using AutoMapper;
using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using BookManager.DAL.Entities;
using BookManager.DAL.Interfaces;

namespace BookManager.BLL.Services
{
    public class CategoryService : Service<Category, CategoryModel>, ICategoryService
    {
        public CategoryService(IMapper mapper, IRepository<Category> repository) : base(mapper, repository)
        {

        }
    }
}