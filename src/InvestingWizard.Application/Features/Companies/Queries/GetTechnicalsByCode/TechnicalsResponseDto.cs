namespace InvestingWizard.Application.Features.Companies.Queries.GetTechnicalsByCode
{
    public class TechnicalsResponseDto
    {
        public decimal? Beta { get; set; }
        public decimal? _52WeekHigh { get; set; }
        public decimal? _52WeekLow { get; set; }
        public decimal? _50DayMA { get; set; }
        public decimal? _200DayMA { get; set; }
        public long? SharesShort { get; set; }
        public long? SharesShortPriorMonth { get; set; }
        public decimal? ShortRatio { get; set; }
        public decimal? ShortPercentOutstanding { get; set; }
        public decimal? ShortPercentFloat { get; set; }
        public decimal? ShortPercent { get; set; }
    }
}