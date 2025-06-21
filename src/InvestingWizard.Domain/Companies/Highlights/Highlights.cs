namespace InvestingWizard.Domain.Companies
{
    public class Highlights
    {
        public long? MarketCapitalization { get; set; }
        public decimal? MarketCapitalizationMln { get; set; }
        public decimal? EBITDA { get; set; }
        public decimal? PERatio { get; set; }
        public decimal? PEGRatio { get; set; }
        public decimal? WallStreetTargetPrice { get; set; }
        public decimal? BookValue { get; set; }
        public decimal? DividendShare { get; set; }
        public decimal? DividendYield { get; set; }
        public decimal? EarningsShare { get; set; }
        public decimal? EPSEstimateCurrentYear { get; set; }
        public decimal? EPSEstimateNextYear { get; set; }
        public decimal? EPSEstimateNextQuarter { get; set; }
        public decimal? EPSEstimateCurrentQuarter { get; set; }
        public DateOnly? MostRecentQuarter { get; set; }
        public decimal? ProfitMargin { get; set; }
        public decimal? OperatingMarginTTM { get; set; }
        public decimal? ReturnOnAssetsTTM { get; set; }
        public decimal? ReturnOnEquityTTM { get; set; }
        public long? RevenueTTM { get; set; }
        public decimal? RevenuePerShareTTM { get; set; }
        public decimal? QuarterlyRevenueGrowthYOY { get; set; }
        public long? GrossProfitTTM { get; set; }
        public decimal? DilutedEpsTTM { get; set; }
        public decimal? QuarterlyEarningsGrowthYOY { get; set; }
    }
}
