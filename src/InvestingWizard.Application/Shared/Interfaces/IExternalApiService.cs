using InvestingWizard.Application.Shared.ExternalDtos.Companies;
using InvestingWizard.Application.Shared.ExternalDtos.Exchanges;
using InvestingWizard.Application.Shared.ExternalDtos.LivePrices;
using InvestingWizard.Application.Shared.ExternalDtos.Prices;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface IExternalApiService
    {
        Task<Result<CompanyExternalDto>> GetCompanyDataAsync(string code);
        Task<Result<ExchangeExternalDto>> GetExchangeDataAsync(string code);
        Task<Result<List<PriceExternalDto>>> GetPriceDataAsync(string code);
        Task<Result<LivePriceExternalDto>> GetLivePriceAsync(string code);
    }
}
