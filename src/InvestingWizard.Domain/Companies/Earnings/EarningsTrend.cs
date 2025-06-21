namespace InvestingWizard.Domain.Companies
{
    public class EarningsTrend
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public string? Period { get; set; }
        public decimal? Growth { get; set; }
        public decimal? EarningsEstimateAvg { get; set; }
        public decimal? EarningsEstimateLow { get; set; }
        public decimal? EarningsEstimateHigh { get; set; }
        public decimal? EarningsEstimateYearAgoEps { get; set; }
        public int? EarningsEstimateNumberOfAnalysts { get; set; }
        public decimal? EarningsEstimateGrowth { get; set; }
        public decimal? RevenueEstimateAvg { get; set; }
        public decimal? RevenueEstimateLow { get; set; }
        public decimal? RevenueEstimateHigh { get; set; }
        public decimal? RevenueEstimateYearAgoEps { get; set; }
        public int? RevenueEstimateNumberOfAnalysts { get; set; }
        public decimal? RevenueEstimateGrowth { get; set; }
        public decimal? EpsTrendCurrent { get; set; }
        public decimal? EpsTrend7daysAgo { get; set; }
        public decimal? EpsTrend30daysAgo { get; set; }
        public decimal? EpsTrend60daysAgo { get; set; }
        public decimal? EpsTrend90daysAgo { get; set; }
        public int? EpsRevisionsUpLast7days { get; set; }
        public int? EpsRevisionsUpLast30days { get; set; }
        public int? EpsRevisionsDownLast7days { get; set; }
        public int? EpsRevisionsDownLast30days { get; set; }
    }
}
