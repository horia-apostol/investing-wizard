using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Prices.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesForChartBySecurityCode
{
    internal sealed class GetPricesForChartBySecurityCodeQueryHandler(IPriceRepository priceRepository)
        : IRequestHandler<GetPricesForChartBySecurityCodeQuery, Result<List<ChartPriceResponseDto>>>
    {
        private readonly IPriceRepository _priceRepository = priceRepository;
        public async Task<Result<List<ChartPriceResponseDto>>> Handle(GetPricesForChartBySecurityCodeQuery request, CancellationToken cancellationToken)
        {
            var marketPrices = await _priceRepository.GetBySecurityCodeAsync(request.SecurityCode);

            if (marketPrices.IsFailure) return CommonErrors.NoEntitiesFound;
            if (marketPrices.Value is null) return CommonErrors.NoEntitiesFound;

            var prices = marketPrices.Value.Select(price =>
            {
                if (price.Close == 0)
                {
                    return null;
                }
                decimal adjustmentFactor = price.AdjustedClose / price.Close;

                return new ChartPriceResponseDto
                {

                    Date = new DateTime(price.Date.Year, price.Date.Month, price.Date.Day),
                    Open = (Double)price.Open! * (Double)adjustmentFactor!,
                    High = (Double)price.High! * (Double)adjustmentFactor!,
                    Low = (Double)price.Low! * (Double)adjustmentFactor!,
                    Close = (Double)price.AdjustedClose,
                    Volume = (Double)price.Volume
                };
            }).ToList();

            return prices;
        }
    }
}