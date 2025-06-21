using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class BalanceSheetReportExternalDto
    {
        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }
        [JsonPropertyName("quarterly")]
        public Dictionary<string, BalanceSheetExternalDto>? Quarterly { get; set; }
        [JsonPropertyName("yearly")]
        public Dictionary<string, BalanceSheetExternalDto>? Yearly { get; set; }
    }
}