namespace InvestingWizard.Domain.Companies
{
    public class SharesStats
    {
        public long? SharesOutstanding { get; set; }
        public long? SharesFloat { get; set; }
        public decimal? PercentInsiders { get; set; }
        public decimal? PercentInstitutions { get; set; }
        public long? SharesShort { get; set; }
        public long? SharesShortPriorMonth { get; set; }
        public decimal? ShortRatio { get; set; }
        public decimal? ShortPercentOutstanding { get; set; }
        public decimal? ShortPercentFloat { get; set; }
    }
}
