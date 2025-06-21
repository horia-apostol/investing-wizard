using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Companies
{
    public class TechnicalsExternalDto
    {
        public decimal? Beta { get; set; }
        [JsonPropertyName("52WeekHigh")]
        public decimal? _52WeekHigh { get; set; }
        [JsonPropertyName("52WeekLow")]
        public decimal? _52WeekLow { get; set; }
        [JsonPropertyName("50DayMA")]
        public decimal? _50DayMA { get; set; }
        [JsonPropertyName("200DayMA")]
        public decimal? _200DayMA { get; set; }
        public long? SharesShort { get; set; }
        public long? SharesShortPriorMonth { get; set; }
        public decimal? ShortRatio { get; set; }
        public decimal? ShortPercent { get; set; }
    }
}