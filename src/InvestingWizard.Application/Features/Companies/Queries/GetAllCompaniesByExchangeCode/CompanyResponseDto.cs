namespace InvestingWizard.Application.Features.Companies.Queries.GetAllCompaniesByExchangeCode
{
    public class CompanyResponseDto
    {
        public string? Code { get; set; }
        public string? Ticker { get; set; }
        public string? Name { get; set; }
    }
}