using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Prices.Queries.GetPricesFromExternalApi
{
    public sealed record GetPricesFromExternalApiQuery(
        string Code) : IRequest<Result<List<PriceResponseDto>>>;
}
