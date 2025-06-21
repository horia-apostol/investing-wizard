using InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesBySecurityCode
{
    public sealed record GetPricesBySecurityCodeQuery(
        string SecurityCode) : IRequest<Result<List<PriceResponseDto>>>;
}
