namespace InvestingWizard.Domain.Companies
{
    public class Earnings
    {
        public List<EarningsHistory>? EarningsHistories { get; set; }
        public List<EarningsTrend>? EarningsTrends { get; set; }
        public List<EarningsAnnual>? EarningsAnnuals { get; set; }
    }
}
