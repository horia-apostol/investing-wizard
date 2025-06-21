using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Portfolios.Commands.AddPortfolio;
using InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById;
using InvestingWizard.Application.Features.Portfolios.Queries.GetPortfoliosByUserId;
using InvestingWizard.Application.Features.Portfolios.Queries.GetProfitLoss;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Dtos.RequestDtos;
using static InvestingWizard.WebUI.Components.Pages.Portfolio;

namespace InvestingWizard.WebUI.Interfaces
{
    public interface IPortfolioDataService
    {
        Task<Result<List<PortfolioIdResponseDto>>> GetPortfoliosByUserIdAsync(string userId);
        Task<Result<Application.Features.Portfolios.Queries.GetDividendById.DividendResponseDto>> GetTotalDividendByUserIdAsync(string userId);
        Task<Result<List<PortfolioEntryModel>>> GetPortfolioEntriesByIdAsync(string portfolioId, string userId);
        Task<Result<ProfitLossResultResponseDto>> GetProfitLossByCodeAsync(string portfolioId, string securityCode);
        Task<Result<LivePriceResponseDto>> GetLivePriceByCodeAsync(string securityCode);
        Task<Result<Application.Features.Portfolios.Queries.GetDividendById.DividendResponseDto>> GetDividendByPortfolioIdAsync(string portfolioId, string userId);
        Task<Result<PortfolioIdResponseDto>> AddPortfolioAsync(AddPortfolioCommand command);
        Task<Result> UpdatePortfolioNameAsync(string portfolioId, UpdatePortfolioNameRequestDto updateRequest);
        Task<Result> DeletePortfolioAsync(string portfolioId);
    }
}
