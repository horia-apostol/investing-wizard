namespace InvestingWizard.Domain.Companies
{
    public class DividendRateResult(decimal? value, string currencyCode)
    {
        public decimal? Value { get; } = value;
        public string CurrencyCode { get; } = currencyCode;
    }
}
