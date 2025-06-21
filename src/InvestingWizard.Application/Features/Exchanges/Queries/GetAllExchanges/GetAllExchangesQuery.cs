using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetAllExchanges
{
    public sealed record GetAllExchangesQuery()
        : IRequest<Result<IReadOnlyList<ExchangeNameCodeResponseDto>>>;
}
