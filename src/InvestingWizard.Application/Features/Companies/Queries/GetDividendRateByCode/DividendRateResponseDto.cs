namespace InvestingWizard.Application.Features.Companies.Queries.GetDividendRateByCode
{
    public class DividendRateResponseDto
    {
        public decimal Value { get; set; }
        public string? CurrencyCode { get; set; }
    }
}