using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestourantMenu.Web.Dtos;
using RestourantMenu.Web.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/_TodaysFood")]
    public class _TodaysFoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly ITodaysFoodService _todayFoodService;

        public _TodaysFoodController(ITodaysFoodService todayFoodService, IFoodService foodService)
        {
            _todayFoodService = todayFoodService;
            _foodService = foodService;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var foodDtos = await _foodService.GetAllAsync();
            List<SelectListItem> foodDtoList = new List<SelectListItem>();
            foreach (var item in foodDtos)
            {
                var foodDto = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.FoodID.ToString()
                };
                foodDtoList.Add(foodDto);
            }
            ViewBag.Foods = foodDtoList;
            var value = await _todayFoodService.GetAsync();
            return View(value);
        }

        [Route("")]
        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(GetTodaysFoodDto getTodaysFoodDto)
        {
            SetTodaysFoodDto setTodaysFoodDto = new()
            {
                FoodId1 = getTodaysFoodDto.Food1.FoodID,
                FoodId2 = getTodaysFoodDto.Food2.FoodID,
                FoodId3 = getTodaysFoodDto.Food3.FoodID

            };

            await _todayFoodService.SetAsync(setTodaysFoodDto);
            return RedirectToAction("Index");
        }
    }
}
