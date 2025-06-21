namespace InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode
{
    public class EarningsAnnualResponseDto
    {
        public DateOnly? Date { get; set; }
        public decimal? EpsActual { get; set; }
        public string Label { get; } = "Yearly Total";
    }
}