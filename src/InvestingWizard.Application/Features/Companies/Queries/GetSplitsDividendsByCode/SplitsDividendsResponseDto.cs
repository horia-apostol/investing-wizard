namespace InvestingWizard.Application.Features.Companies.Queries.GetSplitsDividendsByCode
{
    public class SplitsDividendsResponseDto
    {
        public decimal? ForwardAnnualDividendRate { get; set; }
        public decimal? ForwardAnnualDividendYield { get; set; }
        public decimal? PayoutRatio { get; set; }
        public DateOnly? DividendDate { get; set; }
        public DateOnly? ExDividendDate { get; set; }
        public string? LastSplitFactor { get; set; }
        public DateOnly? LastSplitDate { get; set; }
    }
}