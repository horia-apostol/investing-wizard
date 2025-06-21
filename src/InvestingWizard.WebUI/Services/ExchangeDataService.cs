using InvestingWizard.Application.Features.Exchanges.Queries.GetAllExchanges;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeStatusByCode;
using InvestingWizard.Shared.Common;
using InvestingWizard.WebUI.Interfaces;
using InvestingWizard.WebUI.Misc.Const;

namespace InvestingWizard.WebUI.Services
{
    public class ExchangeDataService : IExchangeDataService
    {
        private readonly HttpClient _httpClient;

        public ExchangeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<List<ExchangeNameCodeResponseDto>>> GetAllExchangesAsync()
        {
            var response = await _httpClient.GetAsync($"{ApiUrls.ExchangesGeneralUrl}/all");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Result<List<ExchangeNameCodeResponseDto>>>();
            return result;
        }

        public async Task<Result<ExchangeResponseDto>> GetExchangeByCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"{ApiUrls.ExchangesGeneralUrl}/{code}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Result<ExchangeResponseDto>>();
            return result;
        }

        public async Task<Result<ExchangeStatusDto>> GetExchangeStatusByCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"{ApiUrls.ExchangeStatusUrl}/{code}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<Result<ExchangeStatusDto>>();
            return result;
        }
    }
}
