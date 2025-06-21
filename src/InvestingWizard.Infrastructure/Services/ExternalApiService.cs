using System.Text.Json;
using InvestingWizard.Application.Shared.ExternalDtos.Companies;
using InvestingWizard.Application.Shared.ExternalDtos.Exchanges;
using InvestingWizard.Application.Shared.ExternalDtos.LivePrices;
using InvestingWizard.Application.Shared.ExternalDtos.Prices;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace InvestingWizard.Infrastructure.Services
{
    public class ExternalApiService(HttpClient httpClient, IOptions<ExternalApiSettings> settings) : IExternalApiService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ExternalApiSettings _settings = settings.Value;

        public async Task<Result<LivePriceExternalDto>> GetLivePriceAsync(string code)
        {
            var url = BuildUrl($"real-time/{code}", new Dictionary<string, string>
            {
                { "fmt", "json" },
                { "api_token", _settings.ApiToken! }
            });
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<LivePriceExternalDto>(response);
        }

        public async Task<Result<List<PriceExternalDto>>> GetPriceDataAsync(string code)
        {
            var url = BuildUrl($"eod/{code}", new Dictionary<string, string>
            {
                { "fmt", "json" },
                { "api_token", _settings.ApiToken! }
            });
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<List<PriceExternalDto>>(response);
        }

        /*
        public async Task<Result<EtfExternalDto>> GetEtfDataAsync(string code)
        {
            var url = BuildUrl($"fundamentals/{code}", new Dictionary<string, string>
            {
                { "api_token", _settings.ApiToken! }
            });
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<EtfExternalDto>(response);
        }*/

        public async Task<Result<ExchangeExternalDto>> GetExchangeDataAsync(string code)
        {
            var url = BuildUrl($"exchange-details/{code}", new Dictionary<string, string>
            {
                { "fmt", "json" },
                { "api_token", _settings.ApiToken! }
            });
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<ExchangeExternalDto>(response);
        }

        public async Task<Result<CompanyExternalDto>> GetCompanyDataAsync(string code)
        {
            var url = BuildUrl($"fundamentals/{code}", new Dictionary<string, string>
            {
                { "api_token", _settings.ApiToken! }
            });
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<CompanyExternalDto>(response);
        }

        private string BuildUrl(string endpoint, Dictionary<string, string> parameters)
        {
            var url = $"{_settings.BaseUrl}/{endpoint}?{string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}"))}";
            return url;
        }

        private static async Task<Result<T>> HandleResponse<T>(HttpResponseMessage response) where T : class
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<T>(content);
                if (data == null) return CommonErrors.UnexpectedNullValue;
                return data;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var errorMessage = $"Error: {response.StatusCode}, Content: {errorContent}";
                return new CustomError(response.StatusCode.ToString(), errorMessage);
            }
        }
    }
}
