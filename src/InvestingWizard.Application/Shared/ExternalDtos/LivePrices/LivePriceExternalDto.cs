using System.Text.Json.Serialization;

namespace InvestingWizard.Application.Shared.ExternalDtos.LivePrices
{
    public class LivePriceExternalDto
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        [JsonPropertyName("timestamp")]
        public decimal Timestamp { get; set; }
        [JsonPropertyName("gmtoffset")]
        public decimal GmtOffset { get; set; }
        [JsonPropertyName("open")]
        public decimal Open { get; set; }
        [JsonPropertyName("high")]
        public decimal High { get; set; }
        [JsonPropertyName("low")]
        public decimal Low { get; set; }
        [JsonPropertyName("close")]
        public decimal Close { get; set; }
        [JsonPropertyName("volume")]
        public long Volume { get; set; }
        [JsonPropertyName("previousClose")]
        public decimal PreviousClose { get; set; }
        [JsonPropertyName("change")]
        public decimal Change { get; set; }
        [JsonPropertyName("change_p")]
        public decimal ChangePercent { get; set; }
    }
}
