using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class IncomeStatementReportExternalDto
    {
        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }
        [JsonPropertyName("quarterly")]
        public Dictionary<string, IncomeStatementExternalDto>? Quarterly { get; set; }
        [JsonPropertyName("yearly")]
        public Dictionary<string, IncomeStatementExternalDto>? Yearly { get; set; }
    }
}