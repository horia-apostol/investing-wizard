using InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Portfolios.Commands.AddTransaction;
using InvestingWizard.Application.Features.Portfolios.Commands.ApproveSuggestion;
using InvestingWizard.Application.Features.Portfolios.Commands.CloseTransaction;
using InvestingWizard.Application.Features.Portfolios.Commands.CloseTransactionPartially;
using InvestingWizard.Shared.Common;
using InvestingWizard.WebUI.Interfaces;
using InvestingWizard.WebUI.Misc.Const;
using static InvestingWizard.WebUI.Components.Pages.Trade;

namespace InvestingWizard.WebUI.Services
{
    public class TransactionDataService(HttpClient httpClient) : ITransactionDataService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<Result<List<TransactionDetailsDto>>> GetTransactionsByPortfolioIdAsync(string portfolioId)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.GetTransactionsByPortfolioId, portfolioId));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<List<TransactionDetailsDto>>>();
        }

        public async Task<Result<CodesResponseDto>> GetAllCompanyCodesAsync()
        {
            var response = await _httpClient.GetAsync(ApiUrls.AllCompanyCodesUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<CodesResponseDto>>();
        }

        public async Task<Result<LivePriceResponseDto>> GetLivePriceByCodeAsync(string companyCode)
        {
            var response = await _httpClient.GetAsync(string.Format(ApiUrls.LivePricesUrl, companyCode));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<LivePriceResponseDto>>();
        }

        public async Task<Result> AddTransactionAsync(AddTransactionCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.AddTransactionUrl, command);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result>();
        }

        public async Task<Result> CloseTransactionAsync(CloseTransactionCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.CloseTransactionUrl, command);
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response: {responseBody}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result>();
        }


        public async Task<Result> CloseTransactionPartiallyAsync(CloseTransactionPartiallyCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.CloseTransactionPartiallyUrl, command);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result>();
        }

        public async Task<Result> ApproveSuggestionAsync(ApproveSuggestionCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.ApproveSuggestionUrl, command);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result>();
        }

        public async Task<Result<GetSuggestionsResponse>> GetOptimizationSuggestionsAsync(GetSuggestionsRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.GetSuggestionsUrl, request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Result<GetSuggestionsResponse>>();
        }
    }
}
