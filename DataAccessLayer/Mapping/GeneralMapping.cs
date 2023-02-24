using AutoMapper;
using DataAccessLayer.Dtos;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<TodaysFood,SetTodaysFoodDto>().ReverseMap();
        }
    }
}
