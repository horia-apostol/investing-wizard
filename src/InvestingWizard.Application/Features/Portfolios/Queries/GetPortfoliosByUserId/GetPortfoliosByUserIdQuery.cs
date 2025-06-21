using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfoliosByUserId
{
    public sealed record GetPortfoliosByUserIdQuery(
        Guid UserId) : IRequest<Result<List<PortfolioIdResponseDto>>>;
}
