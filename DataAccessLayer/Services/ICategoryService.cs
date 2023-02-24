using DataAccessLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        void Create(CategoryDto categoryDto);
        void Update(CategoryDto categoryDto);
        void Delete(int id);
    }
}
