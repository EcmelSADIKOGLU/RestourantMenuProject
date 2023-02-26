using DataAccessLayer.Dtos;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;


namespace RestourantMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var foods = _foodService.GetAll();
            return Ok(foods);
        }

        [HttpGet("/api/Food/GetByCategoryId/{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var foods = _foodService.GetByCategoryId(categoryId);
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var food = _foodService.GetById(id);
            return Ok(food);
        }

        [HttpPost]
        public IActionResult Create(FoodDto foodDto)
        {
            _foodService.Create(foodDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            _foodService.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update(FoodDto foodDto)
        {
            _foodService.Update(foodDto);
            return NoContent();
        }

    }
}
