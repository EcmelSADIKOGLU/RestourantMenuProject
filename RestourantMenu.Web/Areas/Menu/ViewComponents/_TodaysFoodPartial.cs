using Microsoft.AspNetCore.Mvc;
using RestourantMenu.Web.Services.Abstract;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Areas.Menu.ViewComponents
{
    public class _TodaysFoodPartial:ViewComponent
    {
        private readonly ITodaysFoodService _todaysFoodService;

        public _TodaysFoodPartial(ITodaysFoodService todaysFoodService)
        {
            _todaysFoodService = todaysFoodService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var todaysFood = await _todaysFoodService.GetAsync();
            return View(todaysFood);
        }
    }
}
