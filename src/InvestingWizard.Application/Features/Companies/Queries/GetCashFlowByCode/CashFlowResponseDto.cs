namespace InvestingWizard.Application.Features.Companies.Queries.GetCashFlowByCodeQuery
{
    public class CashFlowResponseDto
    {
        public DateOnly? Date { get; set; }
        public DateOnly? FilingDate { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Investments { get; set; }
        public string? TotalCashFromFinancingActivities { get; set; }
        public string? NetIncome { get; set; }
        public string? ChangeInCash { get; set; }
        public string? Depreciation { get; set; }
        public string? DividendsPaCode { get; set; }
        public string? ChangeToInventory { get; set; }
        public string? ChangeToAccountReceivables { get; set; }
        public string? SalePurchaseOfStock { get; set; }
        public string? OtherCashflowsFromFinancingActivities { get; set; }
        public string? CapitalExpenditures { get; set; }
        public string? TotalCashFromOperatingActivities { get; set; }
        public string? ChangeReceivables { get; set; }
        public string? ChangeInWorkingCapital { get; set; }
        public string? StockBasedCompensation { get; set; }
        public string? OtherNonCashItems { get; set; }
        public string? FreeCashFlow { get; set; }
    }
}