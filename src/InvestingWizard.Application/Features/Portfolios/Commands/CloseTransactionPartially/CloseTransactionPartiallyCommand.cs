using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Commands.CloseTransactionPartially
{
    public sealed record CloseTransactionPartiallyCommand(
        Guid PortfolioId, Guid TransactionId, decimal Quantity) : IRequest<Result>;
}
