using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.CloseTransaction
{
    internal sealed class CloseTransactionCommandHandler(IPortfolioRepository portfolioRepository)
        : IRequestHandler<CloseTransactionCommand, Result>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        public async Task<Result> Handle(CloseTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _portfolioRepository.RemoveTransactionAsync(request.PortfolioId, request.TransactionId);
        }
    }
}
