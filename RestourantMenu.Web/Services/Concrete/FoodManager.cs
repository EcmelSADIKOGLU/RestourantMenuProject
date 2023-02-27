
using Newtonsoft.Json;
using RestourantMenu.Web.Dtos;
using RestourantMenu.Web.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Services.Concrete
{
    public class FoodManager:IFoodService
    {
        private readonly HttpClient _httpClient;

        private const string foodUri = "http://localhost:5000/api/Food";

        public FoodManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FoodDto>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(foodUri);
            var responseContent = await response.Content.ReadAsStringAsync();

            var foodDtos = JsonConvert.DeserializeObject<List<FoodDto>>(responseContent);
            return foodDtos;
        }
        public async Task<List<FoodDto>> GetActiveAsync()
        {
            var response = await _httpClient.GetAsync(foodUri);
            var responseContent = await response.Content.ReadAsStringAsync();

            var foodDtos = JsonConvert.DeserializeObject<List<FoodDto>>(responseContent);

            var activeFoodDtos = new List<FoodDto>();

            foreach (var foodDto in foodDtos)
            {
                if (foodDto.Status)
                {
                    activeFoodDtos.Add(foodDto);
                }
            }
            return activeFoodDtos;
        }


        public async Task<FoodDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{foodUri}/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();

            var foodDto = JsonConvert.DeserializeObject<FoodDto>(responseContent);
            return foodDto;
        }
        public async Task<FoodDto> GetByCategoryAsync(int categoryId)
        {
            var response = await _httpClient.GetAsync($"{foodUri}/GetByCategoryId/{categoryId}");
            var responseContent = await response.Content.ReadAsStringAsync();

            var categoriesDtos = JsonConvert.DeserializeObject<FoodDto>(responseContent);
            return categoriesDtos;
        }



        public async Task CreateAsync(FoodDto foodDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(foodDto), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(foodUri,content);
        }

        public async Task UpdateAsync(FoodDto foodDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(foodDto), Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(foodUri, content);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{foodUri}/{id}");
        }

    }
}
