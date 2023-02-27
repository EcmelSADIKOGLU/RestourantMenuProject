using Microsoft.AspNetCore.Mvc;

namespace RestourantMenu.Web.Areas.Menu.Controllers
{
    public class _MenuLayoutController : Controller
    {
        public IActionResult _HeadPartial()
        {
            return View();
        }
        public IActionResult _NavbarPartial()
        {
            return View();
        }

        public IActionResult _BannerPartial()
        {
            return View();
        }

        public IActionResult _AboutPartial()
        {
            return View();
        }

        public IActionResult _PhotoPartial()
        {
            return View();
        }

        public IActionResult _FooterPartial()
        {
            return View();
        }

        public IActionResult _ScriptPartial()
        {
            return View();
        }
    }
}
