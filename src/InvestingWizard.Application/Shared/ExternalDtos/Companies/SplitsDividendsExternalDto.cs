namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class SplitsDividendsExternalDto
    {
        public decimal? ForwardAnnualDividendRate { get; set; }
        public decimal? ForwardAnnualDividendYield { get; set; }
        public decimal? PayoutRatio { get; set; }
        public string? DividendDate { get; set; }
        public string? ExDividendDate { get; set; }
        public string? LastSplitFactor { get; set; }
        public string? LastSplitDate { get; set; }
    }
}