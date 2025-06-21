namespace InvestingWizard.Application.Features.Portfolios.Queries.GetPortfolioEntriesById
{
    public class PortfolioEntryResponseDto
    {
        public string SecurityCode { get; set; }
        public decimal TotalUnits { get; set; }
        public decimal AverageUnitPrice { get; set; }
        public string CurrencyCode { get; set; }
    }
}