using InvestingWizard.Shared.Common;
using MediatR;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById
{
    public sealed record GetPortfolioEntriesByIdQuery(
        Guid PortfolioId) : IRequest<Result<List<PortfolioEntryResponseDto>>>;
}
