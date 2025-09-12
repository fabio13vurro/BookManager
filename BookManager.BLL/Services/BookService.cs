using AutoMapper;
using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using BookManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;      
        }

        public IEnumerable<BookModel> GetAll()
        {
            var books = _bookRepository.GetAll();
            var bookModels = _mapper.Map<IEnumerable<BookModel>>(books);
            return bookModels;
        }

    }
}
