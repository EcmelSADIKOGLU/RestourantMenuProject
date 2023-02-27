
using DataAccessLayer.Dtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IFoodService
    {
        List<FoodDto> GetAll();
        List<FoodDto> GetByCategoryId(int categoryId);
        FoodDto GetFirst();
        FoodDto GetById(int id);
        void Create(FoodDto food);
        void Update(FoodDto food);
        void Delete(int id);


    }
}
