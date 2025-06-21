using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Domain.Interfaces.Repositories;
using InvestingWizard.Shared.Common;
using InvestingWizard.Shared.Common.Errors;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.ApproveSuggestion
{
    internal sealed class ApproveSuggestionCommandHandler(IPortfolioRepository portfolioRepository, ITransactionOrchestrationService transactionOrchestrationService) : IRequestHandler<ApproveSuggestionCommand, Result>
    {
        private readonly IPortfolioRepository _portfolioRepository = portfolioRepository;
        private readonly ITransactionOrchestrationService _transactionOrchestrationService = transactionOrchestrationService;

        public async Task<Result> Handle(ApproveSuggestionCommand request, CancellationToken cancellationToken)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                Result result;

                if (request.IsPartialClose)
                {
                    result = await _portfolioRepository.CloseTransactionPartiallyAsync(request.PortfolioId, request.TransactionId, request.UnitsToSell);
                }
                else
                {
                    result = await _portfolioRepository.RemoveTransactionAsync(request.PortfolioId, request.TransactionId);
                }

                if (!result.IsSuccess)
                {
                    return result;
                }

                result = await _transactionOrchestrationService.AddTransactionAsync(
                    request.PortfolioId,
                    DateOnly.FromDateTime(DateTime.Now),
                    request.SecurityCode,
                    request.UnitsToSell,
                    request.BrokerIsResident
                );

                if (!result.IsSuccess)
                {
                    return result;
                }
                scope.Complete();
                return Result.Success();
            }
            catch (Exception)
            {
                return CommonErrors.UnexpectedError;
            }
        }
    }
}
