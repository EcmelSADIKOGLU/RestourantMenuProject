using AutoMapper;
using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos;
using DataAccessLayer.Mapping;
using DataAccessLayer.Services;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccessLayer.Managers
{
    public class FoodManager:IFoodService
    {
        Context _context;

        public FoodManager(Context context)
        {
            _context = context;
        }

        public List<FoodDto> GetAll()
        {
            List<FoodDto> foodDtos = new List<FoodDto>();

            var foods = _context.Foods.ToList();
            if (foods.Any())
            {
                foreach (var food in foods)
                {
                    var category = _context.Categories.Find(food.CategoryID);
                    CategoryDto categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);

                    FoodDto foodDto = ObjectMapper.Mapper.Map<FoodDto>(food);
                    foodDto.Categorydto= categoryDto;
                    foodDtos.Add(foodDto);

                }
            }
            return foodDtos;
        }

        public List<FoodDto> GetByCategoryId(int categoryId)
        {
            List<FoodDto> foodDtos = new List<FoodDto>();

            var foods = _context.Foods.Where(x=>x.CategoryID == categoryId).ToList();
            if (foods.Any())
            {
                foreach (var food in foods)
                {
                    var category = _context.Categories.Find(food.CategoryID);
                    CategoryDto categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);

                    FoodDto foodDto = ObjectMapper.Mapper.Map<FoodDto>(food);
                    foodDto.Categorydto = categoryDto;
                    foodDtos.Add(foodDto);
                }
            }

            return foodDtos;
        }

        public FoodDto GetById(int id)
        {
            var food = _context.Foods.Find(id);
            var category = _context.Categories.Find(food.CategoryID);

            CategoryDto categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);
            FoodDto foodDto = ObjectMapper.Mapper.Map<FoodDto>(food);
            foodDto.Categorydto = categoryDto;
            return foodDto;
        }

        public void Create(FoodDto foodDto)
        {
            Food food = ObjectMapper.Mapper.Map<Food>(foodDto);
            _context.Foods.Add(food);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var food = _context.Foods.Find(id);
            _context.Foods.Remove(food);
            _context.SaveChanges();
        }

        public void Update(FoodDto foodDto)
        {
            Food food = ObjectMapper.Mapper.Map<Food>(foodDto);
            _context.Foods.Update(food);
            _context.SaveChanges();
        }

        
    }
}
