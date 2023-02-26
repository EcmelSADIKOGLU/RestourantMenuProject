using Newtonsoft.Json;
using RestourantMenu.Web.Dtos;
using RestourantMenu.Web.Services.Abstract;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestourantMenu.Web.Services.Concrete
{
    public class TodaysFoodManager:ITodaysFoodService
    {
        private readonly HttpClient _httpClient;
        private const string _todaysFoodUri = "http://localhost:5000/api/TodaysFood";

        public TodaysFoodManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetTodaysFoodDto> GetAsync()
        {
            var response = await _httpClient.GetAsync(_todaysFoodUri);
            var responseContent = await response.Content.ReadAsStringAsync();
            var getTodaysFoodDto = JsonConvert.DeserializeObject<GetTodaysFoodDto>(responseContent);
            return getTodaysFoodDto;
        }

        public async Task SetAsync(SetTodaysFoodDto setTodaysFoodDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(setTodaysFoodDto), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(_todaysFoodUri, content);
        }
    }
}
