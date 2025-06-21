using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class CashFlowReportExternalDto
    {
        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }
        [JsonPropertyName("quarterly")]
        public Dictionary<string, CashFlowExternalDto>? Quarterly { get; set; }
        [JsonPropertyName("yearly")]
        public Dictionary<string, CashFlowExternalDto>? Yearly { get; set; }
    }
}