using InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeByCode;

namespace InvestingWizard.Application.Features.Exchanges.Queries.GetExchangeDataFromExternalApi
{
    public class ExchangeDataResponseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? OperatingMIC { get; set; }
        public string? Country { get; set; }
        public string? CurrencyCode { get; set; }
        public string? TimeZone { get; set; }
        public List<HolidayResponseDto>? Holidays { get; set; }
        public TradingHoursResponseDto? TradingHours { get; set; }
    }
}