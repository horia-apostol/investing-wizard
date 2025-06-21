using InvestingWizard.Domain.Companies;

namespace InvestingWizard.Application.Features.Companies.Queries.GetIncomeStatementByCode
{
    public class IncomeStatementReportResponseDto
    {
        public string? CurrencyCode { get; set; }
        public List<IncomeStatementResponseDto>? QuarterlyIncomeStatement { get; set; }
        public List<IncomeStatementResponseDto>? YearlyIncomeStatement { get; set; }
    }
}