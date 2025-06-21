namespace InvestingWizard.Domain.Companies
{
    public class IncomeStatementReport
    {
        public string? CurrencyCode { get; set; }
        public List<IncomeStatement>? QuarterlyIncomeStatement { get; set; }
        public List<IncomeStatement>? YearlyIncomeStatement { get; set; }
    }
}