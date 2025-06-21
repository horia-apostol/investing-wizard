using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Portfolios.Commands.AddPortfolio;
using InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfoliosByUserId;
using InvestingWizard.Application.Features.Portfolios.Queries.GetProfitLoss;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Dtos.RequestDtos;
using InvestingWizard.WebUI.Interfaces;
using InvestingWizard.WebUI.Misc.Const;
using static InvestingWizard.WebUI.Components.Pages.Portfolio;

namespace InvestingWizard.WebUI.Services
{
    public class PortfolioDataService : IPortfolioDataService
    {
        private readonly HttpClient _httpClient;

        public PortfolioDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<List<PortfolioIdResponseDto>>> GetPortfoliosByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.GetPortfoliosByUserId, userId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<List<PortfolioIdResponseDto>>>();
        }

        public async Task<Result<Application.Features.Portfolios.Queries.GetDividendById.DividendResponseDto>> GetTotalDividendByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.TotalDividendUrl, userId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<Application.Features.Portfolios.Queries.GetDividendById.DividendResponseDto>>();
        }

        public async Task<Result<List<PortfolioEntryModel>>> GetPortfolioEntriesByIdAsync(string portfolioId, string userId)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.PortfolioEntriesUrl, portfolioId, userId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<List<PortfolioEntryModel>>>();
        }

        public async Task<Result<ProfitLossResultResponseDto>> GetProfitLossByCodeAsync(string portfolioId, string securityCode)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.ProfitLossUrl, portfolioId, securityCode));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<ProfitLossResultResponseDto>>();
        }

        public async Task<Result<LivePriceResponseDto>> GetLivePriceByCodeAsync(string securityCode)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.LivePricesUrl, securityCode));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<LivePriceResponseDto>>();
        }

        public async Task<Result<Application.Features.Portfolios.Queries.GetDividendById.DividendResponseDto>> GetDividendByPortfolioIdAsync(string portfolioId, string userId)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.DividendUrl, portfolioId, userId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<Application.Features.Portfolios.Queries.GetDividendById.DividendResponseDto>>();
        }

        public async Task<Result<PortfolioIdResponseDto>> AddPortfolioAsync(AddPortfolioCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.AddPortfolio, command);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<PortfolioIdResponseDto>>();
        }

        public async Task<Result> UpdatePortfolioNameAsync(string portfolioId, UpdatePortfolioNameRequestDto updateRequest)
        {
            var response = await _httpClient.PutAsJsonAsync(string.Format(ApiUrls.UpdatePortfolioName, portfolioId), updateRequest);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result>();
        }

        public async Task<Result> DeletePortfolioAsync(string portfolioId)
        {
            var response = await _httpClient.DeleteAsync(string.Format(ApiUrls.DeletePortfolio, portfolioId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result>();
        }
    }

}
