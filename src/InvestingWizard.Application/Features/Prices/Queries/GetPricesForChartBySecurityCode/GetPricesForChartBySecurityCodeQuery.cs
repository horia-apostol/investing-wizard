using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesForChartBySecurityCode
{
    public sealed record GetPricesForChartBySecurityCodeQuery(
        string SecurityCode) : IRequest<Result<List<ChartPriceResponseDto>>>;
}
