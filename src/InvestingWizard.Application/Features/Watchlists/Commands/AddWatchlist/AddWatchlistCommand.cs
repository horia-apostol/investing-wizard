using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.AddWatchlist
{
    public sealed record AddWatchlistCommand(
        Guid UserId, string Name) : IRequest<Result>;
}
