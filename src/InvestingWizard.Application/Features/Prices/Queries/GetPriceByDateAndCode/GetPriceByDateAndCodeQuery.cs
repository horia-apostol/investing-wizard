using InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPriceByDateAndCode
{
    public sealed record GetPriceByDateAndCodeQuery(
        DateOnly DateOnly, string Code) : IRequest<Result<PriceResponseDto>>;
}
