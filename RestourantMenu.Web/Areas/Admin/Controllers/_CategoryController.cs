using Microsoft.AspNetCore.Mvc;
using RestourantMenu.Web.Dtos;
using RestourantMenu.Web.Services.Abstract;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/_Category")]
    public class _CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public _CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetAllAsync();
            return View(values);
        }

        [Route("")]
        [Route("AddCategory")]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [Route("")]
        [Route("AddCategory")]
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto categoryDto)
        {
            await _categoryService.CreateAsync(categoryDto);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("DeleteCategory/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Route("")]
        [Route("EditCategory/{id}")]
        [HttpGet]
        public async Task<ActionResult> EditCategory(int id)
        {
            var categoryDto = await _categoryService.GetByIdAsync(id);
            return View(categoryDto);
        }

        [Route("")]
        [Route("EditCategory/{id}")]
        [HttpPost]
        public async Task< ActionResult> EditCategory(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(categoryDto);
            return RedirectToAction("Index");
        }
    }
}
