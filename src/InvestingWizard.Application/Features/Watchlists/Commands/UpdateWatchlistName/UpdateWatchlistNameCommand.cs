using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.UpdateWatchlistName
{
    public sealed record UpdateWatchlistNameCommand(
        Guid Id, string Name) : IRequest<Result>;
}
