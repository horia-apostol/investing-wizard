using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class IncomeStatementExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("filing_date")]
        public string? FilingDate { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }

        [JsonPropertyName("researchDevelopment")]
        public string? ResearchDevelopment { get; set; }

        [JsonPropertyName("incomeBeforeTax")]
        public string? IncomeBeforeTax { get; set; }

        [JsonPropertyName("netIncome")]
        public string? NetIncome { get; set; }

        [JsonPropertyName("sellingGeneralAdministrative")]
        public string? SellingGeneralAdministrative { get; set; }

        [JsonPropertyName("grossProfit")]
        public string? GrossProfit { get; set; }

        [JsonPropertyName("ebit")]
        public string? EBIT { get; set; }

        [JsonPropertyName("ebitda")]
        public string? EBITDA { get; set; }

        [JsonPropertyName("depreciationAndAmortization")]
        public string? DepreciationAndAmortization { get; set; }

        [JsonPropertyName("operatingIncome")]
        public string? OperatingIncome { get; set; }

        [JsonPropertyName("otherOperatingExpenses")]
        public string? OtherOperatingExpenses { get; set; }

        [JsonPropertyName("taxProvision")]
        public string? TaxProvision { get; set; }

        [JsonPropertyName("incomeTaxExpense")]
        public string? IncomeTaxExpense { get; set; }

        [JsonPropertyName("totalRevenue")]
        public string? TotalRevenue { get; set; }

        [JsonPropertyName("totalOperatingExpenses")]
        public string? TotalOperatingExpenses { get; set; }

        [JsonPropertyName("costOfRevenue")]
        public string? CostOfRevenue { get; set; }

        [JsonPropertyName("totalOtherIncomeExpenseNet")]
        public string? TotalOtherIncomeExpenseNet { get; set; }

        [JsonPropertyName("netIncomeFromContinuingOps")]
        public string? NetIncomeFromContinuingOps { get; set; }
    }
}