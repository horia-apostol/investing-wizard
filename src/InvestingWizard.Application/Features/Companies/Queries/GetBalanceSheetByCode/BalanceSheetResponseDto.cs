namespace InvestingWizard.Application.Features.Companies.Queries.GetBalanceSheetByCodeQuery
{
    public class BalanceSheetResponseDto
    {
        public DateOnly? Date { get; set; }
        public DateOnly? FilingDate { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal? TotalAssets { get; set; }
        public decimal? IntangibleAssets { get; set; }
        public decimal? EarningAssets { get; set; }
        public decimal? OtherCurrentAssets { get; set; }
        public decimal? TotalLiab { get; set; }
        public decimal? TotalStockholderEquity { get; set; }
        public decimal? DeferredLongTermLiab { get; set; }
        public decimal? OtherCurrentLiab { get; set; }
        public decimal? CommonStock { get; set; }
        public decimal? CapitalStock { get; set; }
        public decimal? RetainedEarnings { get; set; }
        public decimal? OtherLiab { get; set; }
        public decimal? GoodWill { get; set; }
        public decimal? OtherAssets { get; set; }
        public decimal? Cash { get; set; }
        public decimal? CashAndEquivalents { get; set; }
        public decimal? TotalCurrentLiabilities { get; set; }
        public decimal? CurrentDeferredRevenue { get; set; }
        public decimal? NetDebt { get; set; }
        public decimal? ShortTermDebt { get; set; }
        public decimal? ShortLongTermDebt { get; set; }
        public decimal? ShortLongTermDebtTotal { get; set; }
        public decimal? OtherStockholderEquity { get; set; }
        public decimal? PropertyPlantEquipment { get; set; }
        public decimal? TotalCurrentAssets { get; set; }
        public decimal? LongTermInvestments { get; set; }
        public decimal? NetTangibleAssets { get; set; }
        public decimal? ShortTermInvestments { get; set; }
        public decimal? NetReceivables { get; set; }
        public decimal? LongTermDebt { get; set; }
        public decimal? Inventory { get; set; }
        public decimal? AccountsPayable { get; set; }
        public decimal? TotalPermanentEquity { get; set; }
        public decimal? AdditionalPaCodeInCapital { get; set; }
        public decimal? NonCurrrentAssetsOther { get; set; }
        public decimal? NonCurrentAssetsTotal { get; set; }
        public decimal? NonCurrentLiabilitiesOther { get; set; }
        public decimal? NonCurrentLiabilitiesTotal { get; set; }
        public decimal? NegativeGoodwill { get; set; }
        public decimal? Warrants { get; set; }
        public decimal? PreferredStockRedeemable { get; set; }
        public decimal? CapitalSurpluse { get; set; }
        public decimal? LiabilitiesAndStockholdersEquity { get; set; }
        public decimal? CashAndShortTermInvestments { get; set; }
        public decimal? AccumulatedDepreciation { get; set; }
        public decimal? CommonStockSharesOutstanding { get; set; }
    }
}