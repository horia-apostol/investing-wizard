namespace InvestingWizard.Application.Features.Companies.Queries.GetEarningsByCode
{
    public class EarningsResponseDto
    {
        public List<EarningsHistoryResponseDto>? EarningsHistories { get; set; }
        public List<EarningsTrendResponseDto>? EarningsTrends { get; set; }
        public List<EarningsAnnualResponseDto>? EarningsAnnuals { get; set; }
    }
}