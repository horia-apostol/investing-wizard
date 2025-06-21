using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Watchlists.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Watchlists.Commands.AddSecurityCode
{
    internal sealed class AddSecurityCodeCommandHandler(IWatchlistRepository watchlistRepository)
        : IRequestHandler<AddSecurityCodeCommand, Result>
    {
        private readonly IWatchlistRepository _watchlistRepository = watchlistRepository;
        public async Task<Result> Handle(AddSecurityCodeCommand request, CancellationToken cancellationToken)
        {
            return await _watchlistRepository.AddSecurityCodeAsync(request.Id, request.SecurityCode);
        }
    }
}
