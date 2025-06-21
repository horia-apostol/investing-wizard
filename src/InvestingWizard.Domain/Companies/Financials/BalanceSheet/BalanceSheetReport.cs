namespace InvestingWizard.Domain.Companies
{
    public class BalanceSheetReport
    {
        public string? CurrencyCode { get; set; }
        public List<BalanceSheet>? QuarterlyBalanceSheet { get; set; }
        public List<BalanceSheet>? YearlyBalanceSheet { get; set; }
    }

}