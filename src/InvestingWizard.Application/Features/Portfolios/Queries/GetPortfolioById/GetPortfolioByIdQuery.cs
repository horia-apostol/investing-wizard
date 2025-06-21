using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById
{
    public sealed record GetPortfolioByIdQuery(
        Guid PortfolioId) : IRequest<Result<PortfolioResponseDto>>;
}
