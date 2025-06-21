using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeStatusByCode
{
    public sealed record GetExchangeStatusByCodeQuery(
        string Code) : IRequest<Result<ExchangeStatusDto>>;
}
