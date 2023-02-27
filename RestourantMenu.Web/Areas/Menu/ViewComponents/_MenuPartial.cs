using Microsoft.AspNetCore.Mvc;
using RestourantMenu.Web.Services.Abstract;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Areas.Menu.ViewComponents
{
    public class _MenuPartial:ViewComponent
    {
        private readonly IFoodService _foodService;
        private readonly ICategoryService _categoryService;

        public _MenuPartial(IFoodService foodService, ICategoryService categoryService)
        {
            _foodService = foodService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var foods = await _foodService.GetActiveAsync();
            var categories = await _categoryService.GetActiveAsync();

            ViewBag.Categories = categories;

            return View(foods);
        }
    }
}
