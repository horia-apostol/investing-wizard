using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class CompanyExternalDto
    {
        public GeneralInformationExternalDto? General { get; set; }
        public HighlightsExternalDto? Highlights { get; set; }
        public ValuationExternalDto? Valuation { get; set; }
        public SharesStatsExternalDto? SharesStats { get; set; }
        public TechnicalsExternalDto? Technicals { get; set; }
        public SplitsDividendsExternalDto? SplitsDividends { get; set; }
        public AnalystRatingsExternalDto? AnalystRatings { get; set; }
        public HoldersExternalDto? Holders { get; set; }
        public Dictionary<string, InsiderTransactionExternalDto>? InsiderTransactions { get; set; }
        [JsonPropertyName("ESGScores")]
        public EsgScoresExternalDto? EsgScores { get; set; }
        [JsonPropertyName("outstandingShares")]
        public OutstandingSharesExternalDto? OutstandingShares { get; set; }
        public EarningsExternalDto? Earnings { get; set; }
        public FinancialsExternalDto? Financials { get; set; }
    }
}