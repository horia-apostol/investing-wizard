namespace InvestingWizard.Application.Features.Companies.Queries.GetBalanceSheetByCodeQuery
{
    public class BalanceSheetReportResponseDto
    {
        public string? CurrencyCode { get; set; }
        public List<BalanceSheetResponseDto>? QuarterlyBalanceSheet { get; set; }
        public List<BalanceSheetResponseDto>? YearlyBalanceSheet { get; set; }
    }
}