using Microsoft.AspNetCore.Mvc;

namespace RestourantMenu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class _AdminLayoutController : Controller
    {
        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult _NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult _ScriptPartial()
        {
            return PartialView();
        }
    }
}
