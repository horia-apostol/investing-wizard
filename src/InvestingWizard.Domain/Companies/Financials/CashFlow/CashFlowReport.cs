namespace InvestingWizard.Domain.Companies
{
    public class CashFlowReport
    {
        public string? CurrencyCode { get; set; }
        public List<CashFlow>? QuarterlyCashFlow { get; set; }  
        public List<CashFlow>? YearlyCashFlow { get; set; }
    }
}