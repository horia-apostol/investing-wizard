using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetTransactionsById
{
    public sealed record GetPortfolioTransactionsByIdQuery(
        Guid PortfolioId) : IRequest<Result<List<TransactionResponseDto>>>;
}
