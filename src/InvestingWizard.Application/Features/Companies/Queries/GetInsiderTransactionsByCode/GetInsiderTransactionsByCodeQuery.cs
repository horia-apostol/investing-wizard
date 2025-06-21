using MediatR;
using InvestingWizard.Shared.Common;

namespace InvestingWizard.Application.Features.Companies.Queries.GetInsiderTransactionsByCode
{
    public sealed record GetInsiderTransactionsByCodeQuery(
        string Code) : IRequest<Result<InsiderTransactionsResponseDto>>;
}
