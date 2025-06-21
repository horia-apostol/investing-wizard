using InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Shared.Interfaces
{
    public interface ICachedPricesService
    {
        Result<LivePriceResponseDto> GetCachedPriceAsync(string securityCode);
    }
}
