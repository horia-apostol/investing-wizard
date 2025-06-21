namespace InvestingWizard.Application.Features.Portfolios.Queries.GetDividendById
{
    public class DividendResponseDto
    {
        public decimal Value { get; set; }
        public string? CurrencyCode { get; set; }
    }
}