using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.DeleteWatchlist
{
    public sealed record DeleteWatchlistCommand(
        Guid Id) : IRequest<Result>;
}
