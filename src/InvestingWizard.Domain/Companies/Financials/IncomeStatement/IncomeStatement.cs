namespace InvestingWizard.Domain.Companies
{
    public class IncomeStatement
    {
        public Guid Id { get; set; }
        public DateOnly? Date { get; set; }
        public DateOnly? FilingDate { get; set; }
        public string? CurrencyCode { get; set; }
        public string? ResearchDevelopment { get; set; }
        public string? IncomeBeforeTax { get; set; }
        public string? NetIncome { get; set; }
        public string? SellingGeneralAdministrative { get; set; }
        public string? GrossProfit { get; set; }
        public string? EBIT { get; set; }
        public string? EBITDA { get; set; }
        public string? DepreciationAndAmortization { get; set; }
        public string? OperatingIncome { get; set; }
        public string? OtherOperatingExpenses { get; set; }
        public string? TaxProvision { get; set; }
        public string? IncomeTaxExpense { get; set; }
        public string? TotalRevenue { get; set; }
        public string? TotalOperatingExpenses { get; set; }
        public string? CostOfRevenue { get; set; }
        public string? TotalOtherIncomeExpenseNet { get; set; }
        public string? NetIncomeFromContinuingOps { get; set; }
    }
}