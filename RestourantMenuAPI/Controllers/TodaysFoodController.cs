using DataAccessLayer.Dtos;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestourantMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodaysFoodController : ControllerBase
    {
        ITodaysFoodService _todaysFoodService;

        public TodaysFoodController(ITodaysFoodService todaysFoodService)
        {
            _todaysFoodService = todaysFoodService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var values = _todaysFoodService.Get();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult Set(SetTodaysFoodDto setTodaysFoodDto)
        {
            _todaysFoodService.Set(setTodaysFoodDto);
            var values = _todaysFoodService.Get();
            return Ok(values);
        }
    }
}
