using AutoMapper;
using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using BookManager.DAL.Entities;
using BookManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Services
{
    public class AuthorService : Service<Author, AuthorModel>, IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IMapper mapper, IRepository<Author> repository) : base(mapper, repository)
        { }
    }
}
