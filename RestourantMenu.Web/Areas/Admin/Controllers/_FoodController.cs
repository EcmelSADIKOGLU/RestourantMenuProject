using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestourantMenu.Web.Dtos;
using RestourantMenu.Web.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/_Food")]
    public class _FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ICategoryService _categoryService;

        public _FoodController(IFoodService foodService, ICategoryService categoryService)
        {
            _foodService = foodService;
            _categoryService = categoryService;
        }


        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _foodService.GetAllAsync();
            return View(values);
        }

        [Route("")]
        [Route("AddFood")]
        [HttpGet]
        public async Task<IActionResult> AddFood()
        {
            var categories = await _categoryService.GetActiveAsync();
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (var item in categories)
            {
                var category = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CategoryID.ToString()
                };
                categoryList.Add(category);
            }
            ViewBag.Categories = categoryList;

            return View();
        }

        [Route("")]
        [Route("AddFood")]
        [HttpPost]
        public async Task<IActionResult> AddFood(FoodDto foodDto)
        {
            await _foodService.CreateAsync(foodDto);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("DeleteFood/{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            await _foodService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("EditFood/{id}")]
        [HttpGet]
        public async Task< IActionResult> EditFood(int id)
        {
            var categories = await _categoryService.GetActiveAsync();
            List<SelectListItem> categoryList = new List<SelectListItem>();
            foreach (var item in categories)
            {
                var category = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CategoryID.ToString()
                };
                categoryList.Add(category);
            }
            ViewBag.Categories = categoryList;

            var foodDto = await _foodService.GetByIdAsync(id);
            return View(foodDto);
        }

        [Route("")]
        [Route("EditFood/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditFood(FoodDto foodDto)
        {
            await _foodService.UpdateAsync(foodDto);
            return RedirectToAction("Index");
        }
    }
}
