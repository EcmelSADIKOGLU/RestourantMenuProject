using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using RestourantMenu.Web.Adresses;
using RestourantMenu.Web.Dtos;
using RestourantMenu.Web.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Services.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly HttpClient _httpClient;
        private const string categoryUri = "http://localhost:5000/api/Category"; 

        public CategoryManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(categoryUri);
            string responseContent = await response.Content.ReadAsStringAsync();
            var categoryDtos = JsonConvert.DeserializeObject<List<CategoryDto>>(responseContent);

            return categoryDtos;
        }
        public async Task<List<CategoryDto>> GetActiveAsync()
        {
            var response = await _httpClient.GetAsync(categoryUri);
            string responseContent = await response.Content.ReadAsStringAsync();
            var categoryDtos = JsonConvert.DeserializeObject<List<CategoryDto>>(responseContent);

            var aftifCategoryDtos = new List<CategoryDto>();
            foreach (var categoryDto in categoryDtos)
            {
                if (categoryDto.Status)
                {
                    aftifCategoryDtos.Add(categoryDto);
                }
            }

            return aftifCategoryDtos;
        }


        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(categoryUri+"/"+id);
            string responseContent = await response.Content.ReadAsStringAsync();
            var categoryDto = JsonConvert.DeserializeObject<CategoryDto>(responseContent);
            return categoryDto;
        }

        public async Task CreateAsync(CategoryDto categoryDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(categoryUri, content);

        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(categoryUri, content);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{categoryUri}/{id}");
        }

    }
}
