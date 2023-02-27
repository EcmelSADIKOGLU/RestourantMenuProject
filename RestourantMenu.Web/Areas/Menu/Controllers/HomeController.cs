using Microsoft.AspNetCore.Mvc;

namespace RestourantMenu.Web.Areas.Menu.Controllers
{
    [Area("Menu")]
    [Route("Menu/Home")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
