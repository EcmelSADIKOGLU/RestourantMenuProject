using DataAccessLayer.Concrete;
using DataAccessLayer.Dtos;
using DataAccessLayer.Mapping;
using DataAccessLayer.Services;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Managers
{
    public class TodaysFoodManager:ITodaysFoodService
    {
        private readonly Context _context;

        public TodaysFoodManager(Context context)
        {
            _context = context;
        }

        public GetTodaysFoodDto Get()
        {
            var todaysFood = _context.TodaysFoods.FirstOrDefault();
            if (todaysFood == null)
            {
                _context.TodaysFoods.Add(new TodaysFood());
                todaysFood = _context.TodaysFoods.FirstOrDefault();
            }

            var food1 = _context.Foods.Find(todaysFood.FoodId1);
            var food2 = _context.Foods.Find(todaysFood.FoodId2);
            var food3 = _context.Foods.Find(todaysFood.FoodId3);

            GetTodaysFoodDto getTodaysFoodDto = new GetTodaysFoodDto()
            {
                Food1 = ObjectMapper.Mapper.Map<FoodDto>(food1),
                Food2 = ObjectMapper.Mapper.Map<FoodDto>(food2),
                Food3 = ObjectMapper.Mapper.Map<FoodDto>(food3)       
            };

            return getTodaysFoodDto;
        }

        public void Set(SetTodaysFoodDto setTodaysFoodDto)
        {
            TodaysFood todaysFood = ObjectMapper.Mapper.Map<TodaysFood>(setTodaysFoodDto);
            todaysFood.TodaysFoodId = 1;

            _context.TodaysFoods.Update(todaysFood);
            _context.SaveChanges();
        }

    }
}
