using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestingWizard.Application.Features.Portfolios.Commands.CloseTransactionPartially
{
    internal class CloseTransactionPartiallyCommandHandler(IPortfolioRepository portfolioRepository)
        : IRequestHandler<CloseTransactionPartiallyCommand, Result>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        public async Task<Result> Handle(CloseTransactionPartiallyCommand request, CancellationToken cancellationToken)
        {
            return await _portfolioRepository.CloseTransactionPartiallyAsync(request.PortfolioId, request.TransactionId, request.Quantity);
        }
    }
}
