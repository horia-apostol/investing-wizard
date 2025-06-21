using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Exchanges
{
    public class ExchangeExternalDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? OperatingMIC { get; set; }
        public string? Country { get; set; }
        public string? Currency { get; set; }
        [JsonPropertyName("Timezone")]
        public string? TimeZone { get; set; }
        public TradingHoursExternalDto? TradingHours { get; set; }
        public Dictionary<string, HolidayExternalDto>? ExchangeHolidays { get; set; }
        public Dictionary<string, EarlyCloseDayExternalDto>? ExchangeEarlyCloseDays { get; set; }
    }
}