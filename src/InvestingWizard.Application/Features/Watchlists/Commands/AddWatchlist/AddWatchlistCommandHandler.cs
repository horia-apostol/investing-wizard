using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Watchlists;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.AddWatchlist
{
    internal sealed class AddWatchlistCommandHandler(IWatchlistRepository watchlistRepository)
        : IRequestHandler<AddWatchlistCommand, Result>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        public async Task<Result> Handle(AddWatchlistCommand request, CancellationToken cancellationToken)
        {
            var watchlist = Watchlist.Create(request.UserId, request.Name);
            return await _watchlistRepository.AddAsync(watchlist);
        }
    }
}
