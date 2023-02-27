using AutoMapper;
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
    public class CategoryManager:ICategoryService
    {
        Context _context;


        public CategoryManager(Context context)
        {
            _context = context;
        }

        public List<CategoryDto> GetAll()
        {
            List<CategoryDto> categoryDtos= new List<CategoryDto>();

            var categories = _context.Categories.ToList();
            foreach (var category in categories)
            {

                var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);
                categoryDtos.Add(categoryDto);
            }
            return categoryDtos;
        }
        public CategoryDto GetFirst()
        {
            var category = _context.Categories.First();
            var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
        public CategoryDto GetById(int id)
        {
            var category =_context.Categories.Find(id);
            var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);
            return categoryDto;
        }

        public void Create(CategoryDto categoryDto)
        {
            Category category = ObjectMapper.Mapper.Map<Category>(categoryDto);
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Update(CategoryDto categoryDto)
        {

            Category category = ObjectMapper.Mapper.Map<Category>(categoryDto);
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }


    }
}
