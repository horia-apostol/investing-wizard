using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.UpdateWatchlistName
{
    internal class UpdateWatchlistNameCommandHandler(IWatchlistRepository watchlistRepository)
        : IRequestHandler<UpdateWatchlistNameCommand, Result>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        public async Task<Result> Handle(UpdateWatchlistNameCommand request, CancellationToken cancellationToken)
        {
            return await _watchlistRepository.UpdateNameAsync(request.Id, request.Name);
        }
    }
}
