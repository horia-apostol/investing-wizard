using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class EarningsHistoryExternalDto
    {
        [JsonPropertyName("reportDate")]
        public string? ReportDate { get; set; }
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("beforeAfterMarket")]
        public string? BeforeAfterMarket { get; set; }
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }
        [JsonPropertyName("epsActual")]
        public decimal? EpsActual { get; set; }
        [JsonPropertyName("epsEstimate")]
        public decimal? EpsEstimate { get; set; }
        [JsonPropertyName("epsDifference")]
        public decimal? EpsDifference { get; set; }
        [JsonPropertyName("surprisePercent")]
        public decimal? SurprisePercent { get; set; }
    }
}