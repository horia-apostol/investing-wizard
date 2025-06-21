using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.LivePrices.Queries.GetLivePriceByCode
{
    public sealed record GetLivePriceByCodeQuery(
        string Code) : IRequest<Result<LivePriceResponseDto>>;
}
