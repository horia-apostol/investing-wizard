using InvestingWizard.Application.Features.Exchanges.Queries.GetAllExchanges;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode;
using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeStatusByCode;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.WebUI.Interfaces
{
    public interface IExchangeDataService
    {
        Task<Result<List<ExchangeNameCodeResponseDto>>> GetAllExchangesAsync();
        Task<Result<ExchangeResponseDto>> GetExchangeByCodeAsync(string code);
        Task<Result<ExchangeStatusDto>> GetExchangeStatusByCodeAsync(string code);
    }

}
