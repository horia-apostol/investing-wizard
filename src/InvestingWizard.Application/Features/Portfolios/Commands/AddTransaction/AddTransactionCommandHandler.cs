using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.AddTransaction
{
    internal sealed class AddTransactionCommandHandler(ITransactionOrchestrationService transactionOrchestrationService)
        : IRequestHandler<AddTransactionCommand, Result>
    {
        private readonly ITransactionOrchestrationService _transactionOrchestrationService = transactionOrchestrationService;
        public async Task<Result> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            return await _transactionOrchestrationService.AddTransactionAsync(
                request.PortfolioId, 
                request.Date, 
                request.SecurityCode, 
                request.Units, 
                request.BrokerIsResident);
        }
    }
}
