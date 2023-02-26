using RestourantMenu.Web.Dtos;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Services.Abstract
{
    public interface ITodaysFoodService
    {
        Task<GetTodaysFoodDto> GetAsync();
        Task SetAsync(SetTodaysFoodDto setTodaysFoodDto);
    }
}
