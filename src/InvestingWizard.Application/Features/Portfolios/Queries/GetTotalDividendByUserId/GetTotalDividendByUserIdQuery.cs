using InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById;
using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetTotalDividendByUserId
{
    public sealed record GetTotalDividendByUserIdQuery(
        Guid UserId) : IRequest<Result<DividendResponseDto>>;
}
