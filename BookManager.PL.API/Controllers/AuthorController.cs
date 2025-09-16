using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using BookManager.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var authors = _authorService.GetAll();
                if (authors == null || !authors.Any())
                {
                    return NotFound("No authors found.");
                }
                else
                {
                    return Ok(authors);
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
                var author = _authorService.GetById(id);
                if (author == null)
                {
                    return NotFound($"Author with ID {id} not found.");
                }
                else
                {
                    return Ok(author);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(AuthorModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Author data is null.");
                }
                _authorService.Add(model);
                _authorService.SaveChanges();
                return Ok("Author added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(AuthorModel author)
        {
            try
            {
                if (author == null)
                {
                    return BadRequest("Author data is null.");
                }
                _authorService.Update(author);
                _authorService.SaveChanges();
                return Ok("Author updated successfully.");
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
                var author = _authorService.GetById(id);
                if (author == null)
                {
                    return NotFound($"Author with ID {id} not found.");
                }
                _authorService.Delete(id);
                _authorService.SaveChanges();
                return Ok("Author deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
