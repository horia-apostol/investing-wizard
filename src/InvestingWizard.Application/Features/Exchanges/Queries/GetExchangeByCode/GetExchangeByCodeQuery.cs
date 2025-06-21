using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode
{
    public sealed record GetExchangeByCodeQuery(
        string Code) : IRequest<Result<ExchangeResponseDto>>;
}
