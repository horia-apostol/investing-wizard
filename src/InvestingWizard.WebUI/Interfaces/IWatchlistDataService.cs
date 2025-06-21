using InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Dtos.RequestDtos;

namespace InvestingWizard.WebUI.Interfaces
{
    public interface IWatchlistDataService
    {
        Task<Result<List<WatchlistResponseDto>>> GetWatchlistsByUserIdAsync(string userId);
        Task<Result<WatchlistResponseDto>> GetWatchlistByIdAsync(string watchlistId);
        Task<Result<LivePriceResponseDto>> GetLivePriceByCodeAsync(string companyCode);
        Task<Result<CodesResponseDto>> GetAllCompanyCodesAsync();
        Task<Result<WatchlistResponseDto>> AddWatchlistAsync(AddWatchlistRequestDto request);
        Task<Result> UpdateWatchlistNameAsync(string watchlistId, UpdateWatchlistNameRequestDto request);
        Task<Result> DeleteWatchlistAsync(string watchlistId);
        Task<Result> AddSecurityToWatchlistAsync(string watchlistId, string securityCode);
        Task<Result> RemoveSecurityFromWatchlistAsync(string watchlistId, string securityCode);
    }
}
