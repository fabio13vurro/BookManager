using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var books = _bookService.GetAll();
                if (books == null || !books.Any())
                {
                    return NotFound("No books found.");
                }
                else
                {
                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var book = _bookService.GetById(id);
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }
                else
                {
                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(BookModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Book data is null.");
                }
                _bookService.Add(model);
                _bookService.SaveChanges();
                return Ok("Book added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(BookModel book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book data is null.");
                }
                _bookService.Update(book);
                _bookService.SaveChanges();
                return Ok("Book updated successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var book = _bookService.GetById(id);
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }
                _bookService.Delete(id);
                _bookService.SaveChanges();
                return Ok("Book deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
