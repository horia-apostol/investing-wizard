namespace InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode
{
    public class EarningsHistoryResponseDto
    {
        public DateOnly? ReportDate { get; set; }
        public DateOnly? Date { get; set; }
        public string? BeforeAfterMarket { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal? EpsActual { get; set; }
        public decimal? EpsEstimate { get; set; }
        public decimal? EpsDifference { get; set; }
        public decimal? SurprisePercent { get; set; }
    }
}