using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Exchanges
{
    public class TradingHoursExternalDto
    {
        public string? Open { get; set; }
        public string? Close { get; set; }
        [JsonPropertyName("OpenUTC")]
        public string? OpenUtc { get; set; }
        [JsonPropertyName("CloseUTC")]
        public string? CloseUtc { get; set; }
        public string? WorkingDays { get; set; }
    }
}