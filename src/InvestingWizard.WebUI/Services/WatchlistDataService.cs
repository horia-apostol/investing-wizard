using InvestingWizard.Application.Features.Companies.Queries.GetAllCompanyCodes;
using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Shared.Dtos.RequestDtos;
using InvestingWizard.WebUI.Interfaces;
using InvestingWizard.WebUI.Misc.Const;
using System.Net.Http;

namespace InvestingWizard.WebUI.Services
{
    public class WatchlistDataService(HttpClient httpClient) : IWatchlistDataService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<Result<WatchlistResponseDto>> GetWatchlistByIdAsync(string watchlistId)
        {
            var response = await _httpClient.GetAsync(ApiUrls.GetWatchlistById(watchlistId));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Result<WatchlistResponseDto>>();
            }
            return Result<WatchlistResponseDto>.Failure(new Error("Error fetching watchlist."));
        }

        public async Task<Result<List<WatchlistResponseDto>>> GetWatchlistsByUserIdAsync(string userId)
        {
            var response = await _httpClient.GetAsync(ApiUrls.GetWatchlistsByUserId(userId));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Result<List<WatchlistResponseDto>>>();
            }
            return Result<List<WatchlistResponseDto>>.Failure(new Error("Error fetching watchlists."));
        }

        public async Task<Result<WatchlistResponseDto>> AddWatchlistAsync(AddWatchlistRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync(ApiUrls.AddWatchlist, request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Result<WatchlistResponseDto>>();
            }
            return Result<WatchlistResponseDto>.Failure(new Error("Error adding watchlist."));
        }

        public async Task<Result> UpdateWatchlistNameAsync(string watchlistId, UpdateWatchlistNameRequestDto request)
        {
            var response = await _httpClient.PutAsJsonAsync(ApiUrls.UpdateWatchlistName(watchlistId), request);
            if (response.IsSuccessStatusCode)
            {
                return Result.Success();
            }
            return Result.Failure(new Error("Error updating watchlist name."));
        }

        public async Task<Result> DeleteWatchlistAsync(string watchlistId)
        {
            var response = await _httpClient.DeleteAsync(ApiUrls.DeleteWatchlist(watchlistId));
            if (response.IsSuccessStatusCode)
            {
                return Result.Success();
            }
            return Result.Failure(new Error("Error deleting watchlist."));
        }

        public async Task<Result<CodesResponseDto>> GetAllCompanyCodesAsync()
        {
            var response = await _httpClient.GetAsync(ApiUrls.GetAllCompanyCodes);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Result<CodesResponseDto>>();
            }
            return Result<CodesResponseDto>.Failure(new Error("Error fetching company codes."));
        }

        public async Task<Result<LivePriceResponseDto>> GetLivePriceByCodeAsync(string companyCode)
        {
            var response = await _httpClient.GetAsync(ApiUrls.GetLivePriceByCode(companyCode));
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Result<LivePriceResponseDto>>();
            }
            return Result<LivePriceResponseDto>.Failure(new Error("Error fetching live price."));
        }

        public async Task<Result> AddSecurityToWatchlistAsync(string watchlistId, string companyCode)
        {
            var response = await _httpClient.PutAsync(ApiUrls.AddSecurityToWatchlist(watchlistId, companyCode), null);
            if (response.IsSuccessStatusCode)
            {
                return Result.Success();
            }
            return CommonErrors.EntityNotFound;
        }

        public async Task<Result> RemoveSecurityFromWatchlistAsync(string watchlistId, string companyCode)
        {
            var response = await _httpClient.PutAsync(ApiUrls.RemoveSecurityFromWatchlist(watchlistId, companyCode), null);
            if (response.IsSuccessStatusCode)
            {
                return Result.Success();
            }
            return CommonErrors.EntityNotFound;
        }
    }
}