using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.RemoveSecurityCode
{
    internal sealed class RemoveSecurityCodeCommandHandler(IWatchlistRepository watchlistRepository)
        : IRequestHandler<RemoveSecurityCodeCommand, Result>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        public async Task<Result> Handle(RemoveSecurityCodeCommand request, CancellationToken cancellationToken)
        {
            return await _watchlistRepository.RemoveSecurityCodeAsync(request.Id, request.SecurityCode);
        }
    }
}
