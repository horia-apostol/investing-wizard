namespace InvestingWizard.Application.Features.Companies.Queries.GetCashFlowByCodeQuery
{
    public class CashFlowReportResponseDto
    {
        public string? CurrencyCode { get; set; }
        public List<CashFlowResponseDto>? QuarterlyCashFlow { get; set; }
        public List<CashFlowResponseDto>? YearlyCashFlow { get; set; }
    }
}