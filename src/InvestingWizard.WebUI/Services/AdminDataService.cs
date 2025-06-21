using InvestingWizard.WebUI.Interfaces;
using InvestingWizard.WebUI.Misc.Const;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static InvestingWizard.WebUI.Components.Pages.AdminDashboard;

namespace InvestingWizard.WebUI.Services
{
    public class AdminDataService : IAdminDataService
    {
        private readonly HttpClient _httpClient;

        public AdminDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> AddCompany(string companyCode)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrls.CompaniesUrl}/{companyCode}", new { });
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }

        public async Task<ApiResponse> UpdateCompany(string companyCode)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrls.CompaniesUrl}/{companyCode}", new { });
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }

        public async Task<ApiResponse> AddExchange(string exchangeCode)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrls.ExchangesUrl}?code={exchangeCode}", new { });
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }

        public async Task<ApiResponse> UpdateExchange(string exchangeCode)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrls.ExchangesUrl}?code={exchangeCode}", new { });
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }

        public async Task<ApiResponse> AddPrices(string pricesCode)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrls.PricesUrl}/{pricesCode}", new { });
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }
    }
}
