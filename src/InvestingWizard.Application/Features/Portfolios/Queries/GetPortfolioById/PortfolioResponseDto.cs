using InvestingWizard.Domain.Portfolios;

namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioById
{
    public sealed class PortfolioResponseDto
    {
        public string? Name { get; init; }
        public List<Transaction>? Transactions { get; init; }
        public List<PortfolioEntry>? PortfolioEntries { get; init; }
    }
}