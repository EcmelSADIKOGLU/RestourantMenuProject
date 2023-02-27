using RestourantMenu.Web.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Services.Abstract
{
    public interface IFoodService
    {
        Task<List<FoodDto>> GetAllAsync();
        Task<List<FoodDto>> GetActiveAsync();
        Task<FoodDto> GetByIdAsync(int id);
        Task<FoodDto> GetByCategoryAsync(int categoryId);
        Task CreateAsync(FoodDto foodDto);
        Task UpdateAsync(FoodDto foodDto);
        Task DeleteAsync(int id);

    }
}
