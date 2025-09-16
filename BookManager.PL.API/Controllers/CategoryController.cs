using BookManager.BLL.Interfaces;
using BookManager.BLL.Models;
using BookManager.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.PL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var category = _categoryService.GetAll();
                if (category == null || !category.Any())
                {
                    return NotFound("No categories found.");
                }
                else
                {
                    return Ok(category);
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
                var category = _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }
                else
                {
                    return Ok(category);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add")]
        public IActionResult Add(CategoryModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest("Category data is null.");
                }
                _categoryService.Add(model);
                _categoryService.SaveChanges();
                return Ok("Category added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(CategoryModel category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Category data is null.");
                }
                _categoryService.Update(category);
                _categoryService.SaveChanges();
                return Ok("Category updated successfully.");
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
                var category = _categoryService.GetById(id);
                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }
                _categoryService.Delete(id);
                _categoryService.SaveChanges();
                return Ok("Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
