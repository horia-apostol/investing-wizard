using InvestingWizard.Shared.Common;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Domain.Portfolios;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.AddPortfolio
{
    internal sealed class AddPortfolioCommandHandler(IPortfolioRepository portfolioRepository)
        : IRequestHandler<AddPortfolioCommand, Result>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;

        public async Task<Result> Handle(AddPortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = Portfolio.Create(request.UserId, request.Name);
            await _portfolioRepository.AddAsync(portfolio);

            return Result.Success();
        }
    }
}
