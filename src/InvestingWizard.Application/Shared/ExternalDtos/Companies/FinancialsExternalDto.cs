using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class FinancialsExternalDto
    {
        [JsonPropertyName("Balance_Sheet")]
        public BalanceSheetReportExternalDto? BalanceSheet { get; set; }
        [JsonPropertyName("Cash_Flow")]
        public CashFlowReportExternalDto? CashFlow { get; set; }
        [JsonPropertyName("Income_Statement")]
        public IncomeStatementReportExternalDto? IncomeStatement { get; set; }
    }
}