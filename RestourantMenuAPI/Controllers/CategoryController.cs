using DataAccessLayer.Dtos;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestourantMenuAPI.Controllers
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


        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            if (categoryDto != null)
            { 
                _categoryService.Create(categoryDto);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            if (categoryDto != null)
            {
                _categoryService.Update(categoryDto);
                return NoContent();
            }
            return BadRequest();
        }
    }
}
