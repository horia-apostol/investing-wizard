
using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class BalanceSheetExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("filing_date")]
        public string? FilingDate { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string? CurrencySymbol { get; set; }

        [JsonPropertyName("totalAssets")]
        public string? TotalAssets { get; set; }

        [JsonPropertyName("intangibleAssets")]
        public string? IntangibleAssets { get; set; }

        [JsonPropertyName("earningAssets")]
        public string? EarningAssets { get; set; }

        [JsonPropertyName("otherCurrentAssets")]
        public string? OtherCurrentAssets { get; set; }

        [JsonPropertyName("totalLiab")]
        public string? TotalLiab { get; set; }

        [JsonPropertyName("totalStockholderEquity")]
        public string? TotalStockholderEquity { get; set; }

        [JsonPropertyName("deferredLongTermLiab")]
        public string? DeferredLongTermLiab { get; set; }

        [JsonPropertyName("otherCurrentLiab")]
        public string? OtherCurrentLiab { get; set; }

        [JsonPropertyName("commonStock")]
        public string? CommonStock { get; set; }

        [JsonPropertyName("capitalStock")]
        public string? CapitalStock { get; set; }

        [JsonPropertyName("retainedEarnings")]
        public string? RetainedEarnings { get; set; }

        [JsonPropertyName("otherLiab")]
        public string? OtherLiab { get; set; }

        [JsonPropertyName("goodWill")]
        public string? GoodWill { get; set; }

        [JsonPropertyName("otherAssets")]
        public string? OtherAssets { get; set; }

        [JsonPropertyName("cash")]
        public string? Cash { get; set; }

        [JsonPropertyName("cashAndEquivalents")]
        public string? CashAndEquivalents { get; set; }

        [JsonPropertyName("totalCurrentLiabilities")]
        public string? TotalCurrentLiabilities { get; set; }

        [JsonPropertyName("currentDeferredRevenue")]
        public string? CurrentDeferredRevenue { get; set; }

        [JsonPropertyName("netDebt")]
        public string? NetDebt { get; set; }

        [JsonPropertyName("shortTermDebt")]
        public string? ShortTermDebt { get; set; }

        [JsonPropertyName("shortLongTermDebt")]
        public string? ShortLongTermDebt { get; set; }

        [JsonPropertyName("shortLongTermDebtTotal")]
        public string? ShortLongTermDebtTotal { get; set; }

        [JsonPropertyName("otherStockholderEquity")]
        public string? OtherStockholderEquity { get; set; }

        [JsonPropertyName("propertyPlantEquipment")]
        public string? PropertyPlantEquipment { get; set; }

        [JsonPropertyName("totalCurrentAssets")]
        public string? TotalCurrentAssets { get; set; }

        [JsonPropertyName("longTermInvestments")]
        public string? LongTermInvestments { get; set; }

        [JsonPropertyName("netTangibleAssets")]
        public string? NetTangibleAssets { get; set; }

        [JsonPropertyName("shortTermInvestments")]
        public string? ShortTermInvestments { get; set; }

        [JsonPropertyName("netReceivables")]
        public string? NetReceivables { get; set; }

        [JsonPropertyName("longTermDebt")]
        public string? LongTermDebt { get; set; }

        [JsonPropertyName("inventory")]
        public string? Inventory { get; set; }

        [JsonPropertyName("accountsPayable")]
        public string? AccountsPayable { get; set; }

        [JsonPropertyName("totalPermanentEquity")]
        public string? TotalPermanentEquity { get; set; }

        [JsonPropertyName("additionalPaCodeInCapital")]
        public string? AdditionalPaCodeInCapital { get; set; }

        [JsonPropertyName("nonCurrrentAssetsOther")]
        public string? NonCurrrentAssetsOther { get; set; }

        [JsonPropertyName("nonCurrentAssetsTotal")]
        public string? NonCurrentAssetsTotal { get; set; }

        [JsonPropertyName("nonCurrentLiabilitiesOther")]
        public string? NonCurrentLiabilitiesOther { get; set; }

        [JsonPropertyName("nonCurrentLiabilitiesTotal")]
        public string? NonCurrentLiabilitiesTotal { get; set; }

        [JsonPropertyName("negativeGoodwill")]
        public string? NegativeGoodwill { get; set; }

        [JsonPropertyName("warrants")]
        public string? Warrants { get; set; }

        [JsonPropertyName("preferredStockRedeemable")]
        public string? PreferredStockRedeemable { get; set; }

        [JsonPropertyName("capitalSurpluse")]
        public string? CapitalSurpluse { get; set; }

        [JsonPropertyName("liabilitiesAndStockholdersEquity")]
        public string? LiabilitiesAndStockholdersEquity { get; set; }

        [JsonPropertyName("cashAndShortTermInvestments")]
        public string? CashAndShortTermInvestments { get; set; }

        [JsonPropertyName("accumulatedDepreciation")]
        public string? AccumulatedDepreciation { get; set; }

        [JsonPropertyName("commonStockSharesOutstanding")]
        public string? CommonStockSharesOutstanding { get; set; }
    }
}