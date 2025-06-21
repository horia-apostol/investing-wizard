using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.DeleteWatchlist
{
    internal sealed class DeleteWatchlistCommandHandler(IWatchlistRepository watchlistRepository)
        : IRequestHandler<DeleteWatchlistCommand, Result>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        public async Task<Result> Handle(DeleteWatchlistCommand request, CancellationToken cancellationToken)
        {
            return await _watchlistRepository.DeleteAsync(request.Id);
        }
    }
}
