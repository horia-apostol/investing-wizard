using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.CloseTransaction
{
    public sealed record CloseTransactionCommand(
        Guid PortfolioId, Guid TransactionId) : IRequest<Result>;
}
