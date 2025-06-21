using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById
{
    public sealed record GetDividendByIdQuery(
        Guid Id) : IRequest<Result<DividendResponseDto>>;
}
