using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Queries.GetWatchlistById
{
    public sealed record GetWatchlistByIdQuery(
        Guid Id) : IRequest<Result<WatchlistResponseDto>>;
}
