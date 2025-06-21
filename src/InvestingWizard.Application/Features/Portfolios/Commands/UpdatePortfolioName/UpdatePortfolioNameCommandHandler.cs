using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using InvestingWizard.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.UpdatePortfolioName
{
    internal sealed class UpdatePortfolioNameCommandHandler(IPortfolioRepository portfolioRepository)
        : IRequestHandler<UpdatePortfolioNameCommand, Result>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;

        public async Task<Result> Handle(UpdatePortfolioNameCommand request, CancellationToken cancellationToken)
        {
            return await _portfolioRepository.UpdatePortfolioNameAsync(request.Id, request.Name);
        }
    }
}
