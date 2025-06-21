using InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistsByUserId
{
    public sealed record GetWatchlistsByUserIdQuery(
        Guid UserId) : IRequest<Result<List<WatchlistResponseDto>>>;
}
