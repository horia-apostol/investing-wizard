using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class CashFlowExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("filing_date")]
        public string? FilingDate { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }

        [JsonPropertyName("investments")]
        public string? Investments { get; set; }

        [JsonPropertyName("totalCashFromFinancingActivities")]
        public string? TotalCashFromFinancingActivities { get; set; }

        [JsonPropertyName("netIncome")]
        public string? NetIncome { get; set; }

        [JsonPropertyName("changeInCash")]
        public string? ChangeInCash { get; set; }

        [JsonPropertyName("depreciation")]
        public string? Depreciation { get; set; }

        [JsonPropertyName("DividendsPaCode")]
        public string? DividendsPaCode { get; set; }

        [JsonPropertyName("changeToInventory")]
        public string? ChangeToInventory { get; set; }

        [JsonPropertyName("changeToAccountReceivables")]
        public string? ChangeToAccountReceivables { get; set; }

        [JsonPropertyName("salePurchaseOfStock")]
        public string? SalePurchaseOfStock { get; set; }

        [JsonPropertyName("otherCashflowsFromFinancingActivities")]
        public string? OtherCashflowsFromFinancingActivities { get; set; }

        [JsonPropertyName("capitalExpenditures")]
        public string? CapitalExpenditures { get; set; }

        [JsonPropertyName("totalCashFromOperatingActivities")]
        public string? TotalCashFromOperatingActivities { get; set; }

        [JsonPropertyName("changeReceivables")]
        public string? ChangeReceivables { get; set; }

        [JsonPropertyName("changeInWorkingCapital")]
        public string? ChangeInWorkingCapital { get; set; }

        [JsonPropertyName("stockBasedCompensation")]
        public string? StockBasedCompensation { get; set; }

        [JsonPropertyName("otherNonCashItems")]
        public string? OtherNonCashItems { get; set; }

        [JsonPropertyName("freeCashFlow")]
        public string? FreeCashFlow { get; set; }
    }
}