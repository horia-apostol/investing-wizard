using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.DeletePortfolio
{
    internal class DeletePortfolioCommandHandler(IPortfolioRepository portfolioRepository)
        : IRequestHandler<DeletePortfolioCommand, Result>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;

        public async Task<Result> Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            return await _portfolioRepository.DeleteAsync(request.Id);
        }
    }
}
