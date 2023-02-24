using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Dtos
{
    public class FoodDto
    {
        public int FoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public CategoryDto Categorydto { get; set; }
        public int CategoryID { get; set; }
    }
}
