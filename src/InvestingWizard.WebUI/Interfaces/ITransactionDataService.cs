using InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Portfolios.Commands.AddTransaction;
using InvestingWizard.Application.Features.Portfolios.Commands.ApproveSuggestion;
using InvestingWizard.Application.Features.Portfolios.Commands.CloseTransaction;
using InvestingWizard.Application.Features.Portfolios.Commands.CloseTransactionPartially;
using InvestingWizard.Shared.Common;
using static InvestingWizard.WebUI.Components.Pages.Trade;

namespace InvestingWizard.WebUI.Interfaces
{
    public interface ITransactionDataService
    {
        Task<Result<List<TransactionDetailsDto>>> GetTransactionsByPortfolioIdAsync(string portfolioId);
        Task<Result<CodesResponseDto>> GetAllCompanyCodesAsync();
        Task<Result<LivePriceResponseDto>> GetLivePriceByCodeAsync(string companyCode);
        Task<Result> AddTransactionAsync(AddTransactionCommand command);
        Task<Result> CloseTransactionAsync(CloseTransactionCommand command);
        Task<Result> CloseTransactionPartiallyAsync(CloseTransactionPartiallyCommand command);
        Task<Result> ApproveSuggestionAsync(ApproveSuggestionCommand command);
        Task<Result<GetSuggestionsResponse>> GetOptimizationSuggestionsAsync(GetSuggestionsRequest request);
    }
}
