using AutoMapper;
using BookManager.BLL.Models;
using BookManager.DAL.Entities;

namespace BookManager.PL.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Author, AuthorModel>().ReverseMap();
        }
    }
}
