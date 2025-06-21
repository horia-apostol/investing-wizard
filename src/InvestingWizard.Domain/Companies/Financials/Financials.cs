namespace InvestingWizard.Domain.Companies
{
    public class Financials
    {
        public Guid Id { get; set; }
        public BalanceSheetReport? BalanceSheet { get; set; }
        public CashFlowReport? CashFlow { get; set; }
        public IncomeStatementReport? IncomeStatement { get; set; }
    }

}
