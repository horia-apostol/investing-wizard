using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.Prices
{
    public class PriceExternalDto
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }
        [JsonPropertyName("open")]
        public decimal? Open { get; set; }
        [JsonPropertyName("high")]
        public decimal? High { get; set; }
        [JsonPropertyName("low")]
        public decimal? Low { get; set; }
        [JsonPropertyName("close")]
        public decimal? Close { get; set; }
        [JsonPropertyName("adjusted_close")]
        public decimal? AdjustedClose { get; set; }
        [JsonPropertyName("volume")]
        public long? Volume { get; set; }
    }
}
